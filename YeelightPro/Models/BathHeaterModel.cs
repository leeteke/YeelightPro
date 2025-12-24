using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 浴霸加热器
    /// </summary>
    public class BathHeaterModel: ModelBase
    {
        /// <summary>
        /// 浴霸加热器开关⼈移动
        /// </summary>
        [JsonPropertyName("p")]
        public bool? Power { get; set; }

        /// <summary>
        /// 浴霸加热模式
        /// <para>干燥-1</para>
        /// <para>除雾-2</para>
        /// <para>快速除雾-3</para>
        /// <para>急速加热-4</para>
        /// <para>非上述四种模式-5</para>
        /// </summary>
        [JsonPropertyName("bhm")]
        public int? Mode { get; set; }


        /// <summary>
        /// 浴霸延时关闭 
        /// <para>单位：分</para>
        /// </summary>
        [JsonPropertyName("do")]
        public int? DelayOff { get; set; }

        /// <summary>
        /// 浴霸换气挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// </summary>
        [JsonPropertyName("ve")]
        public int? Ventilation { get; set; }

        /// <summary>
        /// 浴霸吹风挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// </summary>
        [JsonPropertyName("fa")]
        public int? Fan { get; set; }

        /// <summary>
        /// 浴霸加热挡位
        /// <para>关闭-0</para>
        /// <para>抵挡-1</para>
        /// <para>中档-2</para>
        /// <para>高档-3</para>
        /// </summary>
        [JsonPropertyName("he")]
        public int? Heat { get; set; }

        /// <summary>
        /// 当前室内温度⼈移动
        /// </summary>
        [JsonPropertyName("t")]
        public int? Temperature { get; set; }
        /// <summary>
        /// 目标室内温度
        /// </summary>
        [JsonPropertyName("tgt")]
        public int? TargetTemperature { get; set; }
    }


    /// <summary>
    /// 设置 浴霸加热器
    /// </summary>
    public class BathHeaterSet : SetBase
    {
        /// <summary>
        /// 开关
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public BathHeaterSet SetPower(bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_Power, isOn);
            return this;
        }
        /// <summary>
        /// 浴霸加热模式
        /// </summary>
        /// <param name="value"><para>干燥-1</para><para>除雾-2</para><para>快速除雾-3</para><para>急速加热-4</para></param>
        /// <returns></returns>
        public BathHeaterSet SetMode(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_Mode, value);
            return this;
        }
        /// <summary>
        /// 浴霸延时关闭
        /// </summary>
        /// <param name="value">1~120分钟</param>
        /// <returns></returns>
        public BathHeaterSet SetDelayOff(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_DelayOff, value);
            return this;
        }

        /// <summary>
        /// 浴霸换气挡位
        /// </summary>
        /// <param name="value"><para>关闭-0</para><para>抵挡-1</para><para>中档-2</para> <para>高档-3</para></param>
        /// <returns></returns>
        public BathHeaterSet SetVentilation(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_Ventilation, value);
            return this;
        }


        /// <summary>
        /// 浴霸吹风挡位
        /// </summary>
        /// <param name="value"><para>关闭-0</para><para>抵挡-1</para><para>中档-2</para> <para>高档-3</para></param>
        /// <returns></returns>
        public BathHeaterSet SetFan(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_Fan, value);
            return this;
        }

        /// <summary>
        /// 浴霸加热挡位
        /// </summary>
        /// <param name="value"><para>关闭-0</para><para>抵挡-1</para><para>中档-2</para> <para>高档-3</para></param>
        /// <returns></returns>
        public BathHeaterSet SetHeat(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_Heat, value);
            return this;
        }

        /// <summary>
        /// 目标室内温度
        /// </summary>
        /// <param name="value">0~50</param>
        /// <returns></returns>
        public BathHeaterSet SetTemperature(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.BathHeater_TargetTemperature, value);
            return this;
        }
    }

}
