using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 灯具类设备
    /// </summary>
    public class LightModel:ModelBase
    {
        /// <summary>
        /// 开关
        /// </summary>
        [JsonPropertyName("p")]
        public bool? Power { get; set; }
        /// <summary>
        /// 颜⾊
        /// <para>例如：红⾊的⼗进制数为16711680，对应的16进制是0xFF0000（R是FF，G是00，B是00）</para>
        /// </summary>
        [JsonPropertyName("c")]
        public long? Color { get; set; }
        /// <summary>
        /// 色温
        /// </summary>
        [JsonPropertyName("ct")]
        public int? ColorTemperature { get; set; }
        /// <summary>
        /// 亮度
        /// </summary>
        [JsonPropertyName("l")]
        public int? Brightness { get; set; }
        /// <summary>
        /// 光束角度
        /// </summary>
        [JsonPropertyName("angle")]
        public int? Angle { get; set; }
    }
}
