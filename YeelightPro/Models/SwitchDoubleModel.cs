using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 继电器-双路控制
    /// </summary>
    public class SwitchDoubleModel : ModelBase
    { /// <summary>
      /// 双路继电器全控
      /// </summary>
        [JsonPropertyName("p")]
        public bool? All { get; set; }
        /// <summary>
        /// 第⼀路继电器开关
        /// </summary>
        [JsonPropertyName("1-p")]
        public bool? P_1 { get; set; }
        /// <summary>
        /// 第二路继电器开关
        /// </summary>
        [JsonPropertyName("2-p")]
        public bool? P_2 { get; set; }
    }

    /// <summary>
    /// 设置 继电器-双路控制
    /// </summary>
    public class SwitchDoubleSet : SetBase
    {

      

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchDoubleSet SetAll(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchDouble_All, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchDoubleSet Set1P(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchDouble_1P, isOn);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public SwitchDoubleSet Set2P(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.SwitchDouble_2P, isOn);
            return this;
        }
    }
}
