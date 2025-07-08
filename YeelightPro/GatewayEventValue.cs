using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro
{

    /// <summary>
    /// 事件值
    /// </summary>
    public class GatewayEventValue
    {
        /// <summary>
        /// 有⼈移动
        /// </summary>
        public const string Motion_True = "motion.true";
        /// <summary>
        /// ⽆⼈移动
        /// <para>⽆⼈移动是指检测到有⼈移动后，⼀段时间内连续检测不到移动则触发⼀次</para>
        /// </summary>
        public const string Motion_False = "motion.false";
        /// <summary>
        /// ⻔打开
        /// </summary>
        public const string Contact_Open = "contact.open";
        /// <summary>
        /// ⻔关闭
        /// </summary>
        public const string Contact_Close = "contact.close";
        /// <summary>
        /// ⻔磁被拆下   
        /// </summary>
        public const string Contact_Alarm = "contact.alarm";
        /// <summary>
        /// ⻔磁被安装上
        /// </summary>
        public const string Contact_Normal = "contact.normal";
        /// <summary>
        /// ⾯板被点击
        /// </summary>
        public const string Panel_Click = "panel.click";
        /// <summary>
        /// ⾯板按键被按住
        /// </summary>
        public const string Panel_Hold = "panel.hold";
        /// <summary>
        /// ⾯板按键被松开
        /// </summary>
        public const string Panel_Release = "panel.release";
        /// <summary>
        /// 旋钮旋转
        /// </summary>
        public const string Knob_Spin = "knob.spin";

        /// <summary>
        /// 迈睿人体传感器-有人靠近
        /// </summary>
        public const string Approach_True = "approach.true";

        /// <summary>
        /// 迈睿人体传感器-有人远离
        /// </summary>
        public const string Approach_False="approach.false";

        /// <summary>
        /// TOF传感器-有人挥手
        /// </summary>
        public const string Handwave = "handwave";


    }
}
