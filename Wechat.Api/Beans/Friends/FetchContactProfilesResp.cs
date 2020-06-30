using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wechat.Api.Beans.Friends
{
    public class FetchContactProfilesResp
    {
        public IList<micromsg.ContactProfile> Profiles { get; set; }
    }
    /// <summary>
    /// 联系人
    /// </summary>
    public class ContactProfile
    {
        /// <summary>
        /// 微信Id
        /// </summary>
        public string WxId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 微博昵称
        /// </summary>
        public string WeiboNickname { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 大头像url
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像url
        /// </summary>
        public string SmallHeadImgUrl { get; set; }


        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCardNum { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 卡图片地址
        /// </summary>
        public string CardImgUrl { get; set; }
    }
}
