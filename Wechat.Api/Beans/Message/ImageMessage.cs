using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Message
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage
    {
        /// <summary>
        /// 接收的微信ID
        /// </summary>
        [Required]
        public IList<string> ToWxIds { get; set; }

        /// <summary>
        /// 图片Base64
        /// </summary>
        [Required]
        public string Base64 { get; set; }
    }
}
