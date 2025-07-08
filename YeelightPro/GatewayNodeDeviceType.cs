using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum GatewayNodeDeviceType
    {
        /// <summary>
        /// 可开关灯具
        /// </summary>
        Light_Switchable = 1,
        /// <summary>
        /// 亮度可调灯具
        /// </summary>
        Light_Brightness = 2,
        /// <summary>
        /// ⾊温可调灯具
        /// </summary>
        Light_Temperature = 3,
        /// <summary>
        /// ⾊彩可调灯具
        /// </summary>
        Light_Color = 4,
        /// <summary>
        /// 窗帘电机
        /// </summary>
        Motor_Curtain = 6,
        /// <summary>
        /// 双路开关控制器/配备两个继电器的开关
        /// </summary>
        Switch_Double = 7,
        /// <summary>
        /// 空调⽹关可控制n路空调
        /// </summary>
        AirCondition_VRF = 10,
        /// <summary>
        /// 多路开关⾯板
        /// </summary>
        Switch_More = 13,
        /// <summary>
        /// 数字调焦⾊温灯
        /// </summary>
        Lamp_DFT = 14,
        /// <summary>
        /// 空调控制器只能控制1路
        /// </summary>
        AirCondition = 15,
        /// <summary>
        /// 控制⾯板/情景面板
        /// </summary>
        ControlPanel = 128,
        /// <summary>
        /// ⼈体/⼈在传感器
        /// </summary>
        Sensor_Peson = 129,
        /// <summary>
        /// 门磁
        /// </summary>
        Sensor_Door = 130,
        /// <summary>
        /// 旋钮
        /// </summary>
        Knob = 132,
        /// <summary>
        /// ⼈体光感传感器
        /// </summary>
        Sensor_HumanLight = 134,
        /// <summary>
        /// 亮度传感器
        /// </summary>
        Sensor_Brightness = 135,
        /// <summary>
        /// 温湿度传感器
        /// </summary>
        Sensor_Humiture = 136,

        /// <summary>
        /// 迈瑞传感器
        /// </summary>
        Sensor_Merrytek=138,
        /// <summary>
        /// 浴霸加热器
        /// </summary>
        BathHeater = 2049,
        /// <summary>
        /// TOF传感器
        /// </summary>
        Sensor_TOF = 2052
    }
}
