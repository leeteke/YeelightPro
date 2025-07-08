using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeelightPro
{/// <summary>
 /// 关于S21网关的信息
 /// </summary>
 /// <param name="Pid">类型，目前1代表网关，2代表全面屏</param>
 /// <param name="Mac">设备的Mac地址</param>
 /// <param name="Did">UUID</param>
 /// <param name="Ip">设备的IP</param>
    public record GatewayInfo(int Pid, string Mac, int Did, string Ip);
}
