using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    public class ListContactReq
    {
        /// <summary>
        /// 好友分页
        /// </summary>
        public int CurrentWxcontactSeq { get; set; }

        /// <summary>
        /// 群分页
        /// </summary>
        public int CurrentChatRoomContactSeq { get; set; }
    }
}
