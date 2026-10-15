using System.Text.Json;
using YeelightPro.Models;

namespace YeelightPro.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DEMO START!");


            Gateway gateway = new Gateway("x.x.x.x");
            gateway.CommunicationRecord += (_, r) =>
            {
                Console.WriteLine("CommunicationRecord IsReceived:{0} Content:{1}", r.IsReceived, r.Content);
            };
            gateway.ConnectChanged += async (_, e) =>
            {
                if (!e.Connected)
                {
                    Console.WriteLine("\t连接丢失\t{0}", e.Msg);
                    while (true)
                    {
                        Console.WriteLine("\t10S后尝试重连");

                        await Task.Delay(10000);
                        try
                        {
                            gateway.Connect();
                            Console.WriteLine("\t连接成功");
                            return;
                        }
                        catch (YeelightPro.GatewayRepeatedConnectException ex)
                        {
                            Console.WriteLine("\t连接成功");
                            //重复连接 说明已经连接上了
                            return;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\t连接失败 {ex}", ex.Message);
                        }
                    }
                }
            };
            gateway.EventTriggered += (o, e) =>
            {
                Console.WriteLine($"id:{e.Id} type:{e.NodeType} value:{e.Value} parms:{e.Params.ToJsonString()}");
            };
            gateway.PropertiesUpdated += (o, e) =>
            {
                Console.WriteLine($"Id:{e.Id}  old:{e.Old.ToJsonString()} new:{e.New.ToJsonString()}");
            };
            gateway.TopologyUpdated += (o, e) =>
            {
                Console.WriteLine($"type;{e.Type} Id:{JsonSerializer.Serialize(e.Node)} ");
            };
            gateway.Connect();
            gateway.UpdateTopology();


            



            while (true)
            {
                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "clear":
                        Console.Clear();
                        break;

                    case "showNodes":
                        Console.WriteLine(string.Join("\r\n", gateway.Nodes.Select(p => $"id:{p.Key} name:{p.Value.Name}")));
                        break;

                    case "test":

                        var node = gateway.Nodes[666666];

                        var light = node.Params.ParmasConverter<YeelightPro.Models.LightModel>();
                        Console.WriteLine(light.Brightness);
                        Console.WriteLine(light.ColorTemperature);

                        break;

                    case "cmd":

                        var cmdA = new GatewayCommandModel()
                        {
                            Id = 666666,
                            Set = new()
                            {
                                { GatewayNodeDeviceProperties.Light_Power, true }
                            }
                        };

                        float brightness_pct = 80;
                        double color_temp_kelvin = 5000;
                        cmdA.Set.Add(GatewayNodeDeviceProperties.Light_Brightness, brightness_pct);
                        cmdA.Set.Add(GatewayNodeDeviceProperties.Light_ColorTemperature, color_temp_kelvin);
                        _ = gateway.CommandAsync([cmdA]);
                        break;
                    case "exit":
                        return;
                    default:
                        break;
                }
            }


        }
    }
}
