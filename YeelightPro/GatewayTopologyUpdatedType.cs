using System;
using System.Collections.Generic;
using System.Text;

namespace YeelightPro
{
    /// <summary>
    /// 拓扑更新类型
    /// </summary>
    public enum GatewayTopologyUpdatedType
    {
        /// <summary>
        /// 新增节点
        /// </summary>
        Add= 0,
        /// <summary>
        /// 节点移除
        /// </summary>
        Reomve=1,
        /// <summary>
        /// 名称改变
        /// </summary>
        Name=2,

        /// <summary>
        /// 房间改变
        /// </summary>
        Room=3

    }
}
