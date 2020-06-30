using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    public class ListContactResp
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public IList<string> Contacts { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public int CurrentWxcontactSeq { get; set; }

        public int CurrentChatRoomContactSeq { get; set; }


    }
}
