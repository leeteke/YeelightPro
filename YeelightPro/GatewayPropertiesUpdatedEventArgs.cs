using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using YeelightPro;

namespace YeelightPro
{
    /// <summary>
    /// 属性更新事件参数
    /// </summary>
    public class GatewayPropertiesUpdatedEventArgs : EventArgs
    {

        /// <summary>
        /// 旧属性参数
        /// </summary>
        public JsonObject Old { get; }

        /// <summary>
        /// 新属性参数
        /// </summary>
        public JsonObject New { get; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public ulong Id { get; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public GatewayNodeDeviceType Type { get; }
        /// <summary>
        /// 属性更新事件参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceType"></param>
        /// <param name="old"></param>
        /// <param name="new"></param>
        public GatewayPropertiesUpdatedEventArgs(ulong id, GatewayNodeDeviceType deviceType, JsonObject old, JsonObject @new)
        {
            Id = id;
            Type = deviceType;
            Old = old;
            New = @new;
        }


    }
}
