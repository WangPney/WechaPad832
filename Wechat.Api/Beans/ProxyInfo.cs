using Newtonsoft.Json;

namespace Wechat.Api.Beans
{
    public class ProxyInfo
    {
        /// <summary>
        /// 代理Ip
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }
        /// <summary>
        /// 代理用户名
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// 代理密码
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
