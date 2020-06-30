using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    /// <summary>
    /// 添加微信好友
    /// </summary>
    public class AddFriendReq
    {
        /// <summary>
        /// 添加微信好友用户V1数据
        /// </summary>
        [Required]
        public string UserNameV1 { get; set; }

        /// <summary>
        /// 添加微信好友用户的票证数据
        /// </summary>
        [Required]
        public string AntispamTicket { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 来源 1来源QQ2来源邮箱3来源微信号14群聊15手机号18附近的人25漂流瓶29摇一摇30二维码13来源通讯录
        /// </summary>
        [Required]
        public int Origin { get; set; }
    }
}
