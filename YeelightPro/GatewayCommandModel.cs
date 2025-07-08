using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 命令模板
    /// </summary>
    public class GatewayCommandModel
    {
        /// <summary>
        /// 需控制的设备节点ID
        /// <para>64位的⽆符号数值类型的10进制表⽰</para>
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// 节点类型
        /// <para>默认值 MeshSubdevice</para>
        /// </summary>
        [JsonPropertyName("nt")]
        public GatewayNodeType NodeType { get; set; } = GatewayNodeType.MeshSubdevice;

        /// <summary>
        /// 期待完成操作的渐变时间（毫秒）
        /// <para>0~60*60*1000 (毫秒)</para>
        /// <para>默认2000- (毫秒)</para>
        /// </summary>
        public int Duration { get; set; } = 2000;
        /// <summary>
        /// 期待开始操作之前的延迟时间（毫秒）
        /// <para>0~60*60*1000 (毫秒)</para>
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// 期待开灯之后延迟关灯的时间 （毫秒）
        /// <para>0~60*60*1000 (毫秒)</para>
        /// </summary>
        public int DelayOff { get; set; }
        /// <summary>
        /// 期待设置的属性和⽬标值
        /// </summary>
        public Dictionary<string, object>? Set { get; set; }
        /// <summary>
        /// 期待执⾏取反操作的属性列表
        /// </summary>
        public string[]? Toggle { get; set; }
        /// <summary>
        /// 期待调整的属性，格式为字符串形式的带符号分数，分⺟代表（由客⼾端隐式地）预设档位数，带符号分⼦代表向上或向下调整的档数
        /// </summary>
        public Dictionary<string, string>? Adjust { get; set; }
        /// <summary>
        /// 行为动作
        /// </summary>
        public S21GatewayCommandActionModel? Action { get; set; }

    }



    /// <summary>
    /// 行为模型
    /// </summary>
    public class S21GatewayCommandActionModel
    {
        /// <summary>
        /// 指⽰灯具闪烁提醒（blink）
        /// </summary>
        public S21GatewayCommandActionBlinkModel? Blink { get; set; }
        /// <summary>
        /// 调整窗帘电机动作（motorAdjust）
        /// </summary>
        public S21GatewayCommandActionMotorAdjustModel? MotorAdjust { get; set; }
        /// <summary>
        /// 取消延时关闭
        /// </summary>
        public S21GatewayCommandActionDelayCancelModel? DelayCancel { get; set; }
    }

    /// <summary>
    /// 指⽰灯具闪烁提醒（blink）
    /// </summary>
    public class S21GatewayCommandActionBlinkModel
    {
        /// <summary>
        /// 缓慢闪
        /// </summary>
        public const string Smooth = "smooth";
        /// <summary>
        ///慢闪
        /// </summary>
        public const string Notify = "notify";
        /// <summary>
        /// 快闪
        /// </summary>
        public const string Urgent = "urgent";

        /// <summary>
        /// 闪烁次数
        /// </summary>
        public int Repeat { get; set; }

        /// <summary>
        /// 闪烁类型
        /// 缓慢闪-smooth；慢闪-notify；快闪-urgent
        /// </summary>
        public string Type { get; set; } = null!;
    }
    /// <summary>
    /// 调整窗帘电机动作（motorAdjust）
    /// </summary>
    public class S21GatewayCommandActionMotorAdjustModel
    {
        /// <summary>
        /// 暂停
        /// </summary>
        public const string Pause = "pause";
        /// <summary>
        /// 改变⾏进⽅向
        /// </summary>
        public const string Toggle = "toggle";
        /// <summary>
        /// 继续上次⾏进⽅向
        /// </summary>
        public const string Continue = "continue";
        /// <summary>
        /// 在“⾏进/暂停/切换⽅向继续⾏进/暂停”中进⾏切换，⼀般⽤于单键控制窗帘
        /// </summary>
        public const string Auto = "auto";
        /// <summary>
        /// 如果正在执⾏打开操作，暂停；否则执⾏打开操作
        /// </summary>
        public const string OpenOrPause = "openOrPause";
        /// <summary>
        /// 如果正在执⾏关闭操作，暂；否则执⾏关闭操作
        /// </summary>
        public const string CloseOrPause = "closeOrPause";

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = null!;
    }
    /// <summary>
    /// 取消空调延时操作
    /// </summary>
    public class S21GatewayCommandActionDelayCancelModel
    {
        /// <summary>
        /// 取消延时关闭 固定值
        /// Off
        /// </summary>
        public string Type => "off";
        /// <summary>
        /// 固定值
        /// </summary>
        public int Addr => 1;
    }
}
