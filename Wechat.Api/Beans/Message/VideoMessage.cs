using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Message
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoMessage
    {
        /// <summary>
        /// 发送的微信ID
        /// </summary>
        [Required]
        public IList<string> ToWxIds { get; set; }

        /// <summary>
        /// 播放时长 秒
        /// </summary>
        [Required]
        public int PlayLength { get; set; }

        /// <summary>
        /// 视频base64
        /// </summary>
        [Required]
        public string Base64 { get; set; }


        /// <summary>
        /// 封面base64
        /// </summary>
        [Required]
        public string ImageBase64 { get; set; }
    }
}
