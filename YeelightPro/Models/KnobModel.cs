using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 旋钮
    /// </summary>
    public class KnobModel:ModelBase
    {

        /// <summary>
        /// 第几个？
        /// <para>非官方文档里的参数，实测是的，在旋钮事件里。但是目前还不知道意义。</para>
        /// <para>反向旋转刻度: -128~0</para>
        /// <para>正向向旋转刻度：127~0</para>
        /// </summary>
        [JsonPropertyName("idx")]
        public int? Index { get; set; }
        /// <summary>
        /// 旋钮正常旋转事件params属性-旋钮正常旋转的刻度
        /// <para>反向旋转刻度: -128~0</para>
        /// <para>正向向旋转刻度：127~0</para>
        /// </summary>
        [JsonPropertyName("free_spin")]
        public int? FreeSpin { get; set; }

        /// <summary>
        /// 旋钮按压旋转事件params属性-旋钮按压旋转的刻度
        /// <para>反向旋转刻度: -128~0</para>
        /// <para>正向向旋转刻度：127~0</para>
        /// </summary>
        [JsonPropertyName("hold_spin")]
        public int? HoldSpin { get; set; }

    }
}
