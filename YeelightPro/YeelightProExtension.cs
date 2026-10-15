using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YeelightPro.Models;

namespace YeelightPro
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class YeelightProExtension
    {

        /// <summary>
        /// 参数转换器
        /// </summary>
        /// <typeparam name="T">根据设备类型从 Models 里选择相应模型</typeparam>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static T? ParmasConverter<T>(this JsonObject parms) where T : ModelBase
        {
            return parms.Deserialize(typeof(T), GatewayJsonSerializerContextAOT.Default) as T;
        }

        /// <summary>
        /// 参数转换器
        /// </summary>
        /// <typeparam name="T">根据设备类型从 Models 里选择相应模型</typeparam>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static T? ParmasConverter<T>(this JsonNode parms) where T : ModelBase
        {
            return parms.Deserialize(typeof(T), GatewayJsonSerializerContextAOT.Default) as T;
        }

    }
}
