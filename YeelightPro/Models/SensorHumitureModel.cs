using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 温湿度传感器
    /// </summary>
    public class SensorHumitureModel:ModelBase
    {
        /// <summary>
        /// 旋湿度值
        /// </summary>
        [JsonPropertyName("h")]
        public int? Humidity { get; set; }

        /// <summary>
        /// 旋湿度值
        /// </summary>
        [JsonPropertyName("t")]
        public int? Temperature { get; set; }
    }
}
