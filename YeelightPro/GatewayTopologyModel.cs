using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 拓扑模型
    /// </summary>
    public class GatewayTopologyModel
    {
        /// <summary>
        /// 节点类型
        /// </summary>
        [JsonPropertyName("nt")]
        public GatewayNodeType NodeType { get; set; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [JsonPropertyName("n")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 设备类型
        /// </summary>
        public GatewayNodeDeviceType Type { get; set; }

        /// <summary>
        /// 当前设备的可寻址组件数量。例如： 2键多路开关面板有两个可寻址组件；  4键情景面板有四个可寻址组件；
        /// </summary>
        [JsonPropertyName("ch_num")]
        public ulong CH_Num { get; set; }

        /// <summary>
        /// 当前设备的可寻址id组件列表。 例如：  2键多路开关面板有一个可寻址组件id列表为：[16, 16]可寻址组件id含义参考第3节。
        /// </summary>
        [JsonPropertyName("cids")]
        public ulong[] CIds { get; set; } = [];

        /// <summary>
        /// 当前设备所在房间id
        /// </summary>
        public ulong RoomId { get; set; }
    }
}
