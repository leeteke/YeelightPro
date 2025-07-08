using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using YeelightPro.Models;

namespace YeelightPro
{
    /// <summary>
    /// 属性更新事件参数
    /// </summary>
    public class GatewayPropertiesUpdatedEventArgs : EventArgs
    {

        /// <summary>
        /// 旧属性参数
        /// </summary>
        public JsonObject Old { get; }

        /// <summary>
        /// 新属性参数
        /// </summary>
        public JsonObject New { get; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public ulong Id { get; }

        /// <summary>
        /// 属性更新事件参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="old"></param>
        /// <param name="new"></param>
        public GatewayPropertiesUpdatedEventArgs(ulong id, JsonObject old, JsonObject @new)
        {
            Id = id;
            Old = old;
            New = @new;
        }


    }
}
