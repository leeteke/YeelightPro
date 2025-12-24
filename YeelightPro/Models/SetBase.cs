using System;
using System.Collections.Generic;
using System.Text;

namespace YeelightPro.Models
{
    /// <summary>
    /// 设置基类
    /// </summary>
    public class SetBase
    {
        internal readonly Dictionary<string, object> _result = new Dictionary<string, object>();

        /// <summary>
        /// 设置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToSet() => _result;
    }
}
