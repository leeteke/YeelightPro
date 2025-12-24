using System;
using System.Collections.Generic;
using System.Text;

namespace YeelightPro.Models
{
    /// <summary>
    ///由于特殊性暂时无法使用该模型
    /// </summary>
    [Obsolete("暂时无法使用该模型")]
    public class AirConditionModel : ModelBase
    {
    }

    /// <summary>
    /// 空调VRF设置
    /// </summary>
    public class AirConditionSet : SetBase
    {



        /// <summary>
        /// 设置电源开关
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public AirConditionSet SetPower(int index, bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_Power), isOn);
            return this;
        }

        /// <summary>
        /// 设置 空调遥控器使能
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public AirConditionSet SetRemoteController(int index, bool isOn)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_RemoteController), isOn);
            return this;
        }


        /// <summary>
        /// 设置 空调遥控器使能
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="value"><para>制冷-1</para><para>送风-4</para><para>制热-8</para></param>
        /// <returns></returns>
        public AirConditionSet SetMode(int index, int value)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_Mode), value);
            return this;
        }

        /// <summary>
        /// 设置 空调目标温度
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="value">16~32</param>
        /// <returns></returns>
        public AirConditionSet SetTemperature(int index, int value)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_TargetTemperature), value);
            return this;
        }

        /// <summary>
        /// 设置 空调风速
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="value">1~5</param>
        /// <returns></returns>
        public AirConditionSet SetFanSpeed(int index, int value)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_FanSpeed), value);
            return this;
        }


        /// <summary>
        /// 设置 空调延时开关剩余时间
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="value">1~43200000</param>
        /// <returns></returns>
        public AirConditionSet SetDeley(int index, int value)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_Deley), value);
            return this;
        }

        /// <summary>
        /// 设置 空调导风板信息
        /// </summary>
        /// <param name="index">第几通道</param>
        /// <param name="value">0~255</param>
        /// <returns></returns>
        public AirConditionSet SetDeflector(int index, int value)
        {
            _result.Add(GatewayNodeDeviceProperties.AirConditionVRF(index, GatewayNodeDeviceProperties.AirCondition_Deflector), value);
            return this;
        }
    }


}
