using Wechat.Protocol;

namespace Wechat.Api.Beans.Friends
{
    public class InitContactResp
    {
        /// <summary>
        /// 消息
        /// </summary>
        public InitResponse InitResponse { get; set; }

        /// <summary>
        /// buffer
        /// </summary>
        public string Buffer { get; set; }

        /// <summary>
        /// 同步Key
        /// </summary>
        public int SyncKey { get; set; }
    }
}
