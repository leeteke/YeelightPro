using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 属性模型
    /// </summary>
    public class S21GatewayPropertiesModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonPropertyName("nt")]
        public GatewayNodeType NodeType { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        [JsonPropertyName("o")]
        public bool Online { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [JsonPropertyName("fv")]
        public string FirmwareVersion { get; set; } = null!;
        /// <summary>
        /// 参数
        /// </summary>
        public JsonObject? Params { get; set; }
    }
}
