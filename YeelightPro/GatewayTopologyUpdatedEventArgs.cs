using System;
using System.Collections.Generic;
using System.Text;

namespace YeelightPro
{
    /// <summary>
    /// 拓扑更新事件参数
    /// </summary>
    public class GatewayTopologyUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// 改变的节点ID
        /// </summary>
        public GatewayNodeModel Node { get; }

        /// <summary>
        /// 改变的类型
        /// </summary>
        public GatewayTopologyUpdatedType Type { get; }


        public GatewayTopologyUpdatedEventArgs(GatewayNodeModel nodeDevice, GatewayTopologyUpdatedType type)
        {
            Node = nodeDevice;
            Type = type;
        }
    }


}
