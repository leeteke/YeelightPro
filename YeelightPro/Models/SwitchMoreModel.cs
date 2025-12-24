using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 继电器-多路开关面板
    /// </summary>
    public class SwitchMoreModel : ModelBase
    {
        /// <summary>
        /// 第一个按键开关
        /// </summary>
        [JsonPropertyName("1-sp")]
        public bool? SP_1 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("2-sp")]
        public bool? SP_2 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("3-sp")]
        public bool? SP_3 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("4-sp")]
        public bool? SP_4 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("5-sp")]
        public bool? SP_5 { get; set; }
        /// <summary>
        /// 第二个按键开关
        /// </summary>
        [JsonPropertyName("6-sp")]
        public bool? SP_6 { get; set; }
    }

    /// <summary>
    /// 设置 继电器-多路开关面板
    /// </summary>
    public class SwitchMoreSet : SetBase
    {

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set1SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_1SP, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set2SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_2SP, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set3SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_3SP, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set4SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_4SP, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set5SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_5SP, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchMoreSet Set6SP(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchMore_6SP, isOn);
            return this;
        }




    }
}
