using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 通讯记录事件参数
    /// </summary>
    public class GatewayCommunicationRecordEventArgs : EventArgs
    {
        /// <summary>
        /// 是否为接收数据
        /// </summary>
        public bool IsReceived { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// 通讯记录事件参数
        /// </summary>
        /// <param name="isReceived">是否为接收数据</param>
        /// <param name="content">数据</param>
        public GatewayCommunicationRecordEventArgs(bool isReceived, string content)
        {
            IsReceived = isReceived;
            Content = content;
        }
    }
}
