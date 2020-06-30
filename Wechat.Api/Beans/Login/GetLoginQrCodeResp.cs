using Newtonsoft.Json;

namespace Wechat.Api.Beans.Login
{
    public class GetLoginQrCodeResp
    {
        [JsonProperty("qrCodeId")]
        public string QrCodeId { get; set; }
        [JsonProperty("qrCodeBase64")]
        public string QrCodeBase64 { get; set; }
        [JsonProperty("expiredTime")]
        public uint ExpiredTime { get; set; }
    }
}
