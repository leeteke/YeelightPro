using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 门磁
    /// </summary>
    public class SearsonDoorModel:ModelBase
    {

        /// <summary>
        /// 门磁
        /// <para>⻔窗已打开-0</para>
        /// <para>⻔窗已关闭-1</para>
        /// </summary>
        [JsonPropertyName("dc")]
        public int? Close { get; set; }


        /// <summary>
        /// 门磁 强拆告警
        /// <para>门磁被安上-0</para>
        /// <para>门磁被拆下-1</para>
        /// </summary>
        [JsonPropertyName("alm")]
        public int? Alarm { get; set; }
    }
}
