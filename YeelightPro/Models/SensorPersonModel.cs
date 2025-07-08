using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 体光感传感器
    /// </summary>
    public class SensorPersonModel : ModelBase
    {
        /// <summary>
        /// 当前是否有⼈移动
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// </summary>
        [JsonPropertyName("mv")]
        public int? MotionDetected { get; set; }

    }
}
