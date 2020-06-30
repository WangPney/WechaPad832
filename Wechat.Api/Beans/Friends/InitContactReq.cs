using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    public class InitContactReq
    {
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
