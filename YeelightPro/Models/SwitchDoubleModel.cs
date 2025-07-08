using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 继电器-双路控制
    /// </summary>
    public class SwitchDoubleModel : ModelBase
    { /// <summary>
      /// 双路继电器全控
      /// </summary>
        [JsonPropertyName("p")]
        public bool? All { get; set; }
        /// <summary>
        /// 第⼀路继电器开关
        /// </summary>
        [JsonPropertyName("1-p")]
        public bool? P_1 { get; set; }
        /// <summary>
        /// 第二路继电器开关
        /// </summary>
        [JsonPropertyName("2-p")]
        public bool? P_2 { get; set; }
    }
}
