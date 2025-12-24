using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 灯具类设备
    /// </summary>
    public class LightModel : ModelBase
    {
        /// <summary>
        /// 开关
        /// </summary>
        [JsonPropertyName("p")]
        public bool? Power { get; set; }
        /// <summary>
        /// 颜⾊
        /// <para>例如：红⾊的⼗进制数为16711680，对应的16进制是0xFF0000（R是FF，G是00，B是00）</para>
        /// </summary>
        [JsonPropertyName("c")]
        public long? Color { get; set; }
        /// <summary>
        /// 色温
        /// </summary>
        [JsonPropertyName("ct")]
        public int? ColorTemperature { get; set; }
        /// <summary>
        /// 亮度
        /// </summary>
        [JsonPropertyName("l")]
        public int? Brightness { get; set; }
        /// <summary>
        /// 光束角度
        /// </summary>
        [JsonPropertyName("angle")]
        public int? Angle { get; set; }
    }

    /// <summary>
    /// 灯设置
    /// </summary>
    public class LightSet : SetBase
    {

   

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public LightSet SetPower(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.Light_Power, isOn);
            return this;
        }


        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="value"> 值范围：0~255</param>
        /// <returns></returns>
        public LightSet SetAngle(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Light_Angle, value);
            return this;
        }

        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="value"> 值范围：0~100</param>
        /// <returns></returns>
        public LightSet SetBrightness(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Light_Brightness, value);
            return this;
        }


        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="value"> 值范围：2700~6500(晴空：1600~8000)</param>
        /// <returns></returns>
        public LightSet SetColorTemperature(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Light_ColorTemperature, value);
            return this;
        }


        /// <summary>
        /// 设置灯开关
        /// </summary>
        /// <param name="value"> 值范围：值范围：0~16777215  <para>例如：红⾊的⼗进制数为16711680，对应的16进制是0xFF0000（R是FF，G是00，B是00）</para></param>
        /// <returns></returns>
        public LightSet SetColor(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Light_Color, value);
            return this;
        }
    }

}
