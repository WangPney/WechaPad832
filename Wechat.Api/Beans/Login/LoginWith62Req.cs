using Newtonsoft.Json;

namespace Wechat.Api.Beans.Login
{
    public class LoginWith62Req
    {
        /// <summary>
        /// 微信用户名
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// 微信密码
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
        /// <summary>
        /// 62数据
        /// </summary>
        [JsonProperty("data62")]
        public string Data62 { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("proxy")]
        public ProxyInfo Proxy { get; set; }
    }
}
