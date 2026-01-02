using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace YeelightPro
{
    /// <summary>
    /// YeeligntPro 系列产品
    /// <para>网关局域网控制</para>
    /// <para>根据官方局域⽹协议 2.4 编写</para>
    /// </summary>
    public class Gateway : IDisposable
    {

        #region Const
        /// <summary>
        /// UDP⼴播格式
        /// </summary>
        public const string BroadcastMsg = "YEELIGHT_GATEWAY_CONTROL_DISCOVER\r\n";
        /// <summary>
        /// UDP广播端口号
        /// </summary>
        public const int BroadcastPoint = 1982;

        /// <summary>
        /// 网关默认端口
        /// </summary>
        public const int GatewayPoint = 65443;

        #endregion

        #region Static Public Method


        /// <summary>
        /// 查找网关
        /// </summary>
        /// <returns>查找到的网关信息</returns>
        /// <exception cref="NotImplementedException">该方法目前无法验证，所以切勿使用</exception>
        //public static GatewayInfo? FindGateway()
        //{
        //    using Socket udp = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //    IPEndPoint iep = new(System.Net.IPAddress.Broadcast, BroadcastPoint);
        //    var sendData = Encoding.UTF8.GetBytes(BroadcastMsg);
        //    udp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);


        //    string? recMsg = null;//接受到的数据

        //    using AutoResetEvent are = new(false);//卡裆器
        //    Task.Run(() =>
        //    {
        //        //创建接受客户端
        //        var recData = new byte[1024];
        //        _ = udp.Receive(recData);
        //        recMsg = Encoding.UTF8.GetString(recData).TrimEnd('\0');
        //        are.Set();
        //    });

        //    udp.SendTo(sendData, iep);

        //    //最多等待3秒
        //    if (are.WaitOne(3000))
        //    {
        //        throw new NotImplementedException(recMsg);
        //        // return new GatewayInfo(1, "aaa", 123, "1212");
        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}

        /// <summary>
        /// 推测被拆分的设备的所有ID
        /// </summary>
        /// <param name="type">类型:
        /// <para>215-S系列情景开关(跑道屏);</para>
        /// <para>216-S系列墙面旋钮屏开关;</para>
        /// <para>217-E系列浴霸;</para>
        /// <para>218-极致吊灯;</para>
        /// <para>219-G60 Pro青空灯;</para>
        /// </param>
        /// <param name="pid">节点ID</param>
        /// <returns>所有的设备id和对应类型</returns>
        public static (long id, GatewayNodeDeviceType type)[] NodeIdSpeculator(int @type, long pid)
        {
            return type switch
            {
                //S系列情景开关(跑道屏)
                215 => [
                    (pid,GatewayNodeDeviceType.Switch_More),
                    (2<<56|pid,GatewayNodeDeviceType.Switch_More),
                    (1<<56|pid,GatewayNodeDeviceType.ControlPanel),
                    (4<<56|pid,GatewayNodeDeviceType.ControlPanel),
                    (8<<56|pid,GatewayNodeDeviceType.ControlPanel)
                    ],
                //S系列墙面旋钮屏开关
                216 => [(pid, GatewayNodeDeviceType.Switch_Double)],

                //E系列浴霸
                217 => [
                    (1<<56|pid,GatewayNodeDeviceType.Light_Brightness),
                    (2<<56|pid,GatewayNodeDeviceType.BathHeater)
                    ],
                //极致吊灯
                218 => [
                    (1<<56|pid,GatewayNodeDeviceType.Light_Temperature),
                    (2<<56|pid,GatewayNodeDeviceType.Light_Color),
                    (3<<56|pid,GatewayNodeDeviceType.Sensor_TOF)
                    ],
                //G60 Pro青空灯
                219 => [
                    (1<<56|pid,GatewayNodeDeviceType.Light_Temperature),
                    (2<<56|pid,GatewayNodeDeviceType.Sensor_Peson)
                    ],
                _ => [],
            };
        }


        #endregion

        static JsonSerializerOptions CCNullOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        #region Properties
        /// <summary>
        /// 网关属性
        /// </summary>
        public string IP => _ip;
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnected => _socket != null && _socket.Connected;
        /// <summary>
        /// 节点设备
        /// </summary>
        public ConcurrentDictionary<ulong, GatewayNodeDeviceModel> NodeDevices => _devices;

        /// <summary>
        /// 房间信息
        /// </summary>
        public Dictionary<ulong, string> Rooms => _rooms;

        /// <summary>
        /// 情景信息
        /// </summary>
        public Dictionary<ulong, string> Scenes => _scenes;

        #endregion


        #region Fields

        private Socket _socket = null!;//socket
        private string _ip;//设备地址
        private readonly int _receiveBufferSize = 1024 * 64;
        private byte[] _receiveBuffer = null!;//64K的缓存空间
        private List<byte> _receivePool = new List<byte>();//数据池

        private uint _uuid = 100000;
        private readonly object _uuidLock = new();
        private ConcurrentDictionary<ulong, GatewayNodeDeviceModel> _devices = new ConcurrentDictionary<ulong, GatewayNodeDeviceModel>();//所有设备信息
        private Dictionary<ulong, string> _rooms = new Dictionary<ulong, string>();//所有房间信息
        private Dictionary<ulong, string> _scenes = new Dictionary<ulong, string>();//所有情景模式
        private ConcurrentDictionary<uint, JsonNode> _receiveQueue = new ConcurrentDictionary<uint, JsonNode>();//数据接受池


        #endregion

        /// <summary>
        ///  YeeligntPro 系列产品
        /// <para>网关</para>
        /// <para>根据官方局域⽹协议 V2.4 编写</para>
        /// </summary>
        /// <param name="defaultIP">网关默认IP地址，设置个默认地址，该地址可在连接设备时修改</param>
        public Gateway(string defaultIP)
        {
            _ip = defaultIP;
        }

        #region IDisposable
        /// <summary>
        /// 析构
        /// </summary>
        ~Gateway()
        {
            Dispose(false);
        }
        bool _disposed; //是否回收完毕
        /// <summary>
        /// IDisposable接口
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing">是否需要释放那些实现IDisposable接口的托管对象</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {

                //TODO:释放那些实现IDisposable接口的托管对象
                _socket?.Dispose();
            }
            //TODO:释放非托管资源，设置对象为null
            _receiveBuffer = null!;

            _receivePool.Clear();
            _receivePool = null!;

            _devices.Clear();
            _devices = null!;

            _disposed = true;
        }
        #endregion

        #region Public Method

        /// <summary>
        /// 链接设备
        /// </summary>
        /// <param name="newIPAddress">不设置地址则使用初始化IP</param>
        /// <exception cref="GatewayRepeatedConnectException">重复连接</exception>
        public void Connect(string? newIPAddress = null)
        {
            if (_socket?.Connected == true)
                throw new GatewayRepeatedConnectException();


            if (newIPAddress != null)
            {
                _ip = newIPAddress;
            }

            _socket?.Dispose();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(new IPEndPoint(IPAddress.Parse(IP), GatewayPoint));
            RaiseConnectedChanged(true, "Success.");
            _receiveBuffer = new byte[_receiveBufferSize];
            _socket.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, OnReceive, _socket);

        }

        /// <summary>
        /// 更新子节点设备
        /// </summary>
        public void UpdateTopology()
        {
            Send(new JsonObject()
            {
                {"id",GetUUID() },//稍微有点难受的固定值因为设置了动态值不会有啥任何意义
                {"method",GatewayMethod.Get_Topology}
            });
        }

        /// <summary>
        /// 更新Room
        /// </summary>
        public async Task UpdateRoomsAsync(CancellationToken cancellationToken = default)
        {
            var result = await SendAndGetAsync(new JsonObject()
            {
                {"id",GetUUID() },
                {"method",GatewayMethod.Get_Room},
                {"params", new JsonObject()
                {
                    {"id", 0}
                } }
            }, cancellationToken).ConfigureAwait(false); ;
            if (result != null)
            {
                var rooms = result["rooms"]!.AsArray();
                _rooms.Clear();
                foreach (var item in rooms)
                {
                    _rooms.TryAdd(item!["id"]!.GetValue<ulong>(), item["n"]!.GetValue<string>());
                }
            }
        }
        /// <summary>
        /// 更新情景信息
        /// </summary>
        /// <returns></returns>
        public async Task UpdateScenesAsync(CancellationToken cancellationToken = default)
        {
            var result = await SendAndGetAsync(new JsonObject()
            {
                {"id",GetUUID() },
                {"method",GatewayMethod.Get_Scene},
                {"params", new JsonObject()
                {
                    {"id", 0}
                } }
            }, cancellationToken).ConfigureAwait(false);
            if (result != null)
            {
                var scenes = result["scenes"]!.AsArray();
                _scenes.Clear();
                foreach (var item in scenes)
                {
                    _scenes.TryAdd(item!["id"]!.GetValue<ulong>(), item["n"]!.GetValue<string>());
                }
            }
        }

        /// <summary>
        /// 获取单个节点属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GatewayNodeDeviceModel?> GetNodeDevicePropertiesAsync(ulong id, CancellationToken cancellationToken = default)
        {

            try
            {

                if (_devices.TryGetValue(id, out var device))
                {
                    var result = await SendAndGetAsync(new JsonObject()
                    {
                        {"id",GetUUID() },
                        {"method",GatewayMethod.Get_Node},
                        {"params",new JsonObject(){
                            {"id",id }
                        }}
                    }, cancellationToken).ConfigureAwait(false);
                    if (result != null)
                    {
                        var props = result["nodes"]?.AsArray();
                        //不为空
                        //id相同
                        if (props != null && props.Count != 0 && props.First()?["id"]?.GetValue<ulong>() == id)
                        {

                            RaisePropertiesUpdated(result);

                            return device;
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;

            }
        }


        /// <summary>
        /// 控制
        /// </summary>
        /// <returns></returns>
        public async Task<(bool executed, string? msg)> CommandAsync(GatewayCommandModel[] commands, CancellationToken cancellationToken = default)
        {
            try
            {

                var result = await SendAndGetAsync(new JsonObject()
                {
                {"id",GetUUID() },
                {"method",GatewayMethod.Set_Prop},
                {"nodes", JsonSerializer.SerializeToNode(commands, typeof(GatewayCommandModel[]), GatewayJsonSerializerContextAOT.Default)}
                }, cancellationToken).ConfigureAwait(false);

                if (result != null)
                {
                    if (result["result"]?.GetValue<string>() == "ok")
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, result["data"]?["msg"]?.GetValue<string>());
                    }
                }

                return (false, "执行超时，请留意设备变化。");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        /// <summary>
        /// 场景控制
        /// </summary>
        /// <returns></returns>
        public async Task<(bool executed, string? msg)> ScenesCommandAsync(GatewayScenesCommandModel[] commands, CancellationToken cancellationToken = default)
        {


            var result = await SendAndGetAsync(new JsonObject()
            {
                {"id",GetUUID() },
                {"method",GatewayMethod.Set_Prop},
                {"scenes",JsonSerializer.SerializeToNode(commands,typeof(GatewayScenesCommandModel[]),GatewayJsonSerializerContextAOT.Default) }
            }, cancellationToken).ConfigureAwait(false);




            if (result != null)
            {
                if (result["result"]?.GetValue<string>() == "ok")
                {
                    return (true, null);
                }
                else
                {
                    return (false, result["data"]?["msg"]?.GetValue<string>());
                }
            }

            return (false, "执行超时，请留意设备变化。");
        }

        #endregion

        #region event


        /// <summary>
        /// 状态发生了改变
        /// </summary>
        public event EventHandler<GatewayConnectChangedEventArgs>? ConnectChanged;

        /// <summary>
        /// 事件触发了
        /// </summary>
        public event EventHandler<GatewayEventTriggeredEventArgs>? EventTriggered;

        /// <summary>
        /// 设备属性发生变化
        /// </summary>
        public event EventHandler<GatewayPropertiesUpdatedEventArgs>? PropertiesUpdated;

        /// <summary>
        /// 通讯记录事件
        /// </summary>
        public event EventHandler<GatewayCommunicationRecordEventArgs>? CommunicationRecord;
        #endregion

        #region Private
        /// <summary>
        /// 接受信息
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            try
            {
                var read = socket!.EndReceive(ar);
                if (read > 0)
                {
                    var data = _receiveBuffer.Take(read).ToArray();
                    //utf-8
                    var receiveJosn = Encoding.UTF8.GetString(data);

                    RaiseCommunicationRecord(true, receiveJosn);
                    //每段json最后以"\r\n"结尾
                    var receiveDatas = receiveJosn.Split("\r\n");
                    foreach (var item in receiveDatas)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                            RaiseReceived(item);
                    }

                    _socket.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, OnReceive, _socket);
                }
                else //断开连接
                {
                    socket.Close();
                    RaiseConnectedChanged(false, "Disconnected.");
                }
            }
            catch (Exception ex)
            {
                if (socket!.Connected)
                {
                    return;
                }
                socket.Close();
                RaiseConnectedChanged(false, ex.Message);
            }
        }


        /// <summary>
        /// 获取随机端口
        /// </summary>
        /// <returns></returns>
        public static int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        /// <summary>
        /// 通知时间发生
        /// </summary>
        /// <param name="isConnected"></param>
        /// <param name="msg"></param>
        private void RaiseConnectedChanged(bool isConnected, string? msg = null)
        {
            ConnectChanged?.Invoke(this, new GatewayConnectChangedEventArgs(isConnected, msg));
        }

        /// <summary>
        /// 通知接收到了数据
        /// </summary>
        /// <param name="jsonStr"></param>
        private void RaiseReceived(string jsonStr)
        {
            try
            {
                var js = JsonNode.Parse(jsonStr);
                if (js != null)
                {
                    switch (js["method"]?.GetValue<string>())
                    {
                        case GatewayMethod.Post_Event:
                            RaiseEventTriggered(js);
                            break;
                        case GatewayMethod.Post_Topology:
                            UpdateTopology(js);
                            break;
                        case GatewayMethod.Post_Prop:
                            RaisePropertiesUpdated(js);
                            break;
                        default:

                            //其他为返回结果不在此范围
                            break;
                    }

                    var queueId = js["id"]!.GetValue<uint>();
                    if (_receiveQueue.Count > 50)
                        _receiveQueue.Clear();

                    _receiveQueue.AddOrUpdate(queueId, js, (o, n) => n);


                }
            }
            catch
            {

                //这里这些异常暂时直接启用，因为 怕干扰tcp
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="js"></param>
        private void RaiseEventTriggered(JsonNode js)
        {
            //nodes 为数组，
            //可能会有多个事件一起触发
            var jsa = js["nodes"]!.AsArray();
            foreach (var item in jsa)
            {
                if (item != null)
                {
                    Task.Run(() =>
                    {
                        EventTriggered?.Invoke(this,
                            new GatewayEventTriggeredEventArgs(
                                item["id"]!.GetValue<ulong>(),
                                (GatewayNodeType)item["nt"]!.GetValue<int>(),
                                item["value"]!.GetValue<string>(),
                                item["params"]!));

                    });

                }

            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="js"></param>
        private void RaisePropertiesUpdated(JsonNode js)
        {


            var ps = js["nodes"]?.AsArray();
            if (ps != null)
            {
                foreach (var prop in ps)
                {
                    var id = prop!["id"]?.GetValue<ulong>();
                    if (id != null)
                    {
                        if (_devices.TryGetValue((ulong)id, out var device))
                        {

                            var changed = AnalysisPropertiesChanged(ref device, prop.AsObject());
                            if (changed != null)
                            {
                                Task.Run(() =>
                                {
                                    PropertiesUpdated?.Invoke(this, new GatewayPropertiesUpdatedEventArgs((ulong)id, device.Type, changed.Value.old, changed.Value.@new));
                                });
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="isReceived"></param>
        /// <param name="content"></param>
        private void RaiseCommunicationRecord(bool isReceived, string content)
        {

            Task.Run(() => { CommunicationRecord?.Invoke(this, new GatewayCommunicationRecordEventArgs(isReceived, content)); });
        }


        /// <summary>
        /// 触发拓扑图
        /// </summary>
        /// <param name="js"></param>
        private void UpdateTopology(JsonNode js)
        {
            if (js["nodes"]!.Deserialize(typeof(GatewayTopologyModel[]), GatewayJsonSerializerContextAOT.Default) is GatewayTopologyModel[] ts)
            {
                foreach (var item in ts)
                {

                    var dev = _devices.GetOrAdd(item.Id, p =>
                    {
                        //新增设备通知
                        return new GatewayNodeDeviceModel()
                        {
                            Id = item.Id,
                            NodeType = item.NodeType,
                            Name = item.Name,
                            Type = item.Type,
                            UpdateTime = DateTime.Now
                        };
                    });


                    if (dev.Name != item.Name)
                    {
                        var oldName = dev.Name;

                        dev.Name = item.Name;
                        dev.UpdateTime = DateTime.Now;
                        //属性更改通知->名称更改

                    }
                }

                //检测发现所需要移除的设备
                var removeIds = _devices.Keys.Except(ts.Select(p => p.Id));
                if (removeIds != null)
                {
                    //移除设备
                    foreach (var rmIds in removeIds)
                    {
                        if (_devices.TryRemove(rmIds, out var _removeDev))
                        {
                            //移除设备通知
                            //暂时用不到
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 获取队列ID
        /// </summary>
        /// <returns></returns>
        private uint GetUUID()
        {
            //防止线程冲突
            lock (_uuidLock)
            {
                if (_uuid < (uint.MaxValue - 1))
                {
                    return ++_uuid;
                }
                else
                {
                    _uuid = 100000;
                    return _uuid;
                }
            }

        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        private void Send(params JsonObject[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendLine(item.ToJsonString());
            }
            TcpSend(sb.ToString());
        }


        /// <summary>
        /// 发送并获取数据
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        private async Task<JsonNode?> SendAndGetAsync(JsonObject jsonObject, CancellationToken cancellationToken = default)
        {
            try
            {

                var uuid = jsonObject["id"]!.GetValue<uint>();

                var sendJson = jsonObject.ToJsonString(CCNullOptions) + "\r\n";

                TcpSend(sendJson);
                int outTime = 3000;
                while (outTime > 0)
                {
                    await Task.Delay(10, cancellationToken).ConfigureAwait(false);

                    if (_receiveQueue.TryRemove(uuid, out JsonNode? result))
                    {
                        if (result != null)
                        {
                            return result;
                        }
                    }
                    outTime -= 10;
                }
                return null;
            }
            catch
            {

                return null;
            }
        }


        private void TcpSend(string json)
        {
            RaiseCommunicationRecord(false, json);
            _socket?.Send(Encoding.UTF8.GetBytes(json));
        }

        /// <summary>
        /// 分析属性的变化
        /// </summary>
        /// <param name="device"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private (JsonObject old, JsonObject @new)? AnalysisPropertiesChanged(ref GatewayNodeDeviceModel device, JsonObject p)
        {

            //数据对比更新
            //通知更新
            JsonObject old = new JsonObject();
            JsonObject @new = new JsonObject();

            //检查姓名
            var pName = p["n"]?.GetValue<string>();
            if (pName != null)
            {
                if (pName != device.Name)
                {
                    old.Add("n", device.Name);
                    @new.Add("n", pName);
                    device.Name = pName;
                }
            }

            //检查在线
            var pOnline = p["o"]?.GetValue<bool>();
            if (pOnline != null)
            {
                if (pOnline != device.IsOnline)
                {

                    old.Add("o", device.IsOnline);
                    @new.Add("0", pOnline);

                    device.IsOnline = (bool)pOnline;
                }
            }

            //检查参数变化
            var po = p["params"]?.AsObject();
            if (po != null)
            {
                if (device.Params == null)
                {
                    device.Params = po;
                    foreach (var param in po)
                    {
                        @new.Add(param.Key, JsonNode.Parse(param.Value!.AsValue().ToJsonString()));
                    }

                }
                else
                {
                    foreach (var item in po)
                    {
                        if (device.Params.ContainsKey(item.Key))
                        {
                            if (device.Params[item.Key]?.ToJsonString() != item.Value?.ToJsonString())
                            {
                                old.Add(item.Key, JsonNode.Parse(device.Params[item.Key]!.AsValue().ToJsonString()));
                                @new.Add(item.Key, JsonNode.Parse(item.Value!.AsValue().ToJsonString()));
                                device.Params[item.Key] = JsonNode.Parse(item.Value!.AsValue().ToJsonString());
                            }
                        }
                        else
                        {
                            device.Params.Add(item.Key, JsonNode.Parse(item.Value!.AsValue().ToJsonString()));
                            @new.Add(item.Key, JsonNode.Parse(item.Value!.AsValue().ToJsonString()));
                        }

                    }

                }

            }

            if (@new.Count < 1)
            {
                return null;
            }
            else
            {
                device.UpdateTime = DateTime.Now;
                return (old, @new);
            }

        }
        #endregion



    }
}