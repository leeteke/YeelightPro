using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 结点设备属性
    /// </summary>
    public class GatewayNodeDeviceProperties
    {


        #region 灯


        /// <summary>
        /// 开关
        /// <para>true：开灯</para>
        /// <para>false：关灯</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Light_Power = "p";
        /// <summary>
        /// 颜⾊
        /// <para>例如：红⾊的⼗进制数为16711680，对应的16进制是0xFF0000（R是FF，G是00，B是00）</para>
        /// <para>值范围：0~16777215</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Light_Color = "c";

        /// <summary>
        /// 色温
        /// <para>2700~6500</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Light_ColorTemperature = "ct";

        /// <summary>
        /// 亮度
        /// <para>值范围：1~100</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Light_Brightness = "l";

        /// <summary>
        /// 光束角度
        /// <para>值范围：0~255</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Light_Angle = "angle";

        #endregion

        #region 窗帘电机/梦幻帘电机

        /// <summary>
        /// 窗帘当前开合度
        /// <para>值范围：0~100</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Curtain_CurrentPosition = "cp";

        /// <summary>
        /// 期望窗帘⽬标开合度
        /// <para>值范围：0~100</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string Curtain_TargetPosition = "tp";

        /// <summary>
        /// 行程是否已校准
        /// <para>未校准-0</para>
        /// <para>已校准-1</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Curtain_RouteSetted = "rs";

        /// <summary>
        /// 梦幻帘当前的旋转角度
        /// <para>值范围：0~180</para>
        /// <para>操作：读、上报</para>
        /// <para>仅梦幻帘</para>
        /// </summary>
        public const string Curtain_CurrentAngle = "cra";

        /// <summary>
        /// 梦幻帘目标旋转角度
        /// <para>值范围：0~180</para>
        /// <para>操作：读、上报、写</para>
        /// <para>仅梦幻帘</para>
        /// </summary>
        public const string Curtain_TargetAngle = "tra";

        /// <summary>
        /// 梦幻帘行程是否已校准
        /// <para>未校准-0</para>
        /// <para>已校准-1</para>
        /// <para>操作：读、上报</para>
        /// <para>仅梦幻帘</para>
        /// </summary>
        public const string Curtain_TitleRouteSetted = "tra";



        #endregion


        #region 继电器-双路控制
        /// <summary>
        /// 双路继电器全控
        /// <para>true: 期望双路继电器开关闭合</para>
        /// <para>false：期望双路继电器开关打开</para>
        /// <para>操作：写</para>
        /// </summary>
        public const string SwitchDouble_All = "p";
        /// <summary>
        /// 第⼀路继电器开关
        /// <para>true: 期望第⼀路继电器开关闭合</para>
        /// <para>false：期望第⼀路继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchDouble_1P = "1-p";
        /// <summary>
        /// 第二路继电器开关
        /// <para>true: 期望第二路继电器开关闭合</para>
        /// <para>false：期望第二路继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchDouble_2P = "2-p";
        #endregion

        #region 继电器-多路开关面板
        /// <summary>
        /// 第一个按键开关
        /// <para>true: 期望第⼀个按键继电器开关闭合</para>
        /// <para>false：期望第⼀个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_1SP = "1-sp";

        /// <summary>
        /// 第二个按键开关
        /// <para>true: 期望第二个按键继电器开关闭合</para>
        /// <para>false：期望第二个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_2SP = "2-sp";

        /// <summary>
        /// 第三个按键开关
        /// <para>true: 期望第三个按键继电器开关闭合</para>
        /// <para>false：期望第三个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_3SP = "3-sp";

        /// <summary>
        /// 第四个按键开关
        /// <para>true: 期望第四个按键继电器开关闭合</para>
        /// <para>false：期望第四个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_4SP = "4-sp";

        /// <summary>
        /// 第五个按键开关
        /// <para>true: 期望第五个按键继电器开关闭合</para>
        /// <para>false：期望第五个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_5SP = "5-sp";

        /// <summary>
        /// 第六个按键开关
        /// <para>true: 期望第六个按键继电器开关闭合</para>
        /// <para>false：期望第六个按键继电器开关打开</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string SwitchMore_6SP = "6-sp";



        #endregion


        #region  空调控制器（VRF⽹关、⼀对⼀控制⽹关、⽔机控制）

        /// <summary>
        /// 空调开关
        /// <para>true: 开启空调</para>
        /// <para>false:关闭空调</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_Power = "acp";

        /// <summary>
        /// 空调模式
        /// <para>制冷-1</para>
        /// <para>送风-4</para>
        /// <para>制热-8</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_Mode = "acm";

        /// <summary>
        /// 空调当前温度
        /// <para>值范围：16~32 </para>
        /// <para>操作：读、上报</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_CurrentTemperature = "acct";

        /// <summary>
        /// 空调⽬标温度
        /// <para>值范围：16~32</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_TargetTemperature = "actt";

        /// <summary>
        /// 空调风速
        /// <para>值范围1~5</para>
        /// <para>步长：1</para>
        /// <para>⼀般空调温控器有三挡可调：⾼（1），中（2），低（4）</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_FanSpeed = "acf";

        /// <summary>
        /// 空调是否在线
        /// <para>true：在线</para>
        /// <para>false：不在线</para>
        /// <para>操作：读、上报</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_Online = "aco";

        /// <summary>
        /// 空调延时开关剩余时间，单位毫秒
        /// <para>值范围：1~43200000</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_Deley = "acd";

        /// <summary>
        /// 空调导⻛板信息
        /// <para>值范围：0~255</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_Deflector = "acdfltr";

        /// <summary>
        /// 空调遥控器使能
        /// <para>true：使能空调遥控器</para>
        /// <para>false：禁能空调遥控器</para>
        /// <para>操作：读、上报、写</para>
        /// <para>需要通过AirConditionVRF方法生成属性名！或者这自拼，格式为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        public const string AirCondition_RemoteController = "acrc";

        /// <summary>
        /// VRF控制属性的生成
        /// <para>除了基础属性外，其他属性值格式均为‘index-xxx’,index： vrf管理的第几路设备。</para>
        /// </summary>
        /// <param name="index">第几路设备</param>
        /// <param name="airConditionName">某个属性名</param>
        /// <returns></returns>
        public static string AirConditionVRF(int index, string airConditionName) => $"{index}-{airConditionName}";


        #endregion


        #region 情景面板

        /// <summary>
        /// 情景面板按键事件params属性-按键的ID
        /// <para>值范围1~6</para>
        /// <para>操作：读</para>
        /// </summary>
        public const string Scene_Key = "key";
        /// <summary>
        /// 情景面板按键事件params属性-按键的次数
        /// <para>操作：读</para>
        /// </summary>
        public const string Scene_Count = "count";
        #endregion


        #region ⼈体光感传感器

        /// <summary>
        /// 当前是否有⼈移动
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Sensor_HumanLight_MotionDetected = "mv";

        /// <summary>
        /// 光亮等级
        /// <para>1档：小于23lux </para>
        /// <para>2档：23~50lux</para>
        /// <para>3档：50~150lux</para>
        /// <para>4档：150~250lux</para>
        /// <para>5档：250~350lux</para>
        /// <para>6档：350~450lux</para>
        /// <para>7档：450~600lux</para>
        /// <para>8档：＞600lux</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Sensor_HumanLight_Level = "level";
        #endregion

        #region ⼈体传感器/⼈在传感器

        /// <summary>
        /// 当前是否有⼈移动
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Sensor_Peson_MotionDetected = "mv";
        #endregion

        #region 门磁
        /// <summary>
        /// 门磁
        /// <para>⻔窗已打开-0</para>
        /// <para>⻔窗已关闭-1</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Sensor_Door_Close = "dc";

        /// <summary>
        /// 门磁 强拆告警
        /// <para>门磁被安上-0</para>
        /// <para>门磁被拆下-1</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string Sensor_Door_Alarm = "alm";

        #endregion

        #region  旋钮
        /// <summary>
        /// 旋钮正常旋转事件params属性-旋钮正常旋转的刻度
        /// <para>反向旋转刻度: -128~0</para>
        /// <para>正向向旋转刻度：127~0</para>
        /// </summary>
        public const string Knob_FreeSpin = "free_spin";

        /// <summary>
        /// 旋钮按压旋转事件params属性-旋钮按压旋转的刻度
        /// <para>反向旋转刻度: -128~0</para>
        /// <para>正向向旋转刻度：127~0</para>
        /// </summary>
        public const string Knob_HoldSpin = "hold_spin";
        #endregion


        #region 温湿度传感器
        /// <summary>
        /// 湿度值
        /// <para>值范围：0~100</para>
        /// <para>操作：读</para>
        /// </summary>
        public const string Sensor_Humiture_Humidity = "h";

        /// <summary>
        /// 温度值
        /// <para>值范围: -1000~5000 摄氏度放大100倍（真正的范围是 -10.00~50.00）</para>
        /// <para>操作：读</para>
        /// </summary>
        public const string Sensor_Humiture_Temperature = "t";

        #endregion


        #region 迈睿人体传感器
        /// <summary>
        /// 当前是否有人移动 （motion detected缩写）
        /// <para>有人移动-1</para>
        /// <para>无人移动-0</para>
        /// <para>迈睿人体传感器</para>
        /// <para>操作：读</para>
        /// </summary>
        public const string Sensor_Merrytek_MotionDetected = "mv";

        /// <summary>
        /// 光照度值(lux)
        /// <para> 0~65536 </para>
        /// <para>迈睿人体传感器</para>
        /// <para>操作：读</para>
        /// </summary>
        public const string Sensor_Merrytek_Luminance = "luminance";
        #endregion

        #region 浴霸加热器

        /// <summary>
        /// 浴霸加热器开关
        /// <para>true: 开浴霸</para>
        /// <para>false: 关浴霸</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_Power = "p";

        /// <summary>
        /// 浴霸加热模式
        /// <para>干燥-1</para>
        /// <para>除雾-2</para>
        /// <para>快速除雾-3</para>
        /// <para>急速加热-4</para>
        /// <para>非上述四种模式-5</para>
        /// <para>操作：读、上报、写（5只读不写）</para>
        /// </summary>
        public const string BathHeater_Mode = "bhm";

        /// <summary>
        /// 浴霸延时关闭
        /// <para>单位：分</para>
        /// <para>值范围：1~120</para>
        /// <para>步长：1</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_DelayOff = "do";

        /// <summary>
        /// 浴霸换气挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_Ventilation = "ve";

        /// <summary>
        /// 浴霸吹风挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_Fan = "fa";

        /// <summary>
        /// 浴霸加热挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_Heat = "he";

        /// <summary>
        /// 当前室内温度
        /// <para>值范围：-50~50</para>
        /// <para>操作：读、上报</para>
        /// </summary>
        public const string BathHeater_Temperature = "t";

        /// <summary>
        /// 目标室内温度
        /// <para>值范围：0~50</para>
        /// <para>操作：读、上报、写</para>
        /// </summary>
        public const string BathHeater_TargetTemperature = "tgt";
        #endregion
    }
}
