using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// method属性
    /// </summary>
    public class GatewayMethod
    {

        /// <summary>
        /// <para>⽹关->客⼾端</para>
        /// <para>通报⽹关下⾯可以独⽴控制的⼦设备或设备组</para> 
        /// <para>gateway_post.topology</para>
        /// </summary>
        public const string Post_Topology = "gateway_post.topology";

        /// <summary>
        /// <para>⽹关->客⼾端</para>
        /// <para>通报⼦设备或设备组的状态</para> 
        /// <para>gateway_post.prop</para>
        /// </summary>
        public const string Post_Prop = "gateway_post.prop";

        /// <summary>
        /// <para>⽹关->客⼾端</para>
        /// <para>通报传感器触发的事件</para> 
        /// <para>gateway_post.event</para>
        /// </summary>
        public const string Post_Event = "gateway_post.event";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>请求⽹关下⾯可以独⽴控制的⼦设备或设备组</para>
        /// <para>gateway_get.topology</para>
        /// </summary>
        public const string Get_Topology = "gateway_get.topology";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>设备控制（⼦设备、设备组、情景等）</para>
        /// <para>gateway_set.prop</para>
        /// </summary>
        public const string Set_Prop = "gateway_set.prop";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>请求单个设备信息</para>
        /// <para>gateway_get.node</para>
        /// </summary>
        public const string Get_Node = "gateway_get.node";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>请求Mesh灯组信息</para>
        /// <para>gateway_get.group</para>
        /// </summary>
        public const string Get_Group = "gateway_get.group";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>请求房间信息</para>
        /// <para>gateway_get.room</para>
        /// </summary>
        public const string Get_Room = "gateway_get.room";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>请求情景信息</para>
        /// <para>gateway_get.scene</para>
        /// </summary>
        public const string Get_Scene = "gateway_get.scene";

        /// <summary>
        /// 客⼾端->⽹关
        /// <para>模拟虚拟传感器设备事件触发</para>
        /// <para>gateway_set.event</para>
        /// </summary>
        public const string Set_Event = "gateway_set.event";


    }
}
