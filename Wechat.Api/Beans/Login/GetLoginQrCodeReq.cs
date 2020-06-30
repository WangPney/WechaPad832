using Newtonsoft.Json;

namespace Wechat.Api.Beans.Login
{
    public class GetLoginQrCodeReq
    {
        /// <summary>
        /// 代理
        /// </summary>
        [JsonProperty("proxy")]
        public ProxyInfo Proxy { get; set; }
        /// <summary>
        /// 设备Id
        /// </summary>
        [JsonProperty("deviceId")] 
        public string DeviceId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [JsonProperty("deviceName")] 
        public string DeviceName { get; set; }
    }
}
