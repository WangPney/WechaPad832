using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Message
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TxtMessage
    {
        /// <summary>
        /// 发送的微信ID
        /// </summary>
        [Required]
        public IList<string> ToWxIds { get; set; }

        /// <summary>
        /// 发送内容
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
