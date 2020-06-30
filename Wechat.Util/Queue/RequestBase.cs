using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public class RequestBase
    {
        public virtual string MqId { get; set; }
        /// <summary>
        /// 微信Id
        /// </summary>

        public virtual string WxId { get; set; }


    }
}
