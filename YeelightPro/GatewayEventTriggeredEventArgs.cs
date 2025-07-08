using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 网关事件触发器参数
    /// </summary>
    public class GatewayEventTriggeredEventArgs : EventArgs
    {

        /// <summary>
        /// 节点类型
        /// </summary>
        public GatewayNodeType NodeType { get; }

        /// <summary>
        /// 事件名称
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 参数
        /// </summary>
        public JsonNode Params { get; }

        /// <summary>
        /// 设备Id
        /// </summary>
        public ulong Id { get; }

        /// <summary>
        /// 网关事件触发器参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nt"></param>
        /// <param name="value"></param>
        /// <param name="params"></param>
        public GatewayEventTriggeredEventArgs(ulong id,GatewayNodeType nt, string value, JsonNode @params)
        {
             Id = id;
            NodeType = nt;
            Value = value;
            Params = @params;
        }
    }
}
