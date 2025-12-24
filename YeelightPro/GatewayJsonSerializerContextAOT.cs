using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using YeelightPro.Models;

namespace YeelightPro
{
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonSerializable(typeof(GatewayTopologyModel[]))]
    [JsonSerializable(typeof(GatewayTopologyModel))]
    [JsonSerializable(typeof(GatewayCommandModel))]
    [JsonSerializable(typeof(GatewayCommandModel[]))]
    [JsonSerializable(typeof(List<GatewayCommandModel>))]
    [JsonSerializable(typeof(GatewayCommandActionModel))]
    [JsonSerializable(typeof(GatewayCommandActionBlinkModel))]
    [JsonSerializable(typeof(GatewayCommandActionDelayCancelModel))]
    [JsonSerializable(typeof(GatewayCommandActionMotorAdjustModel))]
    [JsonSerializable(typeof(BathHeaterModel))]
    [JsonSerializable(typeof(CurtainModel))]
    [JsonSerializable(typeof(KnobModel))]
    [JsonSerializable(typeof(LightModel))]
    [JsonSerializable(typeof(LightModel))]
    [JsonSerializable(typeof(ModelBase))]
    [JsonSerializable(typeof(SceneModel))]
    [JsonSerializable(typeof(SearsonDoorModel))]
    [JsonSerializable(typeof(SensorHumanLightModel))]
    [JsonSerializable(typeof(SensorHumitureModel))]
    [JsonSerializable(typeof(SensorMerrytekModel))]
    [JsonSerializable(typeof(SensorPersonModel))]
    [JsonSerializable(typeof(SwitchDoubleModel))]
    [JsonSerializable(typeof(SwitchMoreModel))]
    public partial class GatewayJsonSerializerContextAOT : JsonSerializerContext
    {
    }
}
