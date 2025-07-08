using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 节点类型
    /// </summary>
    public enum GatewayNodeType
    {
        /// <summary>
        /// 房间
        /// </summary>
        Room = 1,

        /// <summary>
        /// Mesh⼦设备
        /// </summary>
        MeshSubdevice = 2,

        /// <summary>
        /// ⾃定义分组
        /// </summary>
        CustomGroup = 3,

        /// <summary>
        /// Mesh组
        /// </summary>
        MeshGroup = 4,
        /// <summary>
        /// 房屋/整屋
        /// </summary>
        House = 5,
        /// <summary>
        /// 情景
        /// </summary>
        Scene = 6



    }
}
