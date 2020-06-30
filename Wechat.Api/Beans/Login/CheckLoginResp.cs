using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Login
{
    /// <summary>
    /// 检查登陆
    /// </summary>
    public class CheckLoginResp
    {
        /// <summary>
        /// UuId
        /// </summary>
        public string Uuid { get; set; }
        /// <summary>
        /// 微信Id
        /// </summary>
        public string WxId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 状态 -1失效 0:未扫码 1：扫码 2：登陆
        /// </summary>
        public int State { get; set; }


        /// <summary>
        /// 设备Id
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// 头像Url
        /// </summary>
        public string HeadUrl { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
    }
}
