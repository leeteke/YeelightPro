# YeelightPro 局域网本地控制
[个人根据官方局域网通讯协议协议开发，非官方库]

Yeelight Pro照明控制系统由硬件、云端、用户App组成。硬件包括网关、灯具、传感器、面板、全面屏等组成。网关通过蓝牙MESH协议与其他蓝牙mesh子设备进行通信，通过Wi-Fi或者有线与云端/本地服务器通信。

本库通过 局域网协议（Ver2.4）与 S21/S21增强版 网关进行本地通讯控制以上描述设备，相关可控制设备详见： https://cn.yeelight.com/zh_CN/pro 

（特别说明：非 Yeelight 普通线上产品控制库，也就是连接米家的那些设备，无法使用本库控制。）

## Nuget
[![NUGET](https://img.shields.io/badge/nuget-2.4.0-blue.svg)](https://www.nuget.org/packages/YeelightPro)


    dotnet add package YeelightPro --version 2.4.0

## 基本使用方法

### 初始化
``` csharp
       
        private Gateway _gateway;
        _gateway = new Gateway("192.168.0.0");
        //连接记录
        _gateway.CommunicationRecord += (_, r) =>
        {
            //r:GatewayCommunicationRecordEventArgs
        };
        //连接改变事件
        _gateway.ConnectChanged += async (_, e) =>
        {
            //重连操作
            if (!e.Connected)
            {
                while (true)
                {
                    //等待10S
                    await Task.Delay(10000);
                    try
                    {
                        _gateway.Connect();
                        return;
                    }
                    catch (YeelightPro.GatewayRepeatedConnectException ex)
                    {
                             //重复连接 说明已经连接上了
                             //      return;
                    }
                    catch (Exception ex)
                    {
                        //其他则是连接失败
                    }
                }
            }
        };
        //设备事件触发事件
        _gateway.EventTriggered += Gateway_EventTriggered;
        //设备属性变化事件
        _gateway.PropertiesUpdated += Gateway_PropertiesUpdated;
        //连接
        _gateway.Connect();

```
### 控制设备
``` csharp
//控制逻辑为：生成控制命令->执行控制命令
//控制命令模板为 GatewayCommandModel

//属性举例：构建控制灯具类设备命令
var lightCmd=new GatewayCommandModel()
{
    //节点设备ID 
    Id=id,
    //期待设置的属性和⽬标值
    Set=new()
    {
        //从 GatewayNodeDeviceProperties 选择属性名称，属性注释上表明了 操作包含 ‘写’ 的是属于可控的，并且标标明了相关类型可范围
       { GatewayNodeDeviceProperties.Light_Power, true }, //开灯
       { GatewayNodeDeviceProperties.Light_Brightness, 50} //50%的亮度
    },
    //渐变事件 单位 毫秒
    Duration=2000
};


//行为举例：构建控制床帘类设备命令
var curtainCmd=new GatewayCommandModel()
{
    //节点设备ID 
    Id=id,
    //行为动作
    Action=new GatewayCommandActionModel()
    {
        //调整窗帘电机动作
        MotorAdjust =new GatewayCommandActionMotorAdjustModel()
        {
            //选择 GatewayCommandActionMotorAdjustModel 里面的常量字段
            Type=GatewayCommandActionMotorAdjustModel.Auto
        }
    }
}

//通过命令组进行命令控制执行
(bool executed, string? msg)=await _gateway.CommandAsync([lightCmd,curtainCmd]);

```
### 读取设备属性

```csharp

//设备属性模型为 GatewayNodeDeviceModel
//所有设备属性名称以及定义都放在了 GatewayNodeDeviceProperties
//其中 设备的详细参数为  GatewayNodeDeviceModel.Params，该类型为System.Text.Json.Nodes.JsonObject
//并且  设备属性更新事件  与 设备触发事件 的相关参数 也为 System.Text.Json.Nodes.JsonObject 类型

//模型属性举例： 获取 pid为 198888的 ⾊温可调灯具 GatewayNodeDeviceType.Light_Temperature

 var device= _client.NodeDevices[198888];
//获取灯的亮度
 var brightness= device.Params[GatewayNodeDeviceProperties.Light_Brightness].GetValue<double>();
//获取灯的色温
var brightness= device.Params[GatewayNodeDeviceProperties.Light_ColorTemperature].GetValue<double>();


//在属性更新时间里也同样
private void Gateway_PropertiesUpdated(object? sender, GatewayPropertiesUpdatedEventArgs e)
{
     if(e.Id==198888)
     {
     //获取灯的上一次值
      var brightness= e.Old[GatewayNodeDeviceProperties.Light_Brightness].GetValue<int>();
      //获取灯的新变化值
      var brightness= e.New[GatewayNodeDeviceProperties.Light_Brightness].GetValue<int>();
     }

}


//在此，为了更确切的使用相关数据，本库提供了相关数据模型，可以通过 扩展方法YeelightProExtension.ParmasConverter<T> 直接转换成相应的模型
//模型 在 YeelightPro.Models 下

//举例:
//模型属性举例： 获取 pid为 198888的 ⾊温可调灯具 GatewayNodeDeviceType.Light_Temperature

 var device= _client.NodeDevices[198888];

 var light= device.Params.ParmasConverter<YeelightPro.Models.LightModel>();
//获取灯的亮度
 var brightness= light.Brightness;
//获取灯的色温
var brightness= light.ColorTemperature

//其他依次类推


```