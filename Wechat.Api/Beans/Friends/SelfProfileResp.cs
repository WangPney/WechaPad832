using MMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    public class SelfProfileResp
    {
        public MM.ModUserInfo UserInfo { get; set; }

        public MM.UserInfoExt UserInfoExt;
    }
}
