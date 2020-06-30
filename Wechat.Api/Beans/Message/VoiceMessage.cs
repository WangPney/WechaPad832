using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Message
{
    /// <summary>
    /// 声音消息
    /// </summary>
    public class VoiceMessage
    {
        /// <summary>
        /// 发送的微信ID
        /// </summary>
        [Required]
        public IList<string> ToWxIds { get; set; }
        /// <summary>
        /// 声音秒数
        /// </summary>
        [Required]
        public int VoiceSecond { get; set; }

        /// <summary>
        /// Base4声音
        /// </summary>
        [Required]
        public string Base64 { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [Required]
        public string FileName { get; set; }
    }
}
