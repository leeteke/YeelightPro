using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 场景命令模型
    /// </summary>
    public class GatewayScenesCommandModel
    {
        /// <summary>
        /// 场景ID
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// 期待完成操作的渐变时间（毫秒）
        /// <para>0~60*60*1000 (毫秒)</para>
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 期待开始操作之前的延迟时间（毫秒）
        /// <para>0~60*60*1000 (毫秒)</para>
        /// </summary>
        public int Delay { get; set; }
    }
}
