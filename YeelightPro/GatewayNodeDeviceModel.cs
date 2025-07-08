using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 节点设备数据模型
    /// </summary>
    public class GatewayNodeDeviceModel
    {
        /// <summary>
        /// 节点类型
        /// </summary>
        public GatewayNodeType NodeType { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 设备ID
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 节点设备类型
        /// </summary>
        public GatewayNodeDeviceType Type { get; set; }

        /// <summary>
        /// 固件版本号
        /// </summary>
        public string FirmwareVersion { get; set; } = null!;

        /// <summary>
        /// 详情参数
        /// </summary>
        public JsonObject? Params { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// 数据更新时间
        /// </summary>
        public DateTime UpdateTime { get; internal set; }
    }
}
