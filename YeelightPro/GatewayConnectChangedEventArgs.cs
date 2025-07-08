using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 网关连接事件参数
    /// </summary>
    public class GatewayConnectChangedEventArgs : EventArgs
    {
                     
        /// <summary>
        /// 当前状态
        /// </summary>
        public bool Connected { get; }
        /// <summary>
        /// 消息
        /// </summary>
        public string? Msg { get; }
        /// <summary>
        /// 网关连接事件参数
        /// </summary>
        /// <param name="isConnected"></param>
        /// <param name="msg"></param>
        public GatewayConnectChangedEventArgs(bool isConnected, string? msg=null)
        {
            Connected = isConnected;
            Msg = msg;
        }
    }
}
