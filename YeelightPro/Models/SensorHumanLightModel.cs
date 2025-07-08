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
    public class SensorHumanLightModel:ModelBase
    {
        /// <summary>
        /// 当前是否有⼈移动
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// </summary>
        [JsonPropertyName("mv")]
        public int? MotionDetected { get; set; }

        /// <summary>
        /// 光亮等级
        /// <para>1档：小于23lux </para>
        /// <para>2档：23~50lux</para>
        /// <para>3档：50~150lux</para>
        /// <para>4档：150~250lux</para>
        /// <para>5档：250~350lux</para>
        /// <para>6档：350~450lux</para>
        /// <para>7档：450~600lux</para>
        /// <para>8档：＞600lux</para>
        /// </summary>
        [JsonPropertyName("level")]
        public int? Level { get; set; }
    }
}
