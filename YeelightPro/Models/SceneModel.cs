using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{

    /// <summary>
    /// 情景面板
    /// </summary>
    internal class SceneModel:ModelBase
    {
        /// <summary>
        /// 情景面板按键事件params属性-按键的ID
        /// </summary>
        public int? Key { get; set; }

        /// <summary>
        /// 情景面板按键事件params属性-按键的次数
        /// </summary>
        public int? Count { get; set; }
    }
}
