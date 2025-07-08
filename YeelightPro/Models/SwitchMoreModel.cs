using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 继电器-多路开关面板
    /// </summary>
    internal class SwitchMoreModel : ModelBase
    {
        /// <summary>
        /// 第一个按键开关
        /// </summary>
        [JsonPropertyName("1-sp")]
        public bool? SP_1 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("2-sp")]
        public bool? SP_2 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("3-sp")]
        public bool? SP_3 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("4-sp")]
        public bool? SP_4 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("5-sp")]
        public bool? SP_5 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("6-sp")]
        public bool? SP_6 { get; set; }
    }
}
