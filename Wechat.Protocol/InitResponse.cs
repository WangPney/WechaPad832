using MMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Protocol
{
    public class InitResponse
    {
        public IList<micromsg.ModUserInfo> ModUserInfos { get; set; } = new List<micromsg.ModUserInfo>();
        public IList<micromsg.ModContact> ModContacts { get; set; } = new List<micromsg.ModContact>();
        public IList<micromsg.DelContact> DelContacts { get; set; } = new List<micromsg.DelContact>();
        public IList<micromsg.AddMsg> AddMsgs { get; set; } = new List<micromsg.AddMsg>();
        public IList<micromsg.ModMsgStatus> ModMsgStatuss { get; set; } = new List<micromsg.ModMsgStatus>();
        public IList<micromsg.DelChatContact> DelChatContacts { get; set; } = new List<micromsg.DelChatContact>();
        public IList<micromsg.DelContactMsg> DelContactMsgs { get; set; } = new List<micromsg.DelContactMsg>();
        public IList<micromsg.DelMsg> DelMsgs { get; set; } = new List<micromsg.DelMsg>();
        public IList<micromsg.Report> Reports { get; set; } = new List<micromsg.Report>();

        public IList<micromsg.OpenQQMicroBlog> OpenQQMicroBlogs { get; set; } = new List<micromsg.OpenQQMicroBlog>();
        public IList<micromsg.CloseMicroBlog> CloseMicroBlogs { get; set; } = new List<micromsg.CloseMicroBlog>();

        public IList<micromsg.InviteFriendOpen> InviteFriendOpens { get; set; } = new List<micromsg.InviteFriendOpen>();
        
        public IList<micromsg.ModNotifyStatus> ModNotifyStatuss { get; set; } = new List<micromsg.ModNotifyStatus>();
        public IList<micromsg.ModChatRoomMember> ModChatRoomMembers { get; set; } = new List<micromsg.ModChatRoomMember>();
        public IList<micromsg.QuitChatRoom> QuitChatRooms { get; set; } = new List<micromsg.QuitChatRoom>();
        public IList<micromsg.ModUserDomainEmail> ModUserDomainEmails { get; set; } = new List<micromsg.ModUserDomainEmail>();
        public IList<micromsg.DelUserDomainEmail> DelUserDomainEmails { get; set; } = new List<micromsg.DelUserDomainEmail>();
        public IList<micromsg.ModChatRoomNotify> ModChatRoomNotifys { get; set; } = new List<micromsg.ModChatRoomNotify>();
        public IList<micromsg.PossibleFriend> PossibleFriends { get; set; } = new List<micromsg.PossibleFriend>();
        //public IList<micromsg.InviteFriendOpen> InviteFriendOpens { get; set; } = new List<micromsg.InviteFriendOpen>();
        public IList<micromsg.FunctionSwitch> FunctionSwitchs { get; set; } = new List<micromsg.FunctionSwitch>();
        public IList<micromsg.QContact> QContacts { get; set; } = new List<micromsg.QContact>();
        public IList<micromsg.TContact> TContacts { get; set; } = new List<micromsg.TContact>();        

        public IList<micromsg.PSMStat> PSMStats { get; set; } = new List<micromsg.PSMStat>();
        public IList<micromsg.ModChatRoomTopic> ModChatRoomTopics { get; set; } = new List<micromsg.ModChatRoomTopic>();
        public IList<micromsg.UpdateStatOpLog> UpdateStatOpLogs { get; set; } = new List<micromsg.UpdateStatOpLog>();
        
        public IList<micromsg.ModDisturbSetting> ModDisturbSettings { get; set; } = new List<micromsg.ModDisturbSetting>();

        //public IList<micromsg.DeleteBottle> DeleteBottles { get; set; } = new List<micromsg.DeleteBottle>();
        
        public IList<micromsg.ModBottleContact> ModBottleContacts { get; set; } = new List<micromsg.ModBottleContact>();

        public IList<micromsg.DelBottleContact> DelBottleContacts { get; set; } = new List<micromsg.DelBottleContact>();

        public IList<micromsg.ModUserImg> ModUserImgs { get; set; } = new List<micromsg.ModUserImg>();
        public IList<micromsg.ModDisturbSetting> ModDisturbSetting { get; set; } = new List<micromsg.ModDisturbSetting>();
        public IList<micromsg.KVStatItem> KVStatItems { get; set; } = new List<micromsg.KVStatItem>();

        public IList<micromsg.ThemeOpLog> ThemeOpLogs { get; set; } = new List<micromsg.ThemeOpLog>();        

        public IList<micromsg.UserInfoExt> UserInfoExts { get; set; } = new List<micromsg.UserInfoExt>();
        public IList<micromsg.SnsObject> SnsObjects { get; set; } = new List<micromsg.SnsObject>();
        public IList<micromsg.SnsActionGroup> SnsActionGroups { get; set; } = new List<micromsg.SnsActionGroup>();
        
        public IList<micromsg.ModBrandSetting> ModBrandSettings { get; set; } = new List<micromsg.ModBrandSetting>();
        public IList<micromsg.ModChatRoomMemberDisplayName> ModChatRoomMemberDisplayNames { get; set; } = new List<micromsg.ModChatRoomMemberDisplayName>();
        public IList<micromsg.ModChatRoomMemberFlag> ModChatRoomMemberFlags { get; set; } = new List<micromsg.ModChatRoomMemberFlag>();

        public IList<micromsg.WebWxFunctionSwitch> WebWxFunctionSwitchs { get; set; } = new List<micromsg.WebWxFunctionSwitch>();

        public IList<micromsg.ModSnsBlackList> ModSnsBlackLists { get; set; } = new List<micromsg.ModSnsBlackList>();
        public IList<micromsg.NewDelMsg> NewDelMsgs { get; set; } = new List<micromsg.NewDelMsg>();
        public IList<micromsg.ModDescription> ModDescriptions { get; set; } = new List<micromsg.ModDescription>();

        public IList<micromsg.KVCmd> KVCmds { get; set; } = new List<micromsg.KVCmd>();

        public IList<micromsg.DeleteSnsOldGroup> DeleteSnsOldGroups { get; set; } = new List<micromsg.DeleteSnsOldGroup>();
         
    }
}
