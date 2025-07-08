using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 迈睿人体传感器
    /// </summary>
    public class SensorMerrytekModel:ModelBase
    {
        /// <summary>
        /// 当前是否有⼈移动
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// </summary>
        [JsonPropertyName("mv")]
        public int? MotionDetected { get; set; }


        /// <summary>
        /// 光照度值(lux)
        /// </summary>
        [JsonPropertyName("luminance")]
        public int? Luminance { get; set; }
    }
}
