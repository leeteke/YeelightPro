using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YeelightPro.Models
{
    /// <summary>
    /// 窗帘电机/梦幻帘电机
    /// </summary>
    public class CurtainModel:ModelBase
    {
        /// <summary>
        /// 开关
        /// </summary>
        [JsonPropertyName("cp")]
        public int? CurrentPosition { get; set; }
        /// <summary>
        /// 期望窗帘⽬标开合度
        /// </summary>
        [JsonPropertyName("tp")]
        public int? TargetPosition { get; set; }
        /// <summary>
        /// 行程是否已校准
        /// </summary>
        [JsonPropertyName("rs")]
        public int? RouteSetted { get; set; }
        /// <summary>
        /// 梦幻帘当前的旋转角度
        /// </summary>
        [JsonPropertyName("cra")]
        public int? CurrentAngle { get; set; }
        /// <summary>
        /// 梦幻帘目标旋转角度
        /// </summary>
        [JsonPropertyName("tra")]
        public int? TargetAngle { get; set; }
        /// <summary>
        /// 梦幻帘行程是否已校准
        /// </summary>
        [JsonPropertyName("trs")]
        public int? TitleRouteSetted { get; set; }
    }

    /// <summary>
    /// 窗帘电机/梦幻帘电机 设置
    /// </summary>
    public class CurtainSet : SetBase
    {


        /// <summary>
        /// 期望窗帘目标开合度
        /// </summary>
        /// <param name="value">值范围：0~100</param>
        /// <returns></returns>
        public CurtainSet SetPosition(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Curtain_TargetPosition,value);
            return this;
        }

        /// <summary>
        /// 梦幻帘目标旋转角度
        /// </summary>
        /// <param name="value">值范围：0~180</param>
        /// <returns></returns>
        public CurtainSet SetAngle(int value)
        {
            _result.Add(GatewayNodeDeviceProperties.Curtain_TargetAngle, value);
            return this;
        }
    
    }
}
