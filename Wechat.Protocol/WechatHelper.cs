using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MMPro.MM;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Newtonsoft.Json;
using Wechat.Util.Cache;
using CRYPT;
using Wechat.Util.Exceptions;
using Wechat.Util.Extensions;
using MMPro;
using Wechat.Util.Ip;
using System.Threading;
using System.Text.RegularExpressions;

namespace Wechat.Protocol
{
    public class WechatHelper
    {
        [DllImport("Common.dll")]
        private static extern int GenerateECKey(int nid, byte[] pub, byte[] pri);

        [DllImport("Common.dll")]
        public static extern int ComputerECCKeyMD5(byte[] pub, int pubLen, byte[] pri, int priLen, byte[] eccKey);

        [DllImport("Common.dll")]
        private static extern uint Adler32(uint adler, byte[] buf, int len);

        //微信版本号
        private int version = 0;

        //RSA秘钥版本
        private uint LOGIN_RSA_VER = 174;
        /// <summary>
        /// 系统类型
        /// </summary>
        private string osType = "";
        private string phoneOsType = "";

        /*
        public object VerifyUserList(string wxId, VerifyUserOpCode mM_VERIFYUSER_SENDREQUEST, string content, VerifyUser[] verifyUser_, byte origin)
        {
            throw new NotImplementedException();
        }
        */
        private readonly RedisCache _redisCache;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public WechatHelper(RedisCache redisCache)
        {
            this._redisCache = redisCache;
            //ClientProxy.WxValues values = ClientProxy.WxParams.GetParams();
            //version = values.version; //  0x17000523;//7/0/5
            //phoneOsType = values.phoneOsType; // "iPad iPhone OS 12_3_1 ";
            //osType = values.osType; // "iPad iPhone OS 12_3_1 ";

            version = 0x17000523;
            phoneOsType = "iPad iPhone OS9.3.3";
            osType = "iPad iPhone OS9.3.3";
        }

        /// <summary>
        /// 获取AesKey
        /// </summary>
        /// <returns></returns>
        private byte[] GetAeskey()
        {
            string aesKeyStr = (new Random()).NextBytes(16).ToString(16, 2);
            return aesKeyStr.ToByteArray(16, 2);
        }

        private string GetAeskeyStr()
        {
            string aesKeyStr = (new Random()).NextBytes(16).ToString(16, 2);
            return aesKeyStr;
        }
        /// <summary>
        /// 获取设备
        /// </summary>
        /// <returns></returns>
        private byte[] GetDeviceId()
        {
            string result = "";
            Random rd = new Random();
            for (var i = 0; i < 15; i++)
            {
                result += rd.Next(0, 10).ToString();
            }
            return result.ToByteArray(16, 2);
            //return "202c2405786fefb2a6cc841063e360f9".ToByteArray(16, 2);
            //string deviceIdStr = (new Random()).NextBytes(16).ToString(16, 2).ToLower();
            //return deviceIdStr.ToByteArray(16, 2);
        }

        private string GetDeviceIdStr()
        {
            string result = "";
            Random rd = new Random();
            for (var i = 0; i < 15; i++)
            {
                result += rd.Next(0, 10).ToString();
            }
            return result;
            ////return "202c2405786fefb2a6cc841063e360f9";
            //string deviceIdStr = (new Random()).NextBytes(16).ToString(16, 2).ToLower();
            //return deviceIdStr;
        }
        /// <summary>
        /// 请求的基本参数
        /// </summary>
        /// <param name="aesKey"></param>
        /// <param name="deviceId"></param>
        /// <param name="scene"></param>
        /// <returns></returns>
        private BaseRequest GetBaseRequest(byte[] aesKey, byte[] deviceId, int scene = 0)
        {
            var baseRequest = new BaseRequest()
            {
                clientVersion = version,

                devicelId = deviceId,
                scene = scene,
                sessionKey = aesKey,
                osType = osType,
                uin = 0
            };
            return baseRequest;
        }

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <returns></returns>
        public GetLoginQRCodeResponse GetLoginQRcode(int count = 0, string ip = null, string username = null, string password = null, string deviceIdStr = null)
        {
            var aesKey = GetAeskey();
            byte[] deviceId = null;
            if (string.IsNullOrEmpty(deviceIdStr))
            {
                string str_deviceId = GetDeviceIdStr();
                string md5_deviceId=Util.MD5Encrypt(str_deviceId);
                string enc_deviceId = "49" + md5_deviceId.Substring(2, md5_deviceId.Length-2);
                //deviceId = "49ba7db2f4a3ffe0e96218f6b92cde15".ToByteArray(16, 2);
                deviceId = enc_deviceId.ToByteArray(16, 2);
            }
            else
            {
                deviceId = Encoding.UTF8.GetBytes(deviceIdStr);
            }
            ProxyIpCacheResp proxy = null;
            //if (IpHelper.IsProxy)
            //{
                //proxy = IpHelper.GetProxy();
                if (!string.IsNullOrEmpty(ip))
                {
                    proxy = new ProxyIpCacheResp()
                    {
                        ProxyIp = ip,
                        Username = username,
                        Password = password
                    };
                    try
                    {
                        var res = Wechat.Protocol.Util.HttpPostTestProxy("http://www.baidu.com", proxy);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"{proxy.ProxyIp}代理超时");
                        //proxy = null;
                    }

                }
                else if (string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(username))
                {
                    proxy = new ProxyIpCacheResp()
                    {
                        ClientProxyId = username
                    };
                }
            //}
            int mUid = 0;
            string cookie = null;
            GetLoginQRCodeResponse getLoginQRCodeResponse = null;
            GetLoginQRCodeRequest getLoginQRCodeRequest = new GetLoginQRCodeRequest()
            {
                aes = new AesKey()
                {
                    key = aesKey,
                    len = 16
                },
                baseRequest = GetBaseRequest(aesKey, deviceId, 0),
                opcode = 0
            };
            //序列化 protobuf
            var src = Util.Serialize(getLoginQRCodeRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETLOGINQRCODE, bufferlen, aesKey, null, 0, null, 7);
            //发包
            byte[] RetDate = Util.HttpPost("", SendDate, URL.CGI_GETLOGINQRCODE, proxy);
            // 解包头
            if (RetDate == null) { return new GetLoginQRCodeResponse(); }
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                var RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, aesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, aesKey);
                }

                
                getLoginQRCodeResponse = Util.Deserialize<GetLoginQRCodeResponse>(RespProtobuf);

                if (getLoginQRCodeResponse != null && !string.IsNullOrEmpty(getLoginQRCodeResponse.uuid))
                {
                    string key = ConstCacheKey.GetUuidKey(getLoginQRCodeResponse.uuid);
                    CustomerInfoCache customerInfoCache = new CustomerInfoCache()
                    {
                        Uuid = getLoginQRCodeResponse.uuid,
                        MUid = mUid,
                        AesKey = getLoginQRCodeResponse.AESKey.key,
                        DeviceId = deviceId,
                        Cookie = cookie,
                        Proxy = proxy,
                    };
                    this._redisCache.Add(key, customerInfoCache, 600);

                }
            }
            else
            {
                
                _logger.Error($"GetLoginQRcode代理请求出错，移除代理【{proxy.ToJson()}】");
                //var b = IpHelper.ProxyIps.Remove(proxy);
                if (count > 5)
                {
                    _logger.Error($"代理请求超过次数");
                    throw new ExpiredException("系统出现异常，请稍后再试");
                }
                getLoginQRCodeResponse = GetLoginQRcode(count++);
                //throw new ExpiredException("用户可能退出,请重新登陆");
            }
            return getLoginQRCodeResponse;
        }


        /// <summary>
        /// 检查扫码状态
        /// </summary>
        /// <param name="uuid">获取二维码时返回的uuid</param>
        /// <returns></returns>
        public CustomerInfoCache CheckLoginQRCode(string uuid, int count = 1)
        {
            string key = ConstCacheKey.GetUuidKey(uuid);
            var cache = this._redisCache;
            var customerInfoCache = cache.Get<CustomerInfoCache>(key);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"缓存失效，请重新生成二维码登录");
            }
            if (customerInfoCache.State == 2)
            {
                return customerInfoCache;
            }
            int mUid = 0;
            string cookie = null;
            var RespProtobuf = new byte[0];

            CheckLoginQRCodeRequest checkLoginQRCodeRequest = new CheckLoginQRCodeRequest()
            {
                aes = new AesKey()
                {
                    key = customerInfoCache.AesKey,
                    len = 16
                },
                baseRequest = GetBaseRequest(customerInfoCache.AesKey, customerInfoCache.DeviceId, 0),
                uuid = uuid,
                timeStamp = (uint)CurrentTime_(),
                opcode = 0
            };
            var src = Util.Serialize(checkLoginQRCodeRequest);

            //src = LongLinkPack(LongLinkCmdId.SEND_CHECKLOGINQRCODE_CMDID, CGI_TYPE.CGI_TYPE_CHECKLOGINQRCODE, src, 1);

            //return m_client.Send(src, src.Length);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_CHECKLOGINQRCODE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf,
                customerInfoCache.MUid, customerInfoCache.Cookie, 7);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_CHECKLOGINQRCODE, customerInfoCache.Proxy);
            if (RetDate == null) { return null; }
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
            }
            else
            {
                //var b = IpHelper.ProxyIps.Remove(customerInfoCache.Proxy);
                _logger.Error($"CheckLoginQRCode代理请求出错，移除代理【{customerInfoCache.Proxy.ToJson()}】");
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var result = Util.Deserialize<CheckLoginQRCodeResponse>(RespProtobuf);
            if (result == null)
            {
                return null;
            }
            else if (result.baseResponse.ret == MMPro.MM.RetConst.MM_OK)
            {
                var asd = result.data.notifyData.buffer.ToString(16, 2);
                var __ = Util.nouncompress_aes(result.data.notifyData.buffer, customerInfoCache.AesKey);
                if (__ == null)
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }
                var r = Util.Deserialize<MMPro.MM.LoginQRCodeNotify>(__);
                if (r.headImgUrl != null)
                {
                    customerInfoCache.HeadUrl = r.headImgUrl;
                    customerInfoCache.MUid = mUid;
                    customerInfoCache.Cookie = cookie;
                    customerInfoCache.WxId = r.wxid;
                    customerInfoCache.WxNewPass = r.wxnewpass;
                    customerInfoCache.State = r.state;
                    customerInfoCache.Uuid = r.uuid;
                    customerInfoCache.NickName = r.nickName;
                    customerInfoCache.Device = r.device;
                    if (r.state == 2)
                    {
                        //发送登录包
                        checkManualAuth(customerInfoCache, count);
                        cache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.WxId, customerInfoCache);

                        //var producer = RocketMqHelper.CreateDefaultMQProducer(MqConst.UserSyncMessageCusomerGroup);
                        //producer.SendMessage(new Message(MqConst.UserSyncMessageTopic, Encoding.UTF8.GetBytes(customerInfoCache.WxId)), 3);

                        //cache.Remove(key);

                    }
                }
            }
            else
            {
                customerInfoCache.State = -1;
            }
            return customerInfoCache;
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="wxId"></param>
        public InitResponse Init(string wxId)
        {
            InitResponse list = new InitResponse();

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int ret = 1;
            mm.command.NewInitResponse newInit = null;
            while (ret == 1)
            {
                newInit = NewInit(customerInfoCache);
                ret = newInit.ContinueFlag;

                foreach (var r in newInit.CmdListList)
                {
                    switch ((SyncCmdID)r.CmdId)
                    {
                        case SyncCmdID.CmdInvalid:
                            break;
                        case SyncCmdID.CmdIdModUserInfo:
                            var modUserInfo = Util.Deserialize<micromsg.ModUserInfo>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModUserInfos.Add(modUserInfo);
                            break;
                        case SyncCmdID.CmdIdModContact:
                            var modContact = Util.Deserialize<micromsg.ModContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModContacts.Add(modContact);
                            break;
                        case SyncCmdID.CmdIdDelContact:
                            var delContact = Util.Deserialize<micromsg.DelContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelContacts.Add(delContact);
                            break;
                        case SyncCmdID.CmdIdAddMsg:
                            var addMsg = Util.Deserialize<micromsg.AddMsg>(r.CmdBuf.Buffer.ToByteArray());
                            //if (addMsg.MsgType == 3 || addMsg.MsgType == 34 || addMsg.MsgType == 43)
                            //{
                            //    try
                            //    {
                            //        UploadFileObj uploadFileObj = new UploadFileObj()
                            //        {
                            //            MsgId = addMsg.MsgId,
                            //            NewMsgId = addMsg.NewMsgId,
                            //            WxId = wxId,
                            //            ToWxId = addMsg.ToUserName.String,
                            //            MsgType = addMsg.MsgType,
                            //            Buffer = addMsg.ImgBuf.Buffer,
                            //        };


                            //        XmlDocument xml = new XmlDocument();
                            //        var msgContents = addMsg.Content.String.Split(":");
                            //        if (msgContents.Count() == 1)
                            //        {
                            //            xml.LoadXml(msgContents[0]);
                            //        }
                            //        else
                            //        {
                            //            xml.LoadXml(msgContents[1]?.Trim('\n'));
                            //        }

                            //        XmlAttribute length = null;
                            //        if (addMsg.MsgType == 3)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("img")?.Attributes["hdlength"];
                            //            if (length == null)
                            //            {
                            //                length = xml.SelectSingleNode("/msg")?.SelectSingleNode("img")?.Attributes["length"];

                            //                var comlength = xml.SelectSingleNode("/msg")?.SelectSingleNode("img")?.Attributes["length"];
                            //                uploadFileObj.Length = length == null ? 0 : Convert.ToInt64(comlength.Value);
                            //            }

                            //        }
                            //        else if (addMsg.MsgType == 34)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("voicemsg")?.Attributes["voicelength"];
                            //        }
                            //        else if (addMsg.MsgType == 43)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("videomsg")?.Attributes["length"];
                            //        }

                            //        uploadFileObj.LongDataLength = length == null ? 0 : Convert.ToInt64(length.Value);
                            //        var producer = RocketMqHelper.CreateDefaultMQProducer(MqConst.UploadOssProducerGroup);
                            //        var buffer = Encoding.UTF8.GetBytes(uploadFileObj.ToJson());
                            //        Message message = new Message(MqConst.UploadOssTopic, buffer);
                            //        producer.SendMessage(message);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Wechat.Util.Log._logger.LogError($"{wxId}同步微信消息错误", ex);
                            //    }
                            //}

                            list.AddMsgs.Add(addMsg);
                            break;
                        case SyncCmdID.CmdIdModMsgStatus:
                            var mdMsgStatus = Util.Deserialize<micromsg.ModMsgStatus>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModMsgStatuss.Add(mdMsgStatus);
                            break;
                        case SyncCmdID.CmdIdDelChatContact:
                            var delChatContact = Util.Deserialize<micromsg.DelChatContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelChatContacts.Add(delChatContact);
                            break;
                        case SyncCmdID.CmdIdDelContactMsg:
                            var delContactMsg = Util.Deserialize<micromsg.DelContactMsg>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelContactMsgs.Add(delContactMsg);
                            break;
                        case SyncCmdID.CmdIdDelMsg:
                            var dlMsg = Util.Deserialize<micromsg.DelMsg>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelMsgs.Add(dlMsg);
                            break;
                        case SyncCmdID.CmdIdReport:
                            Util.Deserialize<micromsg.Report>(r.CmdBuf.Buffer.ToByteArray());
                            break;
                        case SyncCmdID.CmdIdOpenQQMicroBlog:
                            var openQQMicroBlog = Util.Deserialize<micromsg.OpenQQMicroBlog>(r.CmdBuf.Buffer.ToByteArray());
                            list.OpenQQMicroBlogs.Add(openQQMicroBlog);
                            break;
                        case SyncCmdID.CmdIdCloseMicroBlog:
                            var closeMicroBlog = Util.Deserialize<micromsg.CloseMicroBlog>(r.CmdBuf.Buffer.ToByteArray());
                            list.CloseMicroBlogs.Add(closeMicroBlog);
                            break;
                        case SyncCmdID.CmdIdModMicroBlog:
                            var inviteFriendOpen = Util.Deserialize<micromsg.InviteFriendOpen>(r.CmdBuf.Buffer.ToByteArray());
                            list.InviteFriendOpens.Add(inviteFriendOpen);
                            break;
                        case SyncCmdID.CmdIdModNotifyStatus:
                            var modNotifyStatus = Util.Deserialize<micromsg.ModNotifyStatus>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModNotifyStatuss.Add(modNotifyStatus);
                            break;
                        case SyncCmdID.CmdIdModChatRoomMember:
                            var modChatRoomMember = Util.Deserialize<micromsg.ModChatRoomMember>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModChatRoomMembers.Add(modChatRoomMember);
                            break;
                        case SyncCmdID.CmdIdQuitChatRoom:
                            var quitChatRoom = Util.Deserialize<micromsg.QuitChatRoom>(r.CmdBuf.Buffer.ToByteArray());
                            list.QuitChatRooms.Add(quitChatRoom);
                            break;
                        case SyncCmdID.CmdIdModContactDomainEmail:
                            //Util.Deserialize<micromsg.ModContactDomainEmail>(r.CmdBuf.Buffer.ToByteArray());
                            break;
                        case SyncCmdID.CmdIdModUserDomainEmail:
                            var modUserDomainEmail = Util.Deserialize<micromsg.ModUserDomainEmail>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModUserDomainEmails.Add(modUserDomainEmail);
                            break;
                        case SyncCmdID.CmdIdDelUserDomainEmail:
                            var delUserDomainEmail = Util.Deserialize<micromsg.DelUserDomainEmail>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelUserDomainEmails.Add(delUserDomainEmail);
                            break;
                        case SyncCmdID.CmdIdModChatRoomNotify:
                            var modChatRoomNotify = Util.Deserialize<micromsg.ModChatRoomNotify>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModChatRoomNotifys.Add(modChatRoomNotify);
                            break;
                        case SyncCmdID.CmdIdPossibleFriend:
                            var possibleFriend = Util.Deserialize<micromsg.PossibleFriend>(r.CmdBuf.Buffer.ToByteArray());
                            list.PossibleFriends.Add(possibleFriend);
                            break;
                        case SyncCmdID.CmdIdInviteFriendOpen:
                            var inviteFriendOpen1 = Util.Deserialize<micromsg.InviteFriendOpen>(r.CmdBuf.Buffer.ToByteArray());
                            list.InviteFriendOpens.Add(inviteFriendOpen1);
                            break;
                        case SyncCmdID.CmdIdFunctionSwitch:
                            var functionSwitch = Util.Deserialize<micromsg.FunctionSwitch>(r.CmdBuf.Buffer.ToByteArray());
                            list.FunctionSwitchs.Add(functionSwitch);
                            break;
                        case SyncCmdID.CmdIdModQContact:
                            var qContact = Util.Deserialize<micromsg.QContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.QContacts.Add(qContact);
                            break;
                        case SyncCmdID.CmdIdModTContact:
                            var tContact = Util.Deserialize<micromsg.TContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.TContacts.Add(tContact);
                            break;
                        case SyncCmdID.CmdIdPsmStat:
                            var pSMStat = Util.Deserialize<micromsg.PSMStat>(r.CmdBuf.Buffer.ToByteArray());
                            list.PSMStats.Add(pSMStat);
                            break;
                        case SyncCmdID.CmdIdModChatRoomTopic:
                            var modChatRoomTopic = Util.Deserialize<micromsg.ModChatRoomTopic>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModChatRoomTopics.Add(modChatRoomTopic);
                            break;
                        case SyncCmdID.MM_SYNCCMD_UPDATESTAT:
                            var updateStatOpLog = Util.Deserialize<micromsg.UpdateStatOpLog>(r.CmdBuf.Buffer.ToByteArray());
                            list.UpdateStatOpLogs.Add(updateStatOpLog);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODDISTURBSETTING:

                            var modDisturbSetting = Util.Deserialize<micromsg.ModDisturbSetting>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModDisturbSettings.Add(modDisturbSetting);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELETEBOTTLE:
                            //var deleteBottle=  Util.Deserialize<micromsg.DeleteBottle>(r.CmdBuf.Buffer.ToByteArray());
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODBOTTLECONTACT:
                            var modBottleContact = Util.Deserialize<micromsg.ModBottleContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModBottleContacts.Add(modBottleContact);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELBOTTLECONTACT:

                            var delBottleContact = Util.Deserialize<micromsg.DelBottleContact>(r.CmdBuf.Buffer.ToByteArray());
                            list.DelBottleContacts.Add(delBottleContact);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODUSERIMG:

                            var modUserImg = Util.Deserialize<micromsg.ModUserImg>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModUserImgs.Add(modUserImg);
                            break;
                        case SyncCmdID.MM_SYNCCMD_KVSTAT:

                            var kVStatItem = Util.Deserialize<micromsg.KVStatItem>(r.CmdBuf.Buffer.ToByteArray());
                            list.KVStatItems.Add(kVStatItem);
                            break;
                        case SyncCmdID.NN_SYNCCMD_THEMESTAT:
                            var themeOpLog = Util.Deserialize<micromsg.ThemeOpLog>(r.CmdBuf.Buffer.ToByteArray());
                            list.ThemeOpLogs.Add(themeOpLog);
                            break;
                        case SyncCmdID.MM_SYNCCMD_USERINFOEXT:

                            var userInfoExt = Util.Deserialize<micromsg.UserInfoExt>(r.CmdBuf.Buffer.ToByteArray());
                            list.UserInfoExts.Add(userInfoExt);
                            break;
                        case SyncCmdID.MM_SNS_SYNCCMD_OBJECT:
                            var snsObject = Util.Deserialize<micromsg.SnsObject>(r.CmdBuf.Buffer.ToByteArray());
                            list.SnsObjects.Add(snsObject);
                            break;
                        case SyncCmdID.MM_SNS_SYNCCMD_ACTION:
                            var snsActionGroup = Util.Deserialize<micromsg.SnsActionGroup>(r.CmdBuf.Buffer.ToByteArray());
                            list.SnsActionGroups.Add(snsActionGroup);
                            break;
                        case SyncCmdID.MM_SYNCCMD_BRAND_SETTING:

                            var modBrandSetting = Util.Deserialize<micromsg.ModBrandSetting>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModBrandSettings.Add(modBrandSetting);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME:

                            var modChatRoomMemberDisplayName = Util.Deserialize<micromsg.ModChatRoomMemberDisplayName>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModChatRoomMemberDisplayNames.Add(modChatRoomMemberDisplayName);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG:

                            var modChatRoomMemberFlag = Util.Deserialize<micromsg.ModChatRoomMemberFlag>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModChatRoomMemberFlags.Add(modChatRoomMemberFlag);
                            break;
                        case SyncCmdID.MM_SYNCCMD_WEBWXFUNCTIONSWITCH:

                            var webWxFunctionSwitch = Util.Deserialize<micromsg.WebWxFunctionSwitch>(r.CmdBuf.Buffer.ToByteArray());
                            list.WebWxFunctionSwitchs.Add(webWxFunctionSwitch);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSUSERINFO:

                            //Util.Deserialize<micromsg>(r.CmdBuf.Buffer.ToByteArray());
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSBLACKLIST:
                            var modSnsBlackList = Util.Deserialize<micromsg.ModSnsBlackList>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModSnsBlackLists.Add(modSnsBlackList);
                            break;
                        case SyncCmdID.MM_SYNCCMD_NEWDELMSG:

                            var newDelMsg = Util.Deserialize<micromsg.NewDelMsg>(r.CmdBuf.Buffer.ToByteArray());
                            list.NewDelMsgs.Add(newDelMsg);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODDESCRIPTION:

                            var modDescription = Util.Deserialize<micromsg.ModDescription>(r.CmdBuf.Buffer.ToByteArray());
                            list.ModDescriptions.Add(modDescription);
                            break;
                        case SyncCmdID.MM_SYNCCMD_KVCMD:

                            var kVCmd = Util.Deserialize<micromsg.KVCmd>(r.CmdBuf.Buffer.ToByteArray());
                            list.KVCmds.Add(kVCmd);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELETE_SNS_OLDGROUP:

                            var deleteSnsOldGroup = Util.Deserialize<micromsg.DeleteSnsOldGroup>(r.CmdBuf.Buffer.ToByteArray());
                            list.DeleteSnsOldGroups.Add(deleteSnsOldGroup);
                            break;
                        case SyncCmdID.MM_FAV_SYNCCMD_ADDITEM:

                            //Util.Deserialize<micromsg>(r.CmdBuf.Buffer.ToByteArray());
                            break;
                        case SyncCmdID.CmdIdMax:

                            //Util.Deserialize<micromsg>(r.CmdBuf.Buffer.ToByteArray());
                            break;


                    }



                }
            }
            customerInfoCache.Sync = newInit.CurrentSynckey.ToByteArray();
            cache.HashSet(ConstCacheKey.GetWxIdKey(), wxId, customerInfoCache);
            return list;

        }

        /// <summary>
        /// 同步消息
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public InitResponse SyncInit(string wxId)
        {
            InitResponse list = new InitResponse();

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            if (customerInfoCache.Sync == null)
            {
                list = Init(wxId);
                customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
                if (customerInfoCache == null)
                {
                    throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
                }
            }
            int ret = 1;
            //var NewInit = new mm.command.NewInitResponse();
            while (ret == 1)
            {
                var NewSync = NewSyncEcode(customerInfoCache, 4);
                if (NewSync.cmdList == null) { break; }
                if (NewSync.cmdList.count <= 0) { break; }
                ret = NewSync.Continueflag;
                foreach (var r in NewSync.cmdList.list)
                {
                    switch ((SyncCmdID)r.cmdid)
                    {
                        case SyncCmdID.CmdInvalid:
                            break;
                        case SyncCmdID.CmdIdModUserInfo:
                            var modUserInfo = Util.Deserialize<micromsg.ModUserInfo>(r.cmdBuf.data);
                            list.ModUserInfos.Add(modUserInfo);
                            break;
                        case SyncCmdID.CmdIdModContact:
                            var modContact = Util.Deserialize<micromsg.ModContact>(r.cmdBuf.data);
                            list.ModContacts.Add(modContact);
                            break;
                        case SyncCmdID.CmdIdDelContact:
                            var delContact = Util.Deserialize<micromsg.DelContact>(r.cmdBuf.data);
                            list.DelContacts.Add(delContact);
                            break;
                        case SyncCmdID.CmdIdAddMsg:
                            var addMsg = Util.Deserialize<micromsg.AddMsg>(r.cmdBuf.data);
                            //if (addMsg.MsgType == 3 || addMsg.MsgType == 34 || addMsg.MsgType == 43)
                            //{
                            //    try
                            //    {
                            //        UploadFileObj uploadFileObj = new UploadFileObj()
                            //        {
                            //            MsgId = addMsg.MsgId,
                            //            NewMsgId = addMsg.NewMsgId,
                            //            WxId = wxId,
                            //            ToWxId = addMsg.ToUserName.String,
                            //            MsgType = addMsg.MsgType,
                            //            Buffer = addMsg.ImgBuf.Buffer,

                            //        };


                            //        XmlDocument xml = new XmlDocument();
                            //        var msgContents = addMsg.Content.String.Split(":");
                            //        if (msgContents.Count() == 1)
                            //        {
                            //            xml.LoadXml(msgContents[0]);
                            //        }
                            //        else
                            //        {
                            //            xml.LoadXml(msgContents[1]?.Trim('\n'));
                            //        }

                            //        XmlAttribute length = null;
                            //        if (addMsg.MsgType == 3)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("img")?.Attributes["hdlength"];

                            //            var comlength = xml.SelectSingleNode("/msg")?.SelectSingleNode("img")?.Attributes["length"];
                            //            uploadFileObj.Length = length == null ? 0 : Convert.ToInt64(comlength.Value);
                            //        }
                            //        else if (addMsg.MsgType == 34)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("voicemsg")?.Attributes["voicelength"];
                            //        }
                            //        else if (addMsg.MsgType == 43)
                            //        {
                            //            length = xml.SelectSingleNode("/msg")?.SelectSingleNode("videomsg")?.Attributes["length"];
                            //        }

                            //        uploadFileObj.LongDataLength = length == null ? 0 : Convert.ToInt64(length.Value);
                            //        var producer = RocketMqHelper.CreateDefaultMQProducer(MqConst.UploadOssProducerGroup);
                            //        var buffer = Encoding.UTF8.GetBytes(uploadFileObj.ToJson());
                            //        Message message = new Message(MqConst.UploadOssTopic, buffer);
                            //        producer.SendMessage(message);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Wechat.Util.Log._logger.LogError($"{wxId}同步微信消息错误", ex);
                            //    }
                            //}

                            list.AddMsgs.Add(addMsg);
                            break;
                        case SyncCmdID.CmdIdModMsgStatus:
                            var mdMsgStatus = Util.Deserialize<micromsg.ModMsgStatus>(r.cmdBuf.data);
                            list.ModMsgStatuss.Add(mdMsgStatus);
                            break;
                        case SyncCmdID.CmdIdDelChatContact:
                            var delChatContact = Util.Deserialize<micromsg.DelChatContact>(r.cmdBuf.data);
                            list.DelChatContacts.Add(delChatContact);
                            break;
                        case SyncCmdID.CmdIdDelContactMsg:
                            var delContactMsg = Util.Deserialize<micromsg.DelContactMsg>(r.cmdBuf.data);
                            list.DelContactMsgs.Add(delContactMsg);
                            break;
                        case SyncCmdID.CmdIdDelMsg:
                            var dlMsg = Util.Deserialize<micromsg.DelMsg>(r.cmdBuf.data);
                            list.DelMsgs.Add(dlMsg);
                            break;
                        case SyncCmdID.CmdIdReport:
                            Util.Deserialize<micromsg.Report>(r.cmdBuf.data);
                            break;
                        case SyncCmdID.CmdIdOpenQQMicroBlog:
                            var openQQMicroBlog = Util.Deserialize<micromsg.OpenQQMicroBlog>(r.cmdBuf.data);
                            list.OpenQQMicroBlogs.Add(openQQMicroBlog);
                            break;
                        case SyncCmdID.CmdIdCloseMicroBlog:
                            var closeMicroBlog = Util.Deserialize<micromsg.CloseMicroBlog>(r.cmdBuf.data);
                            list.CloseMicroBlogs.Add(closeMicroBlog);
                            break;
                        case SyncCmdID.CmdIdModMicroBlog:
                            var inviteFriendOpen = Util.Deserialize<micromsg.InviteFriendOpen>(r.cmdBuf.data);
                            list.InviteFriendOpens.Add(inviteFriendOpen);
                            break;
                        case SyncCmdID.CmdIdModNotifyStatus:
                            var modNotifyStatus = Util.Deserialize<micromsg.ModNotifyStatus>(r.cmdBuf.data);
                            list.ModNotifyStatuss.Add(modNotifyStatus);
                            break;
                        case SyncCmdID.CmdIdModChatRoomMember:
                            var modChatRoomMember = Util.Deserialize<micromsg.ModChatRoomMember>(r.cmdBuf.data);
                            list.ModChatRoomMembers.Add(modChatRoomMember);
                            break;
                        case SyncCmdID.CmdIdQuitChatRoom:
                            var quitChatRoom = Util.Deserialize<micromsg.QuitChatRoom>(r.cmdBuf.data);
                            list.QuitChatRooms.Add(quitChatRoom);
                            break;
                        case SyncCmdID.CmdIdModContactDomainEmail:
                            //Util.Deserialize<micromsg.ModContactDomainEmail>(r.cmdBuf.data);
                            break;
                        case SyncCmdID.CmdIdModUserDomainEmail:
                            var modUserDomainEmail = Util.Deserialize<micromsg.ModUserDomainEmail>(r.cmdBuf.data);
                            list.ModUserDomainEmails.Add(modUserDomainEmail);
                            break;
                        case SyncCmdID.CmdIdDelUserDomainEmail:
                            var delUserDomainEmail = Util.Deserialize<micromsg.DelUserDomainEmail>(r.cmdBuf.data);
                            list.DelUserDomainEmails.Add(delUserDomainEmail);
                            break;
                        case SyncCmdID.CmdIdModChatRoomNotify:
                            var modChatRoomNotify = Util.Deserialize<micromsg.ModChatRoomNotify>(r.cmdBuf.data);
                            list.ModChatRoomNotifys.Add(modChatRoomNotify);
                            break;
                        case SyncCmdID.CmdIdPossibleFriend:
                            var possibleFriend = Util.Deserialize<micromsg.PossibleFriend>(r.cmdBuf.data);
                            list.PossibleFriends.Add(possibleFriend);
                            break;
                        case SyncCmdID.CmdIdInviteFriendOpen:
                            var inviteFriendOpen1 = Util.Deserialize<micromsg.InviteFriendOpen>(r.cmdBuf.data);
                            list.InviteFriendOpens.Add(inviteFriendOpen1);
                            break;
                        case SyncCmdID.CmdIdFunctionSwitch:
                            var functionSwitch = Util.Deserialize<micromsg.FunctionSwitch>(r.cmdBuf.data);
                            list.FunctionSwitchs.Add(functionSwitch);
                            break;
                        case SyncCmdID.CmdIdModQContact:
                            var qContact = Util.Deserialize<micromsg.QContact>(r.cmdBuf.data);
                            list.QContacts.Add(qContact);
                            break;
                        case SyncCmdID.CmdIdModTContact:
                            var tContact = Util.Deserialize<micromsg.TContact>(r.cmdBuf.data);
                            list.TContacts.Add(tContact);
                            break;
                        case SyncCmdID.CmdIdPsmStat:
                            var pSMStat = Util.Deserialize<micromsg.PSMStat>(r.cmdBuf.data);
                            list.PSMStats.Add(pSMStat);
                            break;
                        case SyncCmdID.CmdIdModChatRoomTopic:
                            var modChatRoomTopic = Util.Deserialize<micromsg.ModChatRoomTopic>(r.cmdBuf.data);
                            list.ModChatRoomTopics.Add(modChatRoomTopic);
                            break;
                        case SyncCmdID.MM_SYNCCMD_UPDATESTAT:
                            var updateStatOpLog = Util.Deserialize<micromsg.UpdateStatOpLog>(r.cmdBuf.data);
                            list.UpdateStatOpLogs.Add(updateStatOpLog);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODDISTURBSETTING:

                            var modDisturbSetting = Util.Deserialize<micromsg.ModDisturbSetting>(r.cmdBuf.data);
                            list.ModDisturbSettings.Add(modDisturbSetting);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELETEBOTTLE:
                            //var deleteBottle=  Util.Deserialize<micromsg.DeleteBottle>(r.cmdBuf.data);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODBOTTLECONTACT:
                            var modBottleContact = Util.Deserialize<micromsg.ModBottleContact>(r.cmdBuf.data);
                            list.ModBottleContacts.Add(modBottleContact);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELBOTTLECONTACT:

                            var delBottleContact = Util.Deserialize<micromsg.DelBottleContact>(r.cmdBuf.data);
                            list.DelBottleContacts.Add(delBottleContact);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODUSERIMG:

                            var modUserImg = Util.Deserialize<micromsg.ModUserImg>(r.cmdBuf.data);
                            list.ModUserImgs.Add(modUserImg);
                            break;
                        case SyncCmdID.MM_SYNCCMD_KVSTAT:

                            var kVStatItem = Util.Deserialize<micromsg.KVStatItem>(r.cmdBuf.data);
                            list.KVStatItems.Add(kVStatItem);
                            break;
                        case SyncCmdID.NN_SYNCCMD_THEMESTAT:
                            var themeOpLog = Util.Deserialize<micromsg.ThemeOpLog>(r.cmdBuf.data);
                            list.ThemeOpLogs.Add(themeOpLog);
                            break;
                        case SyncCmdID.MM_SYNCCMD_USERINFOEXT:

                            var userInfoExt = Util.Deserialize<micromsg.UserInfoExt>(r.cmdBuf.data);
                            list.UserInfoExts.Add(userInfoExt);
                            break;
                        case SyncCmdID.MM_SNS_SYNCCMD_OBJECT:
                            var snsObject = Util.Deserialize<micromsg.SnsObject>(r.cmdBuf.data);
                            list.SnsObjects.Add(snsObject);
                            break;
                        case SyncCmdID.MM_SNS_SYNCCMD_ACTION:
                            var snsActionGroup = Util.Deserialize<micromsg.SnsActionGroup>(r.cmdBuf.data);
                            list.SnsActionGroups.Add(snsActionGroup);
                            break;
                        case SyncCmdID.MM_SYNCCMD_BRAND_SETTING:

                            var modBrandSetting = Util.Deserialize<micromsg.ModBrandSetting>(r.cmdBuf.data);
                            list.ModBrandSettings.Add(modBrandSetting);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME:

                            var modChatRoomMemberDisplayName = Util.Deserialize<micromsg.ModChatRoomMemberDisplayName>(r.cmdBuf.data);
                            list.ModChatRoomMemberDisplayNames.Add(modChatRoomMemberDisplayName);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG:

                            var modChatRoomMemberFlag = Util.Deserialize<micromsg.ModChatRoomMemberFlag>(r.cmdBuf.data);
                            list.ModChatRoomMemberFlags.Add(modChatRoomMemberFlag);
                            break;
                        case SyncCmdID.MM_SYNCCMD_WEBWXFUNCTIONSWITCH:

                            var webWxFunctionSwitch = Util.Deserialize<micromsg.WebWxFunctionSwitch>(r.cmdBuf.data);
                            list.WebWxFunctionSwitchs.Add(webWxFunctionSwitch);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSUSERINFO:

                            //Util.Deserialize<micromsg>(r.cmdBuf.data);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODSNSBLACKLIST:
                            var modSnsBlackList = Util.Deserialize<micromsg.ModSnsBlackList>(r.cmdBuf.data);
                            list.ModSnsBlackLists.Add(modSnsBlackList);
                            break;
                        case SyncCmdID.MM_SYNCCMD_NEWDELMSG:

                            var newDelMsg = Util.Deserialize<micromsg.NewDelMsg>(r.cmdBuf.data);
                            list.NewDelMsgs.Add(newDelMsg);
                            break;
                        case SyncCmdID.MM_SYNCCMD_MODDESCRIPTION:

                            var modDescription = Util.Deserialize<micromsg.ModDescription>(r.cmdBuf.data);
                            list.ModDescriptions.Add(modDescription);
                            break;
                        case SyncCmdID.MM_SYNCCMD_KVCMD:

                            var kVCmd = Util.Deserialize<micromsg.KVCmd>(r.cmdBuf.data);
                            list.KVCmds.Add(kVCmd);
                            break;
                        case SyncCmdID.MM_SYNCCMD_DELETE_SNS_OLDGROUP:

                            var deleteSnsOldGroup = Util.Deserialize<micromsg.DeleteSnsOldGroup>(r.cmdBuf.data);
                            list.DeleteSnsOldGroups.Add(deleteSnsOldGroup);
                            break;
                        case SyncCmdID.MM_FAV_SYNCCMD_ADDITEM:

                            //Util.Deserialize<micromsg>(r.cmdBuf.data);
                            break;
                        case SyncCmdID.CmdIdMax:

                            //Util.Deserialize<micromsg>(r.CmdBuf.Buffer.ToByteArray());
                            break;


                    }



                }

                customerInfoCache.Sync = NewSync.sync_key;
            }
            cache.HashSet(ConstCacheKey.GetWxIdKey(), wxId, customerInfoCache);
            return list;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="syncKey"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public Tuple<InitResponse, string, uint> InitUser(string wxId, int syncKey = 0, string buffer = null)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }


            micromsg.InitRequest initRequest = new micromsg.InitRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                SyncKey = (uint)syncKey,
                UserName = new micromsg.SKBuiltinString_t() { String = wxId },
                Language = "cn-zh",
                Buffer = new micromsg.SKBuiltinString_t() { String = buffer },
            };
            var RespProtobuf = new byte[0];

            var src = Util.Serialize(initRequest);
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 0x79, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/init", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var initResponse = Util.Deserialize<micromsg.InitResponse>(RespProtobuf);
            InitResponse list = new InitResponse();
            foreach (var r in initResponse.CmdList)
            {
                switch ((SyncCmdID)r.CmdId)
                {
                    case SyncCmdID.CmdInvalid:
                        break;
                    case SyncCmdID.CmdIdModUserInfo:
                        var modUserInfo = Util.Deserialize<micromsg.ModUserInfo>(r.CmdBuf.Buffer);
                        list.ModUserInfos.Add(modUserInfo);
                        break;
                    case SyncCmdID.CmdIdModContact:
                        var modContact = Util.Deserialize<micromsg.ModContact>(r.CmdBuf.Buffer);
                        list.ModContacts.Add(modContact);
                        break;
                    case SyncCmdID.CmdIdDelContact:
                        var delContact = Util.Deserialize<micromsg.DelContact>(r.CmdBuf.Buffer);
                        list.DelContacts.Add(delContact);
                        break;
                    case SyncCmdID.CmdIdAddMsg:
                        var addMsg = Util.Deserialize<micromsg.AddMsg>(r.CmdBuf.Buffer);
                        list.AddMsgs.Add(addMsg);
                        break;
                    case SyncCmdID.CmdIdModMsgStatus:
                        var mdMsgStatus = Util.Deserialize<micromsg.ModMsgStatus>(r.CmdBuf.Buffer);
                        list.ModMsgStatuss.Add(mdMsgStatus);
                        break;
                    case SyncCmdID.CmdIdDelChatContact:
                        var delChatContact = Util.Deserialize<micromsg.DelChatContact>(r.CmdBuf.Buffer);
                        list.DelChatContacts.Add(delChatContact);
                        break;
                    case SyncCmdID.CmdIdDelContactMsg:
                        var delContactMsg = Util.Deserialize<micromsg.DelContactMsg>(r.CmdBuf.Buffer);
                        list.DelContactMsgs.Add(delContactMsg);
                        break;
                    case SyncCmdID.CmdIdDelMsg:
                        var dlMsg = Util.Deserialize<micromsg.DelMsg>(r.CmdBuf.Buffer);
                        list.DelMsgs.Add(dlMsg);
                        break;
                    case SyncCmdID.CmdIdReport:
                        Util.Deserialize<micromsg.Report>(r.CmdBuf.Buffer);
                        break;
                    case SyncCmdID.CmdIdOpenQQMicroBlog:
                        var openQQMicroBlog = Util.Deserialize<micromsg.OpenQQMicroBlog>(r.CmdBuf.Buffer);
                        list.OpenQQMicroBlogs.Add(openQQMicroBlog);
                        break;
                    case SyncCmdID.CmdIdCloseMicroBlog:
                        var closeMicroBlog = Util.Deserialize<micromsg.CloseMicroBlog>(r.CmdBuf.Buffer);
                        list.CloseMicroBlogs.Add(closeMicroBlog);
                        break;
                    case SyncCmdID.CmdIdModMicroBlog:
                        var inviteFriendOpen = Util.Deserialize<micromsg.InviteFriendOpen>(r.CmdBuf.Buffer);
                        list.InviteFriendOpens.Add(inviteFriendOpen);
                        break;
                    case SyncCmdID.CmdIdModNotifyStatus:
                        var modNotifyStatus = Util.Deserialize<micromsg.ModNotifyStatus>(r.CmdBuf.Buffer);
                        list.ModNotifyStatuss.Add(modNotifyStatus);
                        break;
                    case SyncCmdID.CmdIdModChatRoomMember:
                        var modChatRoomMember = Util.Deserialize<micromsg.ModChatRoomMember>(r.CmdBuf.Buffer);
                        list.ModChatRoomMembers.Add(modChatRoomMember);
                        break;
                    case SyncCmdID.CmdIdQuitChatRoom:
                        var quitChatRoom = Util.Deserialize<micromsg.QuitChatRoom>(r.CmdBuf.Buffer);
                        list.QuitChatRooms.Add(quitChatRoom);
                        break;
                    case SyncCmdID.CmdIdModContactDomainEmail:
                        //Util.Deserialize<micromsg.ModContactDomainEmail>(r.CmdBuf.Buffer);
                        break;
                    case SyncCmdID.CmdIdModUserDomainEmail:
                        var modUserDomainEmail = Util.Deserialize<micromsg.ModUserDomainEmail>(r.CmdBuf.Buffer);
                        list.ModUserDomainEmails.Add(modUserDomainEmail);
                        break;
                    case SyncCmdID.CmdIdDelUserDomainEmail:
                        var delUserDomainEmail = Util.Deserialize<micromsg.DelUserDomainEmail>(r.CmdBuf.Buffer);
                        list.DelUserDomainEmails.Add(delUserDomainEmail);
                        break;
                    case SyncCmdID.CmdIdModChatRoomNotify:
                        var modChatRoomNotify = Util.Deserialize<micromsg.ModChatRoomNotify>(r.CmdBuf.Buffer);
                        list.ModChatRoomNotifys.Add(modChatRoomNotify);
                        break;
                    case SyncCmdID.CmdIdPossibleFriend:
                        var possibleFriend = Util.Deserialize<micromsg.PossibleFriend>(r.CmdBuf.Buffer);
                        list.PossibleFriends.Add(possibleFriend);
                        break;
                    case SyncCmdID.CmdIdInviteFriendOpen:
                        var inviteFriendOpen1 = Util.Deserialize<micromsg.InviteFriendOpen>(r.CmdBuf.Buffer);
                        list.InviteFriendOpens.Add(inviteFriendOpen1);
                        break;
                    case SyncCmdID.CmdIdFunctionSwitch:
                        var functionSwitch = Util.Deserialize<micromsg.FunctionSwitch>(r.CmdBuf.Buffer);
                        list.FunctionSwitchs.Add(functionSwitch);
                        break;
                    case SyncCmdID.CmdIdModQContact:
                        var qContact = Util.Deserialize<micromsg.QContact>(r.CmdBuf.Buffer);
                        list.QContacts.Add(qContact);
                        break;
                    case SyncCmdID.CmdIdModTContact:
                        var tContact = Util.Deserialize<micromsg.TContact>(r.CmdBuf.Buffer);
                        list.TContacts.Add(tContact);
                        break;
                    case SyncCmdID.CmdIdPsmStat:
                        var pSMStat = Util.Deserialize<micromsg.PSMStat>(r.CmdBuf.Buffer);
                        list.PSMStats.Add(pSMStat);
                        break;
                    case SyncCmdID.CmdIdModChatRoomTopic:
                        var modChatRoomTopic = Util.Deserialize<micromsg.ModChatRoomTopic>(r.CmdBuf.Buffer);
                        list.ModChatRoomTopics.Add(modChatRoomTopic);
                        break;
                    case SyncCmdID.MM_SYNCCMD_UPDATESTAT:
                        var updateStatOpLog = Util.Deserialize<micromsg.UpdateStatOpLog>(r.CmdBuf.Buffer);
                        list.UpdateStatOpLogs.Add(updateStatOpLog);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODDISTURBSETTING:

                        var modDisturbSetting = Util.Deserialize<micromsg.ModDisturbSetting>(r.CmdBuf.Buffer);
                        list.ModDisturbSettings.Add(modDisturbSetting);
                        break;
                    case SyncCmdID.MM_SYNCCMD_DELETEBOTTLE:
                        //var deleteBottle=  Util.Deserialize<micromsg.DeleteBottle>(r.CmdBuf.Buffer);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODBOTTLECONTACT:
                        var modBottleContact = Util.Deserialize<micromsg.ModBottleContact>(r.CmdBuf.Buffer);
                        list.ModBottleContacts.Add(modBottleContact);
                        break;
                    case SyncCmdID.MM_SYNCCMD_DELBOTTLECONTACT:

                        var delBottleContact = Util.Deserialize<micromsg.DelBottleContact>(r.CmdBuf.Buffer);
                        list.DelBottleContacts.Add(delBottleContact);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODUSERIMG:

                        var modUserImg = Util.Deserialize<micromsg.ModUserImg>(r.CmdBuf.Buffer);
                        list.ModUserImgs.Add(modUserImg);
                        break;
                    case SyncCmdID.MM_SYNCCMD_KVSTAT:

                        var kVStatItem = Util.Deserialize<micromsg.KVStatItem>(r.CmdBuf.Buffer);
                        list.KVStatItems.Add(kVStatItem);
                        break;
                    case SyncCmdID.NN_SYNCCMD_THEMESTAT:
                        var themeOpLog = Util.Deserialize<micromsg.ThemeOpLog>(r.CmdBuf.Buffer);
                        list.ThemeOpLogs.Add(themeOpLog);
                        break;
                    case SyncCmdID.MM_SYNCCMD_USERINFOEXT:

                        var userInfoExt = Util.Deserialize<micromsg.UserInfoExt>(r.CmdBuf.Buffer);
                        list.UserInfoExts.Add(userInfoExt);
                        break;
                    case SyncCmdID.MM_SNS_SYNCCMD_OBJECT:
                        var snsObject = Util.Deserialize<micromsg.SnsObject>(r.CmdBuf.Buffer);
                        list.SnsObjects.Add(snsObject);
                        break;
                    case SyncCmdID.MM_SNS_SYNCCMD_ACTION:
                        var snsActionGroup = Util.Deserialize<micromsg.SnsActionGroup>(r.CmdBuf.Buffer);
                        list.SnsActionGroups.Add(snsActionGroup);
                        break;
                    case SyncCmdID.MM_SYNCCMD_BRAND_SETTING:

                        var modBrandSetting = Util.Deserialize<micromsg.ModBrandSetting>(r.CmdBuf.Buffer);
                        list.ModBrandSettings.Add(modBrandSetting);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME:

                        var modChatRoomMemberDisplayName = Util.Deserialize<micromsg.ModChatRoomMemberDisplayName>(r.CmdBuf.Buffer);
                        list.ModChatRoomMemberDisplayNames.Add(modChatRoomMemberDisplayName);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODCHATROOMMEMBERFLAG:

                        var modChatRoomMemberFlag = Util.Deserialize<micromsg.ModChatRoomMemberFlag>(r.CmdBuf.Buffer);
                        list.ModChatRoomMemberFlags.Add(modChatRoomMemberFlag);
                        break;
                    case SyncCmdID.MM_SYNCCMD_WEBWXFUNCTIONSWITCH:

                        var webWxFunctionSwitch = Util.Deserialize<micromsg.WebWxFunctionSwitch>(r.CmdBuf.Buffer);
                        list.WebWxFunctionSwitchs.Add(webWxFunctionSwitch);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODSNSUSERINFO:

                        //Util.Deserialize<micromsg>(r.CmdBuf.Buffer);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODSNSBLACKLIST:
                        var modSnsBlackList = Util.Deserialize<micromsg.ModSnsBlackList>(r.CmdBuf.Buffer);
                        list.ModSnsBlackLists.Add(modSnsBlackList);
                        break;
                    case SyncCmdID.MM_SYNCCMD_NEWDELMSG:

                        var newDelMsg = Util.Deserialize<micromsg.NewDelMsg>(r.CmdBuf.Buffer);
                        list.NewDelMsgs.Add(newDelMsg);
                        break;
                    case SyncCmdID.MM_SYNCCMD_MODDESCRIPTION:

                        var modDescription = Util.Deserialize<micromsg.ModDescription>(r.CmdBuf.Buffer);
                        list.ModDescriptions.Add(modDescription);
                        break;
                    case SyncCmdID.MM_SYNCCMD_KVCMD:

                        var kVCmd = Util.Deserialize<micromsg.KVCmd>(r.CmdBuf.Buffer);
                        list.KVCmds.Add(kVCmd);
                        break;
                    case SyncCmdID.MM_SYNCCMD_DELETE_SNS_OLDGROUP:

                        var deleteSnsOldGroup = Util.Deserialize<micromsg.DeleteSnsOldGroup>(r.CmdBuf.Buffer);
                        list.DeleteSnsOldGroups.Add(deleteSnsOldGroup);
                        break;
                    case SyncCmdID.MM_FAV_SYNCCMD_ADDITEM:

                        //Util.Deserialize<micromsg>(r.CmdBuf.Buffer);
                        break;
                    case SyncCmdID.CmdIdMax:

                        //Util.Deserialize<micromsg>(r.CmdBuf.Buffer);
                        break;


                }



            }
            return new Tuple<InitResponse, string, uint>(list, initResponse.Buffer.String, initResponse.NewSyncKey);
        }





        public micromsg.SyncFriendResponse SyncFriend(string wxId, int syncKey = 0)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SyncFriendRequest syncFriendRequest = new micromsg.SyncFriendRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                UserName = new micromsg.SKBuiltinString_t() { String = wxId },
                SyncKey = (uint)syncKey,
                Scene = 0,
            };

            var RespProtobuf = new byte[0];

            var src = Util.Serialize(syncFriendRequest);
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 0x88, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/syncfriend", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var syncFriendResponse = Util.Deserialize<micromsg.SyncFriendResponse>(RespProtobuf);

            return syncFriendResponse;
        }

        /// <summary>
        /// 邀请群成员
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="chatRoom"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public micromsg.InviteChatRoomMemberResponse InviteChatRoomMember(string wxId, string chatRoom, IList<string> members)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            List<micromsg.MemberReq> list = new List<micromsg.MemberReq>();
            foreach (var item in members)
            {
                micromsg.MemberReq memberReq = new micromsg.MemberReq()
                {
                    MemberName = new micromsg.SKBuiltinString_t() { String = item }
                };
                list.Add(memberReq);
            }

            micromsg.InviteChatRoomMemberRequest syncFriendRequest = new micromsg.InviteChatRoomMemberRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                MemberCount = (uint)members.Count,

                ChatRoomName = new micromsg.SKBuiltinString_t() { String = chatRoom },
            };

            syncFriendRequest.MemberList.AddRange(list);

            var RespProtobuf = new byte[0];

            var src = Util.Serialize(syncFriendRequest);
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 610, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/invitechatroommember", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var inviteChatRoomMemberResponse = Util.Deserialize<micromsg.InviteChatRoomMemberResponse>(RespProtobuf);

            return inviteChatRoomMemberResponse;
        }
        /// <summary>
        /// 获取好友简介
        /// </summary>
        /// <param name="name">微信wxid</param>
        /// <returns></returns>
        public GetProfileResponse GetContractProfile(string wxId, string toWxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            GetProfileRequest profileRequest = new GetProfileRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                userName = toWxId
            };
            byte[] RespProtobuf = null;
            var src = Util.Serialize(profileRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETPROFILE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETPROFILE, customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var profileResponse = Util.Deserialize<GetProfileResponse>(RespProtobuf);
            return profileResponse;
        }





        /// <summary>
        /// 批量获取好友简介
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="toWxIds"></param>
        /// <returns></returns>
        public IList<micromsg.ContactProfile> BatchGetContractProfile(string wxId, IList<string> toWxIds, int mode = 2)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int count = toWxIds.Count;
            List<micromsg.SKBuiltinString_t> list = new List<micromsg.SKBuiltinString_t>();
            foreach (var item in toWxIds)
            {
                micromsg.SKBuiltinString_t sKBuiltinString_T = new micromsg.SKBuiltinString_t()
                {
                    String = item
                };
                list.Add(sKBuiltinString_T);

            }
           
            micromsg.BatchGetContactProfileRequest batchGetProfileReq = new micromsg.BatchGetContactProfileRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Mode = (uint)mode,
                Count = (uint)count,
                //UserNameList = list
            };

            batchGetProfileReq.UserNameList.AddRange(list);
            byte[] RespProtobuf = null;
            var src = Util.Serialize(batchGetProfileReq);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)0x1c, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/batchgetcontactprofile", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            IList<micromsg.ContactProfile> result = new List<micromsg.ContactProfile>();
            var profileResponse = Util.Deserialize<micromsg.BatchGetContactProfileResponse>(RespProtobuf);
            if (profileResponse?.BaseResponse?.Ret == 0)
            {
                foreach (var item in profileResponse.ContactProfileBufList)
                {
                    var contactProfile = Util.Deserialize<micromsg.ContactProfile>(item.Buffer);
                    result.Add(contactProfile);
                }
            }
            return result;
        }
        public micromsg.GetFSUrlResponse GetFsUrl(string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.GetFSUrlRequest batchGetHeadImgRequest = new micromsg.GetFSUrlRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },

            };
            byte[] RespProtobuf = null;
            var src = Util.Serialize(batchGetHeadImgRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)15, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/getfsurl", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var fSUrlResponse = Util.Deserialize<micromsg.GetFSUrlResponse>(RespProtobuf);

            return fSUrlResponse;
        }

        public IList<micromsg.ImgPair> BatchGetHeadImg(string wxId, IList<string> toWxIds)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int count = toWxIds.Count;
            List<micromsg.SKBuiltinString_t> list = new List<micromsg.SKBuiltinString_t>();
            foreach (var item in toWxIds)
            {
                micromsg.SKBuiltinString_t sKBuiltinString_T = new micromsg.SKBuiltinString_t()
                {
                    String = item
                };
                list.Add(sKBuiltinString_T);

            }
            micromsg.BatchGetHeadImgRequest batchGetHeadImgRequest = new micromsg.BatchGetHeadImgRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Count = (uint)count,
                //UserNameList = list
            };

            batchGetHeadImgRequest.UserNameList.AddRange(list);
            byte[] RespProtobuf = null;
            var src = Util.Serialize(batchGetHeadImgRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)15, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/batchgetheadimg", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            IList<micromsg.ImgPair> result = new List<micromsg.ImgPair>();
            var batchGetHeadImgResponse = Util.Deserialize<micromsg.BatchGetHeadImgResponse>(RespProtobuf);
            if (batchGetHeadImgResponse?.BaseResponse?.Ret == 0)
            {
                result = batchGetHeadImgResponse.ImgPairList;
            }
            return result;
        }


        /// <summary>
        /// 获取个人二维码或群二维码
        /// </summary>
        /// <param name="name">微信wxid</param>
        /// <returns></returns>
        public micromsg.GetQRCodeResponse GetMyQRCode(string wxId, string toWxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            var RespProtobuf = new byte[0];
            SKBuiltinString skb = new SKBuiltinString();
            skb.@string = toWxId;
            SKBuiltinString[] skb_ = new SKBuiltinString[1];
            skb_[0] = skb;
            GetQRCodeRequest getqrcode = new GetQRCodeRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                opcode = 0,
                style = (uint)0,
                userName = skb_
            };
            var src = Util.Serialize(getqrcode);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETQRCODE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETQRCODE, customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var GetQRcode = Util.Deserialize<micromsg.GetQRCodeResponse>(RespProtobuf);
            return GetQRcode;
        }
        /// <summary>
        /// 发送登陆包
        /// </summary>
        /// <param name="customerInfoCache"></param>
        /// <param name="count"></param>
        private ManualAuthResponse checkManualAuth(CustomerInfoCache customerInfoCache, int count = 1)
        {

            var manualAuth = ManualAuth(customerInfoCache);
            if (manualAuth.dnsInfo?.newHostList?.list?.Count() > 1)
            {
                customerInfoCache.HostUrl = "http://" + manualAuth.dnsInfo.newHostList.list[1].substitute;
            }
            else
            {
                customerInfoCache.HostUrl = Util.shortUrl;
            }

            //-301重定向         
            if (manualAuth.baseResponse.ret == MMPro.MM.RetConst.MM_ERR_IDC_REDIRECT)
            {
                //Console.WriteLine(ManualAuth.dnsInfo.builtinIplist.shortConnectIplist[0].ip);
                //byte[] s = Util.Serialize<MM.BuiltinIP>(ManualAuth.dnsInfo.builtinIplist.shortConnectIplist.shortConnectIplist[1]);
                int len = (int)manualAuth.dnsInfo.builtinIplist.shortconnectIpcount;

                //Util.shortUrl = "http://" + manualAuth.dnsInfo.newHostList.list[1].substitute;

                if (count > 5)
                {
                    customerInfoCache.State = -1;
                    return manualAuth;
                }
                count++;
                Thread.Sleep(count * 200);
                return checkManualAuth(customerInfoCache, count);

            }
            else if (manualAuth.baseResponse.ret == MMPro.MM.RetConst.MM_OK)
            {
                customerInfoCache.WxId = manualAuth.accountInfo.wxid;

                byte[] strECServrPubKey = manualAuth.authParam.ecdh.ecdhkey.key;
                byte[] aesKey = new byte[16];
                ComputerECCKeyMD5(strECServrPubKey, 57, customerInfoCache.PriKeyBuf, 328, aesKey);
                //var aesKey = OpenSSLNativeClass.ECDH.DoEcdh(ManualAuth.authParam.ecdh.nid, strECServrPubKey, wechat.pri_key_buf);
                //wechat.CheckEcdh = aesKey.ToString(16, 2);
                customerInfoCache.AesKey = AES.AESDecrypt(manualAuth.authParam.session.key, aesKey).ToString(16, 2).ToByteArray(16, 2);

                //var baseRequest = GetBaseRequest(customerInfoCache.DeviceId, customerInfoCache.AesKey, (uint)customerInfoCache.MUid, phoneOsType, version);
                customerInfoCache.BaseRequest = new CustomerInfoCache.BaseRequestCache()
                {
                    sessionKey = customerInfoCache.AesKey,
                    uin = customerInfoCache.MUid,
                    devicelId = customerInfoCache.DeviceId,
                    clientVersion = version,
                    osType = phoneOsType,
                    scene = 0
                };
                customerInfoCache.BindEmail = manualAuth.accountInfo.bindMail;
                customerInfoCache.BindMobile = manualAuth.accountInfo.bindMobile;
                customerInfoCache.DeviceInfoXml = manualAuth.accountInfo.deviceInfoXml;
                customerInfoCache.Alias = manualAuth.accountInfo.Alias;

                customerInfoCache.AuthKey = manualAuth.authParam.authKey;
                customerInfoCache.AuthTicket = manualAuth.authParam.authTicket;
                customerInfoCache.AutoAuthTicket = manualAuth.authParam.autoAuthKey.buffer;
            }
            else if ((int)manualAuth.baseResponse.ret == 2)
            {
                customerInfoCache.WxId = manualAuth.accountInfo.wxid;

            }
            else
            {
                throw new Exception(manualAuth.baseResponse.errMsg.@string);
            }
            return manualAuth;
        }



        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="passwd">明文密码</param>
        /// <returns></returns>
        public micromsg.NewVerifyPasswdResponse NewVerifyPasswd(string wxId, string passwd)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.NewVerifyPasswdRequest newVerifyPasswd = new micromsg.NewVerifyPasswdRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Pwd1 = Util.MD5Encrypt(passwd),
                Pwd2 = Util.MD5Encrypt(passwd),
                OpCode = 1,
            };

            var RespProtobuf = new byte[0];

            var src = Util.Serialize(newVerifyPasswd);
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 384, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/newverifypasswd", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var NewVerifyPasswdResponse = Util.Deserialize<micromsg.NewVerifyPasswdResponse>(RespProtobuf);

            return NewVerifyPasswdResponse;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="NewPasswd"></param>
        /// <param name="Ticket"></param>
        /// <param name="authKey"></param>
        /// <returns></returns>
        public micromsg.NewSetPasswdResponse NewSetPasswd(string wxId, string NewPasswd, string ticket)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SetPwdRequest newSetPasswdRequest = new micromsg.SetPwdRequest()
            {
                AutoAuthKey = new micromsg.SKBuiltinBuffer_t()
                {
                    Buffer = customerInfoCache.AutoAuthTicket,
                    iLen = (uint)customerInfoCache.AutoAuthTicket.Length
                },
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Password = Util.EncryptWithMD5(NewPasswd),
                Ticket = ticket,
            };

            var RespProtobuf = new byte[0];

            //newSetPasswd.BaseRequest.Scene = 0;
            var src = Util.Serialize(newSetPasswdRequest);
            src = src.Concat("2801".ToByteArray(16, 2)).ToArray();

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 383, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/newsetpasswd", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var SetPwdResponse = Util.Deserialize<micromsg.NewSetPasswdResponse>(RespProtobuf);
            if (SetPwdResponse != null && SetPwdResponse.BaseResponse.Ret == (int)MMPro.MM.RetConst.MM_OK)
            {
                customerInfoCache.AutoAuthTicket = SetPwdResponse.AutoAuthKey.Buffer;
                cache.HashSet(ConstCacheKey.GetWxIdKey(), wxId, customerInfoCache);
            }
            return SetPwdResponse;
        }



        /// <summary>
        /// 查询设备
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="hardDeviceQRCode"></param>
        /// <returns></returns>
        public micromsg.SearchHardDeviceResponse SearchHardDevice(string wxId, string hardDeviceQRCode)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SearchHardDeviceRequest searchHardDeviceRequest = new micromsg.SearchHardDeviceRequest()
            {

                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                HardDeviceQRCode = hardDeviceQRCode

            };

            var RespProtobuf = new byte[0];

            //newSetPasswd.BaseRequest.Scene = 0;
            var src = Util.Serialize(searchHardDeviceRequest);

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 540, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/searchharddevice", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var searchHardDeviceResponse = Util.Deserialize<micromsg.SearchHardDeviceResponse>(RespProtobuf);

            return searchHardDeviceResponse;
        }



        /// <summary>
        /// 删除安全设备
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public micromsg.DelSafeDeviceResponse DelSafeDevice(string wxId, string uuid)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.DelSafeDeviceRequest searchHardDeviceRequest = new micromsg.DelSafeDeviceRequest()
            {

                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Uuid = uuid

            };

            var RespProtobuf = new byte[0];

            //newSetPasswd.BaseRequest.Scene = 0;
            var src = Util.Serialize(searchHardDeviceRequest);

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 0x16a, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/delsafedevice", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var delSafeDeviceResponse = Util.Deserialize<micromsg.DelSafeDeviceResponse>(RespProtobuf);

            return delSafeDeviceResponse;
        }


        /// <summary>
        /// 二维码重新登陆(不可用)
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public PushLoginURLResponse TwiceQrCodeLogin(string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            PushLoginURLRequest pushLoginURLRequest = new PushLoginURLRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                Autoauthkey = new SKBuiltinString_()
                {
                    buffer = customerInfoCache.AutoAuthTicket,
                    iLen = (uint)customerInfoCache.AutoAuthTicket.Length
                },
                //Autoauthticket = "",
                ClientId = CurrentTime_().ToString(),
                Devicename = customerInfoCache.Device,
                opcode = 1,
                randomEncryKey = new AesKey()
                {
                    key = customerInfoCache.AesKey,
                    len = customerInfoCache.AesKey.Length
                },
                username = wxId,
                rsa = new RSAPem()
                {

                }
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(pushLoginURLRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_PUSHLOGINURL, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 1, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_PUSHLOGINURL, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var pushLoginURLResponse = Util.Deserialize<PushLoginURLResponse>(RespProtobuf);
            return pushLoginURLResponse;
        }



        /// <summary>
        /// 创建群
        /// </summary>
        /// <param name="list">要添加进来的好友第一个必须是自己的wxid</param>
        /// <param name="topic">群名</param>
        /// <returns></returns>
        public CreateChatRoomResponese CreateChatRoom(string wxId, MemberReq[] list, string topic = "")
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString topic_ = new SKBuiltinString();
            topic_.@string = topic;
            CreateChatRoomRequest createChatRoom_ = new CreateChatRoomRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                scene = 0,
                topic = topic_,
                memberCount = (uint)list.Length,
                memberList = list
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(createChatRoom_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_CREATECHATROOM, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_CREATECHATROOM, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var CreateChatRoomResponse_ = Util.Deserialize<CreateChatRoomResponese>(RespProtobuf);
            return CreateChatRoomResponse_;
        }


        //public AddChatRoomMemberResponse HongBao(string wxId, int cgiCmd, int outPutType, string reqUrl)
        //{

        //    var cache = this._redisCache;
        //    var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
        //    if (customerInfoCache == null)
        //    {
        //        throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
        //    }
        //    HongBaoRequest hongBaoRequest = new HongBaoRequest()
        //    {
        //        baseRequest = new BaseRequest()
        //        {
        //            sessionKey = customerInfoCache.BaseRequest.sessionKey,
        //            uin = customerInfoCache.BaseRequest.uin,
        //            devicelId = customerInfoCache.BaseRequest.devicelId,
        //            clientVersion = customerInfoCache.BaseRequest.clientVersion,
        //            osType = customerInfoCache.BaseRequest.osType,
        //            scene = customerInfoCache.BaseRequest.scene
        //        },
        //        outPutType = (uint)outPutType,
        //        cgiCmd = cgiCmd,
        //        reqText = reqUrl

        //    }

        //    AddChatRoomMemberRequest addChat = new AddChatRoomMemberRequest()
        //    {
        //        baseRequest = new BaseRequest()
        //        {
        //            sessionKey = customerInfoCache.BaseRequest.sessionKey,
        //            uin = customerInfoCache.BaseRequest.uin,
        //            devicelId = customerInfoCache.BaseRequest.devicelId,
        //            clientVersion = customerInfoCache.BaseRequest.clientVersion,
        //            osType = customerInfoCache.BaseRequest.osType,
        //            scene = customerInfoCache.BaseRequest.scene
        //        },
        //        chatRoomName = chatRoomName_,
        //        memberCount = (uint)list.Count(),
        //        memberList = list
        //    };
        //    int mUid = 0;
        //    string cookie = null;
        //    var src = Util.Serialize(addChat);
        //    int bufferlen = src.Length;
        //    //组包
        //    byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_ADDCHATROOMMEMBER, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
        //    //发包
        //    byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl,SendDate, URL.CGI_ADDCHATROOMMEMBER, customerInfoCache.Proxy);
        //    if (RetDate.Length > 32)
        //    {
        //        var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
        //        //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
        //        RespProtobuf = packinfo.body;
        //        if (packinfo.m_bCompressed)
        //        {
        //            RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
        //        }
        //        else
        //        {
        //            RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
        //        }

        //    }
        //    else
        //    {
        //        throw new ExpiredException("用户可能退出,请重新登陆");
        //    }

        //    var AddChatRoomMemberResponse_ = Util.Deserialize<AddChatRoomMemberResponse>(RespProtobuf);
        //    return AddChatRoomMemberResponse_;

        //}

        /// <summary>
        /// 邀请好友
        /// </summary>
        /// <param name="chatRoomName">群id</param>
        /// <param name="list">要邀请的联系人["xxxx","xxxx1","xxxx2"]</param>
        /// <returns></returns>
        public AddChatRoomMemberResponse AddChatRoomMember(string wxId, string chatRoomName, MemberReq[] list)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            SKBuiltinString chatRoomName_ = new SKBuiltinString();
            chatRoomName_.@string = chatRoomName;
            byte[] RespProtobuf = new byte[0];

            AddChatRoomMemberRequest addChat = new AddChatRoomMemberRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                chatRoomName = chatRoomName_,
                memberCount = (uint)list.Count(),
                memberList = list
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(addChat);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_ADDCHATROOMMEMBER, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_ADDCHATROOMMEMBER, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var AddChatRoomMemberResponse_ = Util.Deserialize<AddChatRoomMemberResponse>(RespProtobuf);
            return AddChatRoomMemberResponse_;

        }

        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="chatRoomName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public DelChatRoomMemberResponse DelChatRoomMember(string wxId, string chatRoomName, DelMemberReq[] list)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];

            DelChatRoomMemberRequest addChat = new DelChatRoomMemberRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                chatRoomName = chatRoomName,
                memberCount = (uint)list.Count(),
                memberList = list
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(addChat);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_DELCHATROOMMEMBER, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_DELCHATROOMMEMBER, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var DelChatRoomMemberResponse_ = Util.Deserialize<DelChatRoomMemberResponse>(RespProtobuf);
            return DelChatRoomMemberResponse_;

        }



        /// <summary>
        /// 获取群详情
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="chatroomUserName"></param>
        /// <returns></returns>
        public GetChatRoomInfoDetailResponse GetChatRoomInfoDetail(string wxId, string chatroomUserName)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            GetChatRoomInfoDetailRequest getChatroomMember_ = new GetChatRoomInfoDetailRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                chatRoomName = chatroomUserName,
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(getChatroomMember_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETCHATROOMINFODETAIL, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETCHATROOMINFODETAIL, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var chatRoomInfoDetailRequest = Util.Deserialize<GetChatRoomInfoDetailResponse>(RespProtobuf);
            return chatRoomInfoDetailRequest;
        }

        /// <summary>
        /// 取群成员详细
        /// </summary>
        /// <param name="chatroomUserName">群id</param>
        /// <returns></returns>
        public GetChatroomMemberDetailResponse GetChatroomMemberDetail(string wxId, string chatroomUserName)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            GetChatroomMemberDetailRequest getChatroomMember_ = new GetChatroomMemberDetailRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                clientVersion = (uint)0,
                chatroomUserName = chatroomUserName,
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(getChatroomMember_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETCHATROOMMEMBERDETAIL, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETCHATROOMMEMBERDETAIL, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var GetChatroomMemberDetailResponse_ = Util.Deserialize<GetChatroomMemberDetailResponse>(RespProtobuf);
            return GetChatroomMemberDetailResponse_;
        }

        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="chatroomUserName"></param>
        /// <returns></returns>
        public micromsg.QuitChatRoomResp QuitGroup(string wxId, string chatroomUserName)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            micromsg.QuitChatRoomReq quitChatRoomReq = new micromsg.QuitChatRoomReq()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                ChatRoomName = chatroomUserName,
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(quitChatRoomReq);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 16, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/quitchatroom", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var quitChatRoomResp = Util.Deserialize<micromsg.QuitChatRoomResp>(RespProtobuf);
            return quitChatRoomResp;
        }


        /// <summary>
        /// 验证身份证
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="userRealName"></param>
        /// <param name="idcardTpye"></param>
        /// <param name="idCardnumber"></param>
        /// <returns></returns>
        public micromsg.VerifyPersonalInfoResp VerifyPersonalInfo(string wxId, string userRealName, int idcardTpye, string idCardnumber)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];

            micromsg.VerifyPersonalInfoReq verifyPersonalInfoReq = new micromsg.VerifyPersonalInfoReq()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                UserRealName = userRealName,
                UserIDCardType = (uint)idcardTpye,
                UserIDCardNum = idCardnumber
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(verifyPersonalInfoReq);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 460, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/verifypersonalinfo", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var verifyPersonalInfoResp = Util.Deserialize<micromsg.VerifyPersonalInfoResp>(RespProtobuf);
            return verifyPersonalInfoResp;
        }


        /// <summary>
        /// 获取群公告
        /// </summary>
        /// <param name="ChatRoomName">群wxid</param>
        /// <returns></returns>
        public micromsg.GetChatRoomAnnouncementResponse getChatRoomAnnouncement(string wxId, string ChatRoomName)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.GetChatRoomAnnouncementRequest getChatRoomAnnouncementRequest = new micromsg.GetChatRoomAnnouncementRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                ChatRoomName = ChatRoomName
            };

            var src = Util.Serialize(getChatRoomAnnouncementRequest);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)1, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/getchatroomannouncement", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var getChatRoomAnnouncementResponse = Util.Deserialize<micromsg.GetChatRoomAnnouncementResponse>(RespProtobuf);
            return getChatRoomAnnouncementResponse;
        }

        /// <summary>
        /// 发送群公告
        /// </summary>
        /// <param name="ChatRoomName">群wxid</param>
        /// <param name="Announcement">公告内容</param>
        /// <returns></returns>
        public micromsg.SetChatRoomAnnouncementResponse setChatRoomAnnouncement(string wxId, string ChatRoomName, string Announcement)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SetChatRoomAnnouncementRequest setChatRoomAnnouncement_ = new micromsg.SetChatRoomAnnouncementRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Announcement = Announcement,
                ChatRoomName = ChatRoomName
            };

            var src = Util.Serialize(setChatRoomAnnouncement_);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_SETCHATROOMANNOUNCEMENT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/setchatroomannouncement", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var SetChatRoomAnnouncementResponse_ = Util.Deserialize<micromsg.SetChatRoomAnnouncementResponse>(RespProtobuf);
            return SetChatRoomAnnouncementResponse_;
        }

        /// <summary>
        /// 移交群管理
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="ChatRoomName"></param>
        /// <param name="toWxId"></param>
        /// <returns></returns>
        public micromsg.TransferChatRoomOwnerResponse transferChatRoomOwner(string wxId, string ChatRoomName, string toWxId)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.TransferChatRoomOwnerRequest transferChatRoomOwnerRequest = new micromsg.TransferChatRoomOwnerRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                NewOwnerUserName = toWxId,
                ChatRoomName = ChatRoomName
            };

            var src = Util.Serialize(transferChatRoomOwnerRequest);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)1, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/transferchatroomowner", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var transferChatRoomOwnerResponse = Util.Deserialize<micromsg.TransferChatRoomOwnerResponse>(RespProtobuf);
            return transferChatRoomOwnerResponse;
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public micromsg.LogOutResponse logOut(string wxId)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.LogOutRequest logOut_ = new micromsg.LogOutRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Scene = 0,
            };

            var src = Util.Serialize(logOut_);

            byte[] RespProtobuf = new byte[0];


            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 282, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/logout", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var LogOutResponse_ = Util.Deserialize<micromsg.LogOutResponse>(RespProtobuf);
            return LogOutResponse_;
        }

        /// <summary>
        /// 精准获取通讯录  
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public InitContactResponse InitContact(string wxId, int currentWxcontactSeq = 0, int currentChatRoomContactSeq = 0)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            InitContactRequest initContact_ = new InitContactRequest()
            {
                currentChatRoomContactSeq = currentChatRoomContactSeq,
                currentWxcontactSeq = currentWxcontactSeq,
                username = wxId,
            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(initContact_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_INITCONTACT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_INITCONTACT, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var InitContactResponse_ = Util.Deserialize<InitContactResponse>(RespProtobuf);
            return InitContactResponse_;
        }



        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="ChatRoom"></param>
        /// <returns></returns>
        public micromsg.GetContactResponse GetContactDetail(string wxId, IList<string> searchWxIds, string ChatRoom = "")
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];



            micromsg.GetContactRequest getContact_a = new micromsg.GetContactRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            getContact_a.UserCount = (uint)searchWxIds.Count;
            foreach (var item in searchWxIds)
            {
                micromsg.SKBuiltinString_t UserName_ = new micromsg.SKBuiltinString_t();
                UserName_.String = item;

                getContact_a.UserNameList.Add(UserName_);
            }



            if (ChatRoom != "")
            {
                micromsg.SKBuiltinString_t ChatRoom_ = new micromsg.SKBuiltinString_t();
                ChatRoom_.String = ChatRoom;

                getContact_a.FromChatRoomCount = 1;
                getContact_a.FromChatRoom.Add(ChatRoom_);
            }

            var src = Util.Serialize(getContact_a);
            int mUid = 0;
            string cookie = null;

            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETCONTACT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETCONTACT, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var GetContactResponse_ = Util.Deserialize<micromsg.GetContactResponse>(RespProtobuf);
            return GetContactResponse_;
        }


        /// <summary>
        /// 附近的人
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="latitude"></param>
        /// <param name="logitude"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public LbsResponse LbsLBSFind(string wxId, float latitude, float logitude, int type = 1)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            LbsRequest lbs = new LbsRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                gPSSource = 0,
                latitude = latitude,
                logitude = logitude,
                opCode = (uint)type,
                precision = 65,
            };

            var src = Util.Serialize(lbs);
            int mUid = 0;
            string cookie = null;

            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_LBSFIND, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);

            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_LBSFIND, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {

                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);


                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var LbsResponse_ = Util.Deserialize<LbsResponse>(RespProtobuf);
            return LbsResponse_;
        }


        /// <summary>
        /// 搜索联系人
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SearchContactResponse SearchContact(string wxId, string userName)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString userName_ = new SKBuiltinString();
            userName_.@string = userName;
            SearchContactRequest searchContact = new SearchContactRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                searchScene = (uint)1,
                opCode = (uint)0,
                fromScene = (uint)1,
                userName = userName_,


            };
            var src = Util.Serialize(searchContact);
            int bufferlen = src.Length;
            int mUid = 0;
            string cookie = null;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_SEARCHCONTACT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_SEARCHCONTACT, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var SearchContactResponse_ = Util.Deserialize<SearchContactResponse>(RespProtobuf);
            return SearchContactResponse_;
        }


        /// <summary>
        /// 授权连接
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="url"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public micromsg.GetA8KeyResp GetA8Key(string wxId, string username, string url, int opcode = 2)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }



            byte[] RespProtobuf = new byte[0];
            SKBuiltinString requrl_ = new SKBuiltinString();
            requrl_.@string = url;
            GetA8KeyRequest getA8Key_ = new GetA8KeyRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = (uint)100,
                netType = "WIFI",
                opCode = (uint)opcode,
                userName = username,
                reqUrl = requrl_,
                friendQQ = 0,

            };

            var src = Util.Serialize(getA8Key_);
            int bufferlen = src.Length;
            //组包

            int mUid = 0;
            string cookie = null;
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETA8KEY, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/mp-geta8key", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var getA8KeyResponse_ = Util.Deserialize<micromsg.GetA8KeyResp>(RespProtobuf);

            return getA8KeyResponse_;
        }


        public string GetA8KeyRead(string wxId, string username, string url, int opcode = 2)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString requrl_ = new SKBuiltinString();
            requrl_.@string = url;
            GetA8KeyRequest getA8Key_ = new GetA8KeyRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = (uint)100,
                netType = "WIFI",
                opCode = (uint)opcode,
                userName = username,
                reqUrl = requrl_,
                friendQQ = 0,
                //scene = 37,
            };

            var src = Util.Serialize(getA8Key_);
            int bufferlen = src.Length;
            //组包

            int mUid = 0;
            string cookie = null;
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETA8KEY, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/geta8key", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var a8KeyResponse_ = Util.Deserialize<micromsg.GetA8KeyResp>(RespProtobuf);
            if (!string.IsNullOrEmpty(a8KeyResponse_.FullURL))
            {
                var result = HttpGetRead(a8KeyResponse_.FullURL, a8KeyResponse_.HttpHeader);

                Regex reg = new Regex("wxuin=(.+);");
                Match match = reg.Match(result.Cookie);
                string wxuin = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("devicetype=(.+);");
                match = reg.Match(result.Cookie);
                string devicetype = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("version=(.+);");
                match = reg.Match(result.Cookie);
                string version = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("pass_ticket=(.+);");
                match = reg.Match(result.Cookie);
                string pass_ticket = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("lang=(.+);");
                match = reg.Match(result.Cookie);
                string lang = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("window.appmsg_token = \"(.+)\";");
                match = reg.Match(result.Html);
                string appmsg_token = match.Groups[1].Value;

                reg = new Regex("var msg_title = \"(.+)\";");
                match = reg.Match(result.Html);
                string msg_title = match.Groups[1].Value;


                reg = new Regex("var comment_id = \"(.+)\"");
                match = reg.Match(result.Html);
                string comment_id = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var biz = \"(.+)\"");
                match = reg.Match(result.Html);
                string biz = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var mid = \"(.+)\"");
                match = reg.Match(result.Html);
                string mid = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var sn = \"(.+)\"");
                match = reg.Match(result.Html);
                string sn = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

                reg = new Regex("var ct = \"(.+)\"");
                match = reg.Match(result.Html);
                string ct = match.Groups[1].Value;

                reg = new Regex("var user_name = \"(.+)\"");
                match = reg.Match(result.Html);
                string user_name = match.Groups[1].Value;

                //if (!string.IsNullOrEmpty(user_name))
                //{
                //    VerifyUser(wxId, MMPro.MM.VerifyUserOpCode.MM_VERIFYUSER_ADDCONTACT, "", "", user_name, 0);
                //}

                reg = new Regex("var appmsg_type = \"(.+)\"");
                match = reg.Match(result.Html);
                string appmsg_type = match.Groups[1].Value;

                string appMsgUrl = $"https://mp.weixin.qq.com/mp/getappmsgext?f=json&mock=&fasttmplajax=1&f=json&wx_header=1&pass_ticket={pass_ticket}";
                var random = new Random().Next(100000000, 999999999);
                string postData = $"r=0.36105416{random}&__biz={biz}&appmsg_type={appmsg_type}&mid={mid}&sn={sn}&idx=1&scene=0&title={msg_title}&ct={ct}&abtest_cookie=&devicetype={devicetype}&version={version}&is_need_ticket=0&is_need_ad=0&comment_id={comment_id}&is_need_reward=0&both_ad=0&reward_uin_count=0&send_time=&msg_daily_idx=0&is_original=0&is_only_read=1&req_id=&pass_ticket={pass_ticket}&is_temp_url=0&item_show_type=0&tmp_version=1&more_read_type=0&appmsg_like_type=2";



                var result1 = HttpPostRead(appMsgUrl, a8KeyResponse_.HttpHeader, result.Cookie, postData);
                return $"{result1.Html}|{user_name}|{msg_title}";


            }

            return null;

        }



        public string GetA8KeyLike(string wxId, string username, string url, int opcode = 2)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString requrl_ = new SKBuiltinString();
            requrl_.@string = url;
            GetA8KeyRequest getA8Key_ = new GetA8KeyRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = (uint)100,
                netType = "WIFI",
                opCode = (uint)opcode,
                userName = username,
                reqUrl = requrl_,
                friendQQ = 0,
                //scene = 37,
            };

            var src = Util.Serialize(getA8Key_);
            int bufferlen = src.Length;
            //组包

            int mUid = 0;
            string cookie = null;
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETA8KEY, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/geta8key", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var a8KeyResponse_ = Util.Deserialize<micromsg.GetA8KeyResp>(RespProtobuf);
            if (!string.IsNullOrEmpty(a8KeyResponse_.FullURL))
            {
                var result = HttpGetRead(a8KeyResponse_.FullURL, a8KeyResponse_.HttpHeader);

                Regex reg = new Regex("wxuin=(.+);");
                Match match = reg.Match(result.Cookie);
                string wxuin = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("devicetype=(.+);");
                match = reg.Match(result.Cookie);
                string devicetype = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("version=(.+);");
                match = reg.Match(result.Cookie);
                string version = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("pass_ticket=(.+);");
                match = reg.Match(result.Cookie);
                string pass_ticket = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("lang=(.+);");
                match = reg.Match(result.Cookie);
                string lang = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf(';'));

                reg = new Regex("window.appmsg_token = \"(.+)\";");
                match = reg.Match(result.Html);
                string appmsg_token = match.Groups[1].Value;

                reg = new Regex("var msg_title = \"(.+)\";");
                match = reg.Match(result.Html);
                string msg_title = match.Groups[1].Value;


                reg = new Regex("var comment_id = \"(.+)\"");
                match = reg.Match(result.Html);
                string comment_id = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var biz = \"(.+)\"");
                match = reg.Match(result.Html);
                string biz = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var mid = \"(.+)\"");
                match = reg.Match(result.Html);
                string mid = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));


                reg = new Regex("var sn = \"(.+)\"");
                match = reg.Match(result.Html);
                string sn = match.Groups[1].Value.Substring(0, match.Groups[1].Value.IndexOf('\"'));

                reg = new Regex("var ct = \"(.+)\"");
                match = reg.Match(result.Html);
                string ct = match.Groups[1].Value;

                reg = new Regex("var user_name = \"(.+)\"");
                match = reg.Match(result.Html);
                string user_name = match.Groups[1].Value;

                string appmsgid = null;
                reg = new Regex("var appmsgid = '(.*)' \\|\\| '(.*)'\\|\\| \"(.*)\"");
                match = reg.Match(result.Html);
                if (match.Groups.Count >= 2 && !string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    appmsgid = match.Groups[1].Value;
                }
                else if (match.Groups.Count >= 3 && !string.IsNullOrEmpty(match.Groups[2].Value))
                {
                    appmsgid = match.Groups[2].Value;
                }
                else if (match.Groups.Count >= 4 && !string.IsNullOrEmpty(match.Groups[3].Value))
                {
                    appmsgid = match.Groups[3].Value;
                }



                //if (!string.IsNullOrEmpty(user_name))
                //{
                //    VerifyUser(wxId, MMPro.MM.VerifyUserOpCode.MM_VERIFYUSER_ADDCONTACT, "", "", user_name, 0);
                //}

                reg = new Regex("var appmsg_type = \"(.+)\"");
                match = reg.Match(result.Html);
                string appmsg_type = match.Groups[1].Value;

                string appMsgUrl = $"https://mp.weixin.qq.com/mp/appmsg_like?__biz={biz}&mid={mid}&idx=1&like=1&f=json&appmsgid={appmsgid}&itemidx=1&fasttmplajax=1&f=json&wx_header=1&pass_ticket={pass_ticket}";
                var random = new Random().Next(100000000, 999999999);
                string postData = $"is_temp_url=0&scene=90&subscene=93&appmsg_like_type=2&item_show_type=0&client_version=1700042d&comment=&prompted=1&style=2&action_type=1&passparam=&request_id={(DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000}&device_type=iOS12.3.1";



                var result1 = HttpPostRead(appMsgUrl, a8KeyResponse_.HttpHeader, result.Cookie, postData);
                return $"{result1.Html}|{user_name}|{msg_title}";


            }

            return null;

        }
        public static HttpResult HttpGetRead(string GroupUrl, List<micromsg.HTTPHeader> headers = null)
        {

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = GroupUrl,
                Method = "get",
                PostDataType = PostDataType.Byte,
                //UserAgent = "MicroMessenger Client",
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/7.0.4(0x17000428) NetType/4G Language/zh_CN",
                Accept = "*/*",
                ContentType = "application/octet-stream",
                //se = "SEC_SF_edcd630591726845634a339fa1e14168; Domain =.weixin110.qq.com; Path =/; Secure; HttpOnly",
                ResultType = ResultType.Byte,
                KeepAlive = true,

            };
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    item.Header.Add(header.Key, header.Value);
                }


            }
            HttpResult ret = http.GetHtml(item);
            // Console.WriteLine(ret.ResultByte.ToString(16, 2));
            return ret;
        }

        public static HttpResult HttpPostRead(string GroupUrl, List<micromsg.HTTPHeader> headers = null, string cookie = null, string postData = null)
        {
            //Console.WriteLine(shortUrl + Url_GCI);
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = GroupUrl,
                Method = "post",
                PostDataType = PostDataType.Byte,
                //UserAgent = "MicroMessenger Client",
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/7.0.4(0x17000428) NetType/4G Language/zh_CN",
                Accept = "*/*",
                ContentType = "application/x-www-form-urlencoded",
                //se = "SEC_SF_edcd630591726845634a339fa1e14168; Domain =.weixin110.qq.com; Path =/; Secure; HttpOnly",
                ResultType = ResultType.Byte,
                KeepAlive = true,
                Cookie = cookie,
            };
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    item.Header.Add(header.Key, header.Value);
                }
            }
            item.Postdata = postData;
            HttpResult ret = http.GetHtml(item);
            // Console.WriteLine(ret.ResultByte.ToString(16, 2));
            return ret;
        }

        /// <summary>
        /// 扫码进群
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="url"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public string GetA8KeyGroup(string wxId, string username, string url, int opcode = 2)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString requrl_ = new SKBuiltinString();
            requrl_.@string = url;
            GetA8KeyRequest getA8Key_ = new GetA8KeyRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                codeType = 0,
                codeVersion = 0,
                flag = 0,
                fontScale = (uint)100,
                netType = "WIFI",
                opCode = (uint)opcode,
                userName = wxId,
                reqUrl = requrl_,
                friendQQ = 0,
                scene = 37,
            };

            var src = Util.Serialize(getA8Key_);
            int bufferlen = src.Length;
            //组包

            int mUid = 0;
            string cookie = null;
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETA8KEY, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            //byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/mp-geta8key", customerInfoCache.Proxy);
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/geta8key", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var a8KeyResponse_ = Util.Deserialize<micromsg.GetA8KeyResp>(RespProtobuf);

            if (a8KeyResponse_.FullURL.Contains("@chatroom"))
            {

                return a8KeyResponse_.FullURL?.Replace("weixin://jump/mainframe/", "");
            }
            else
            {
                var result = HttpPostGroup(a8KeyResponse_.FullURL);
                return result?.RedirectUrl?.Replace("weixin://jump/mainframe/", "");
            }

        }


        public static HttpResult HttpPostGroup(string GroupUrl)
        {
            //Console.WriteLine(shortUrl + Url_GCI);
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = GroupUrl,
                Method = "post",
                PostDataType = PostDataType.Byte,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36 QBCore/3.53.1159.400 QQBrowser/9.0.2524.400 Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 MicroMessenger/6.5.2.501 NetType/WIFI WindowsWechat",
                Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
                ContentType = "application/x-www-form-urlencoded",
                //ContentType = "application/octet-stream",
                //se = "SEC_SF_edcd630591726845634a339fa1e14168; Domain =.weixin110.qq.com; Path =/; Secure; HttpOnly",
                ResultType = ResultType.Byte,
                KeepAlive = true,
                Postdata = "forBlackberry=forceToUsePost",
                Referer = GroupUrl,

            };

            HttpResult ret = http.GetHtml(item);
            // Console.WriteLine(ret.ResultByte.ToString(16, 2));
            return ret;
        }





        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="LabelName">标签名</param>
        /// <returns></returns>
        public micromsg.AddContactLabelResponse AddContactLabel(string wxId, string LabelName)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.AddContactLabelRequest addContactLabel_ = new micromsg.AddContactLabelRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };

            micromsg.LabelPair label = new micromsg.LabelPair()
            {
                LabelID = 0,
                LabelName = LabelName
            };

            addContactLabel_.LabelPairList.Add(label);
            addContactLabel_.LabelCount = 1;

            var src = Util.Serialize(addContactLabel_);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 635, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/addcontactlabel", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var AddContactLabelResponse_ = Util.Deserialize<micromsg.AddContactLabelResponse>(RespProtobuf);
            return AddContactLabelResponse_;
        }



        /// <summary>
        /// 修改标签列表
        /// </summary>
        /// <param name="UserLabelInfo"></param>
        /// <returns></returns>
        public micromsg.ModifyContactLabelListResponse ModifyContactLabelList(string wxId, micromsg.UserLabelInfo[] UserLabelInfo)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.ModifyContactLabelListRequest ModifyContactLabelList_ = new micromsg.ModifyContactLabelListRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            foreach (var id in UserLabelInfo)
            {
                ModifyContactLabelList_.UserLabelInfoList.Add(id);

            }
            ModifyContactLabelList_.UserCount = (uint)UserLabelInfo.Length;

            var src = Util.Serialize(ModifyContactLabelList_);

            byte[] RespProtobuf = new byte[0];
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 638, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/modifycontactlabellist", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var ModifyContactLabelListResponse_ = Util.Deserialize<micromsg.ModifyContactLabelListResponse>(RespProtobuf);
            return ModifyContactLabelListResponse_;


        }


        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="LabelIDList_">欲删除的标签id</param>
        /// <returns></returns>
        public micromsg.DelContactLabelResponse DelContactLabel(string wxId, string LabelIDList_)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.DelContactLabelRequest delContactLabel = new micromsg.DelContactLabelRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                LabelIDList = LabelIDList_
            };

            var src = Util.Serialize(delContactLabel);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 636, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/delcontactlabel", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");

            }

            var DelContactLabelResponse_ = Util.Deserialize<micromsg.DelContactLabelResponse>(RespProtobuf);
            return DelContactLabelResponse_;

        }


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public GetContactLabelListResponse GetContactLabelList(string wxId)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            GetContactLabelListRequest getContactLabelList_ = new GetContactLabelListRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
            };

            var src = Util.Serialize(getContactLabelList_);
            int bufferlen = src.Length;
            int mUid = 0;
            string cookie = null;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_GETCONTACTLABELLIST, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_GETCONTACTLABELLIST, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var GetContactLabelListResponse_ = Util.Deserialize<GetContactLabelListResponse>(RespProtobuf);
            return GetContactLabelListResponse_;
        }

        /// <summary>
        /// 绑定邮箱
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="Email"></param>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public micromsg.BindEmailResponse BindEmail(string wxId, string Email, int opcode = 1)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.BindEmailRequest bindEmail_ = new micromsg.BindEmailRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Email = Email,
                OpCode = (uint)opcode,
            };

            var src = Util.Serialize(bindEmail_);

            byte[] RespProtobuf = new byte[0];


            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 256, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            int mUid = 0;
            string cookie = null;
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/bindemail", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var BindEmailResponse_ = Util.Deserialize<micromsg.BindEmailResponse>(RespProtobuf);
            return BindEmailResponse_;
        }
        /// <summary>
        ///摇一摇
        /// </summary>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        /// <returns></returns>
        public micromsg.ShakeGetResponse ShakeReport(string wxId, float Latitude, float Longitude)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];

            //mm.command.ShakereportRequest shakeReport_ = GoogleProto.shakereport(Latitude, Longitude, "49aa7db2f4a3ffe0e96218f6b92cde32", Encoding.Default.GetString(GetAESkey()), (uint)m_uid, "iPad iPhone OS9.3.3");
            micromsg.ShakeReportRequest shakeReport_ = new micromsg.ShakeReportRequest()
            {

                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                GPSSource = 0,
                ImgId = 0,
                Latitude = Latitude,
                Longitude = Longitude,
                OpCode = 0,
                Precision = 0,
                Times = 1,
            };

            var src = Util.Serialize(shakeReport_);

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 161, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/shakereport", customerInfoCache.Proxy);



            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var ShakeReportResponse_ = Util.Deserialize<micromsg.ShakeReportResponse>(RespProtobuf);

            if (ShakeReportResponse_.BaseResponse.Ret == 0 && ShakeReportResponse_.Buffer.Buffer != null)
            {

                var ShakeGetResponse_ = this.ShakeGet(customerInfoCache, ShakeReportResponse_.Buffer);
                return ShakeGetResponse_;
            }

            return null;
        }




        /// <summary>
        /// 获取指定人的朋友圈
        /// </summary>
        /// <param name="fristPageMd5">/首页为空 第二页请附带md5</param>
        /// <param name="Username">要访问人的wxid</param>
        /// <param name="maxid">首页为0 次页朋友圈数据id 的最小值</param>
        /// <returns></returns>
        public SnsUserPageResponse SnsUserPage(string fristPageMd5, string wxId, string toWxId, ulong maxid = 0)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            byte[] RespProtobuf = new byte[0];
            SnsUserPageRequest snsUserPage = new SnsUserPageRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                fristPageMd5 = fristPageMd5,
                username = toWxId,
                maxid = (ulong)maxid,
                source = 0,
                minFilterId = 0,
                lastRequestTime = 0

            };


            var src = Util.Serialize(snsUserPage);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_MMSNSUSERPAGE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSUSERPAGE, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var SnsUserPageResponse_ = Util.Deserialize<SnsUserPageResponse>(RespProtobuf);
            return SnsUserPageResponse_;
        }



        /// <summary>
        /// 取朋友圈首页
        /// </summary>
        /// <param name="fristPageMd5">/首页为空 第二页请附带md5</param>
        /// <param name="maxid">首页为0 次页朋友圈数据id 的最小值</param>
        /// <returns></returns>
        public SnsTimeLineResponse SnsTimeLine(string wxId, string fristPageMd5 = "", ulong maxid = 0)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            byte[] RespProtobuf = new byte[0];
            SnsTimeLineRequest snsTimeLine = new SnsTimeLineRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                clientLastestId = 0,
                firstPageMd5 = fristPageMd5,
                lastRequestTime = 0,
                maxId = (ulong)maxid,
                minFilterId = 0,
                networkType = 1,

            };


            var src = Util.Serialize(snsTimeLine);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_MMSNSTIMELINE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSTIMELINE, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var SnsTimeLineResponse_ = Util.Deserialize<SnsTimeLineResponse>(RespProtobuf);
            return SnsTimeLineResponse_;
        }


        /// <summary>
        /// 操作朋友圈
        /// </summary>
        /// <param name="id">要操作的id</param>
        /// <param name="type">//1删除朋友圈2设为隐私3设为公开4删除评论5取消点赞</param>
        /// <returns></returns>
        public SnsObjectOpResponse GetSnsObjectOp(ulong id, string wxId, SnsObjectOpType type)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            byte[] RespProtobuf = new byte[0];
            SnsObjectOp snsObject = new SnsObjectOp()
            {
                id = id,
                opType = type
            };

            SnsObjectOpRequest snsObjectOp_ = new SnsObjectOpRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                opCount = 1,
                opList = snsObject
            };

            var src = Util.Serialize(snsObjectOp_);

            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_SNSOBJECTOP, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSOBJECTOP, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var SnsObjectOpResponse_ = Util.Deserialize<SnsObjectOpResponse>(RespProtobuf);
            return SnsObjectOpResponse_;
        }


        /// <summary>
        /// 发送盆友圈
        /// </summary>
        /// <param name="content">欲发送内容 使用朋友圈结构发送</param>
        /// <returns></returns>
        public SnsPostResponse SnsPost(string wxId, string content, IList<string> BlackList, IList<string> WithUserList)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException("缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            var RespProtobuf = new byte[0];
            SnsPostRequest SnsPostReq = new SnsPostRequest();// Util.Deserialize<SnsPostRequest>("0A570A105D64797E40587E3653492B3770767C6D10E5DA8D81031A20353332363435314632303045304431333043453441453237323632423631363920A28498B0012A1369506164206950686F6E65204F53392E332E33300012810808FB0712FB073C54696D656C696E654F626A6563743E3C69643E31323534323132393139333538343234323934373C2F69643E3C757365726E616D653E777869645F6B727862626D68316A75646533313C2F757365726E616D653E3C63726561746554696D653E313439353133383331303C2F63726561746554696D653E3C636F6E74656E74446573633EE2809CE7BEA1E68595E982A3E4BA9BE4B880E6B2BEE79D80E69E95E5A4B4E5B0B1E883BDE5AE89E79DA1E79A84E4BABAE5928CE982A3E4BA9BE586B3E5BF83E694BEE6898BE4B98BE5908EE5B0B1E4B88DE5868DE59B9EE5A4B4E79A84E4BABAE2809D3C2F636F6E74656E74446573633E3C636F6E74656E744465736353686F77547970653E303C2F636F6E74656E744465736353686F77547970653E3C636F6E74656E74446573635363656E653E333C2F636F6E74656E74446573635363656E653E3C707269766174653E303C2F707269766174653E3C7369676874466F6C6465643E303C2F7369676874466F6C6465643E3C617070496E666F3E3C69643E3C2F69643E3C76657273696F6E3E3C2F76657273696F6E3E3C6170704E616D653E3C2F6170704E616D653E3C696E7374616C6C55726C3E3C2F696E7374616C6C55726C3E3C66726F6D55726C3E3C2F66726F6D55726C3E3C6973466F7263655570646174653E303C2F6973466F7263655570646174653E3C2F617070496E666F3E3C736F75726365557365724E616D653E3C2F736F75726365557365724E616D653E3C736F757263654E69636B4E616D653E3C2F736F757263654E69636B4E616D653E3C73746174697374696373446174613E3C2F73746174697374696373446174613E3C737461744578745374723E3C2F737461744578745374723E3C436F6E74656E744F626A6563743E3C636F6E74656E745374796C653E323C2F636F6E74656E745374796C653E3C7469746C653E3C2F7469746C653E3C6465736372697074696F6E3E3C2F6465736372697074696F6E3E3C6D656469614C6973743E3C2F6D656469614C6973743E3C636F6E74656E7455726C3E3C2F636F6E74656E7455726C3E3C2F436F6E74656E744F626A6563743E3C616374696F6E496E666F3E3C6170704D73673E3C6D657373616765416374696F6E3E3C2F6D657373616765416374696F6E3E3C2F6170704D73673E3C2F616374696F6E496E666F3E3C6C6F636174696F6E20636974793D5C225C2220706F69436C61737369667949643D5C225C2220706F694E616D653D5C225C2220706F69416464726573733D5C225C2220706F69436C617373696679547970653D5C22305C223E3C2F6C6F636174696F6E3E3C7075626C6963557365724E616D653E3C2F7075626C6963557365724E616D653E3C2F54696D656C696E654F626A6563743E0D0A1800280030003A13736E735F706F73745F313533343933333731384001580068008001009A010A0A0012001A0020002800AA010408001200C00100".ToByteArray(16, 2));

            SnsPostReq.baseRequest = new BaseRequest()
            {
                sessionKey = customerInfoCache.BaseRequest.sessionKey,
                uin = customerInfoCache.BaseRequest.uin,
                devicelId = customerInfoCache.BaseRequest.devicelId,
                clientVersion = customerInfoCache.BaseRequest.clientVersion,
                osType = customerInfoCache.BaseRequest.osType,
                scene = customerInfoCache.BaseRequest.scene
            };
            SnsPostReq.objectDesc = new SKBuiltinString_S();
            SnsPostReq.objectDesc.iLen = (uint)content.Length;
            SnsPostReq.objectDesc.buffer = content;

            SnsPostReq.clientId = "sns_post_" + CurrentTime_().ToString();
            //SnsPostReq.groupNum = 1;
            //SnsPostReq.groupIds = new SnsGroup[1];
            //SnsPostReq.groupIds[0] = new SnsGroup() { GroupId = 3 };
            //SnsPostReq.blackListNum = 1;
            if (BlackList != null && BlackList.Count > 0)
            {
                SnsPostReq.blackListNum = (uint)BlackList.Count;
                SnsPostReq.blackList = new SKBuiltinString[BlackList.Count];
                for (int i = 0; i < BlackList.Count; i++)
                {
                    SnsPostReq.blackList[i] = new SKBuiltinString() { @string = BlackList[i] };
                }

            }
            if (WithUserList != null && WithUserList.Count > 0)
            {
                SnsPostReq.withUserListNum = (uint)WithUserList.Count;
                SnsPostReq.withUserList = new SKBuiltinString[WithUserList.Count];
                for (int i = 0; i < WithUserList.Count; i++)
                {
                    SnsPostReq.withUserList[i] = new SKBuiltinString() { @string = WithUserList[i] };
                }
            }

            var src = Util.Serialize(SnsPostReq);



            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_MMSNSPORT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSPORT, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new Exception("数据包可能有问题,请重新生成二维码登录");
            }
            var SnsPostResponse = Util.Deserialize<SnsPostResponse>(RespProtobuf);
            return SnsPostResponse;
        }

        /// <summary>
        /// 同步盆友圈
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="OStype"></param>
        /// <returns></returns>
        public SnsSyncResponse SnsSync(string wxId)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            //压缩前长度和压缩后长度
            int lenBeforeZip = 0;
            int lenAfterZip = 0;

            var RespProtobuf = new byte[0];
            //生成google对象
            mm.command.MMSnsSyncRequest nsrObj = GoogleProto.CreateMMSnsSyncRequest(customerInfoCache.DeviceId, Encoding.Default.GetString(customerInfoCache.AesKey), (uint)customerInfoCache.MUid, osType, customerInfoCache.InitSyncKey);

            byte[] nsrData = nsrObj.ToByteArray();
            lenBeforeZip = nsrData.Length;

            int bufferlen = nsrData.Length;
            //组包
            byte[] SendDate = pack(nsrData, (int)CGI_TYPE.CGI_TYPE_MMSNSSYNC, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSSYNC, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            //mm.command.MMSnsSyncRequest nsrReceive = mm.command.MMSnsSyncRequest.ParseFrom(RespProtobuf);
            var SnsSyncResponse = Util.Deserialize<SnsSyncResponse>(RespProtobuf);
            return SnsSyncResponse;
        }

        public static string GetMD5HashFromFile(byte[] buffer)
        {
            try
            {

                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(buffer);


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
        /// <summary>
        /// 上传朋友圈图片不是发朋友圈图片
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <returns></returns>
        public micromsg.SnsUploadResponse SnsUpload(string wxId, Stream sm)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            byte[] RespProtobuf = new byte[0];

            int Startpos = 0;//起始位置
            int datalen = 1024 * 100;//数据分块长度
            long datatotalength = sm.Length;
            micromsg.SnsUploadResponse SnsUploadResponse_ = null;
            var currentTime = CurrentTime_();
            string md5 = GetMD5HashFromFile(sm.ToBuffer());
            while (Startpos != (int)datatotalength)
            {//
                int count = 0;
                if (datatotalength - Startpos > datalen)
                {
                    count = datalen;
                }
                else
                {

                    count = (int)datatotalength - Startpos;
                }

                byte[] data = new byte[count];
                sm.Seek(Startpos, SeekOrigin.Begin);
                sm.Read(data, 0, count);


                micromsg.SKBuiltinBuffer_t data_ = new micromsg.SKBuiltinBuffer_t();
                data_.Buffer = data;
                data_.iLen = (uint)data.Length;

                micromsg.SnsUploadRequest snsUpload_ = new micromsg.SnsUploadRequest()
                {
                    BaseRequest = new micromsg.BaseRequest()
                    {
                        SessionKey = customerInfoCache.BaseRequest.sessionKey,
                        Uin = (uint)customerInfoCache.BaseRequest.uin,
                        DeviceID = customerInfoCache.BaseRequest.devicelId,
                        ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                        DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                        Scene = (uint)customerInfoCache.BaseRequest.scene
                    },
                    ClientId = currentTime.ToString(),
                    TotalLen = (uint)datatotalength,
                    StartPos = (uint)Startpos,
                    Buffer = data_,
                    Type = 2,
                    MD5 = md5
                };

                var src = Util.Serialize(snsUpload_);
                //byte[] RespProtobuf = new byte[0];

                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, 207, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/snsupload", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }
                SnsUploadResponse_ = Util.Deserialize<micromsg.SnsUploadResponse>(RespProtobuf);

                if (SnsUploadResponse_.BaseResponse.Ret == 0)
                {
                    Startpos = Startpos + count;
                }
                else
                {
                    return null;
                }

            }
            return SnsUploadResponse_;
        }

        /// <summary>
        /// 回复朋友圈
        /// </summary>
        /// <param name="id">朋友圈Id</param>
        /// <param name="wxId"></param>
        /// <param name="toWxId"></param>
        /// <param name="content"></param>
        /// <param name="type">1点赞 2：文本 3:消息 4：with 5陌生人点赞</param>
        /// <returns></returns>
        public micromsg.SnsCommentResponse SnsComment(ulong id, string wxId, string toWxId, int relpyCommentId, string content, SnsObjectType type)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            var RespProtobuf = new byte[0];


            SnsCommentRequest snsCommentRequest = new SnsCommentRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                clientid = CurrentTime_().ToString(),
                action = new SnsActionGroup()
                {
                    id = id,
                    parentId = 0,
                    currentAction = new SnsAction()
                    {
                        replyCommentId = relpyCommentId,
                        type = type,
                        content = content,
                        from = wxId,
                        to = toWxId,
                        source = 6,
                        //fromnickname="李四",
                        //tonickname="张三"
                    }

                }


            };
            var src = Util.Serialize(snsCommentRequest);


            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_NEWSENDMSG, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);

            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_MMSNSCOMMENT, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var snsCommentResponse = Util.Deserialize<micromsg.SnsCommentResponse>(RespProtobuf);
            return snsCommentResponse;
        }


        /// <summary>
        /// 发送文字信息
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="toWxId"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NewSendMsgRespone SendNewMsg(string wxId, string toWxId, string content, int type = 1)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            var RespProtobuf = new byte[0];

            NewSendMsgRequest newSendMsgRequest = new NewSendMsgRequest();
            newSendMsgRequest.info = new ChatInfo();
            newSendMsgRequest.info.clientMsgId = (ulong)CurrentTime_();
            newSendMsgRequest.cnt = 1;
            newSendMsgRequest.info.toid = new SKBuiltinString();
            newSendMsgRequest.info.toid.@string = toWxId;
            newSendMsgRequest.info.content = content;
            newSendMsgRequest.info.utc = CurrentTime_();
            newSendMsgRequest.info.type = type;
            newSendMsgRequest.info.msgSource = string.Empty;
            var src = Util.Serialize(newSendMsgRequest);


            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_NEWSENDMSG, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);

            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_NEWSENDMSG, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var NewSendMsg = Util.Deserialize<NewSendMsgRespone>(RespProtobuf);
            return NewSendMsg;
        }


        /// <summary>
        /// 发送音频文件
        /// </summary>
        /// <param name="to">接收者</param>
        /// <param name="from">发送者</param>
        /// <param name="path">音频路径</param>
        /// <param name="voiceFormat">音频格式</param>
        /// <param name="voiceLen">音频长度 10为一秒</param>
        /// <returns></returns>
        public UploadVoiceResponse SendVoiceMessage(string wxId, string toWxId, byte[] buffer, VoiceFormat voiceFormat = VoiceFormat.MM_VOICE_FORMAT_AMR, int voiceLen = 100)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            SKBuiltinString_ data_ = new SKBuiltinString_();
            data_.buffer = buffer;
            data_.iLen = (uint)buffer.Length;
            UploadVoiceRequest uploadVoice_ = new UploadVoiceRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                from = wxId,
                to = toWxId,
                clientMsgId = CurrentTime_().ToString(),
                voiceFormat = voiceFormat,
                voiceLen = voiceLen,
                length = buffer.Length,
                data = data_,
                offset = 0,
                endFlag = 1,
                msgsource = ""
            };
            int mUid = 0;
            string cookie = null;

            var src = Util.Serialize(uploadVoice_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 127, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadvoice", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var UploadVoiceResponse_ = Util.Deserialize<UploadVoiceResponse>(RespProtobuf);

            string ret = JsonConvert.SerializeObject(UploadVoiceResponse_);


            return UploadVoiceResponse_;
        }
        /// <summary>
        /// 上传通讯录
        /// </summary>
        /// <param name="Mobile_"></param>
        /// <param name="UPMobile"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public micromsg.UploadMContactResponse UploadMContact(string wxId, string Mobile_, micromsg.Mobile[] UPMobile)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.UploadMContactRequest uploadMContact = new micromsg.UploadMContactRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Opcode = 1,
                UserName = wxId
            };

            uploadMContact.Mobile = Mobile_;
            foreach (micromsg.Mobile mobile in UPMobile)
            {
                uploadMContact.MobileList.Add(mobile);
            }

            uploadMContact.MobileListSize = UPMobile.Length;
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(uploadMContact);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_UPLOADMCONTACT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_UPLOADMCONTACT, customerInfoCache.Proxy);
            byte[] RespProtobuf = new byte[0];

            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var UploadMContactResponse = Util.Deserialize<micromsg.UploadMContactResponse>(RespProtobuf);
            return UploadMContactResponse;

        }
        public NewSendMsgRespone SendVoiceMessage1(string wxId, string toWxId, string content, byte[] buffer, VoiceFormat voiceFormat = VoiceFormat.MM_VOICE_FORMAT_AMR, int voiceLen = 100, int type = 34)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;
            var RespProtobuf = new byte[0];
            //byte[] Msg = "0801129B050A150A13777869645F32306E763668336A63333735323212EC043C3F786D6C2076657273696F6E3D22312E30223F3E0A3C6D73672062696768656164696D6775726C3D22687474703A2F2F77782E716C6F676F2E636E2F6D6D686561642F7665725F312F666864536D6F503670744B483467537852495842394643544A455136436169635648317338787675506B787551706E4D344A647956696154626E64696354335172574444616E56624F48535955344F3437396D65796D5947672F302220736D616C6C68656164696D6775726C3D22687474703A2F2F77782E716C6F676F2E636E2F6D6D686561642F7665725F312F666864536D6F503670744B483467537852495842394643544A455136436169635648317338787675506B787551706E4D344A647956696154626E64696354335172574444616E56624F48535955344F3437396D65796D5947672F3133322220757365726E616D653D22777869645F7062673530786463696B7875323222206E69636B6E616D653D224C694152222066756C6C70793D224C694152222073686F727470793D222220616C6961733D2248333130373333343633322220696D6167657374617475733D223322207363656E653D223137222070726F76696E63653D22E5AF86E5858BE7BD97E5B0BCE8A5BFE4BA9A2220636974793D22E5AF86E5858BE7BD97E5B0BCE8A5BFE4BA9A22207369676E3D2222207365783D2232222063657274666C61673D2230222063657274696E666F3D2222206272616E6449636F6E55726C3D2222206272616E64486F6D6555726C3D2222206272616E64537562736372697074436F6E66696755726C3D2222206272616E64466C6167733D22302220726567696F6E436F64653D22464D22202F3E0A182A20D1ED8FDC0528DCD885C681C5ADD69B013200".ToByteArray(16, 2);
            //var newSendMsgRequest1 = ProtoBuf.Serializer.Deserialize<NewSendMsgRequest>(new MemoryStream(Msg));
            //newSendMsgRequest1.info.clientMsgId = (ulong)CurrentTime_();
            //newSendMsgRequest1.info.toid.@string = toWxId;
            //newSendMsgRequest1.info.content = content;
            //newSendMsgRequest1.info.utc = CurrentTime_();
            //newSendMsgRequest1.info.type = type;
            //var src = Util.Serialize(newSendMsgRequest1);
            //var wdawdda = sd111a.ToJson();
            //File.WriteAllText("D://a.txt", wdawdda);
            //byte[] msg = Encoding.UTF8.GetBytes(content);

            NewSendMsgRequest newSendMsgRequest = new NewSendMsgRequest();
            newSendMsgRequest.info = new ChatInfo();
            newSendMsgRequest.info.clientMsgId = (ulong)CurrentTime_();
            newSendMsgRequest.cnt = 1;
            newSendMsgRequest.info.clientMsgId = (ulong)CurrentTime_();
            newSendMsgRequest.info.toid = new SKBuiltinString();
            newSendMsgRequest.info.toid.@string = toWxId;
            newSendMsgRequest.info.content = content;
            newSendMsgRequest.info.utc = CurrentTime_();
            newSendMsgRequest.info.type = type;
            newSendMsgRequest.info.msgSource = string.Empty;
            var src = Util.Serialize(newSendMsgRequest);


            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_NEWSENDMSG, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);

            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_NEWSENDMSG, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var NewSendMsg = Util.Deserialize<NewSendMsgRespone>(RespProtobuf);
            return NewSendMsg;
        }

        /// <summary>
        /// 同步收藏 
        /// </summary>
        /// <param name="keybuf">第二次请求需要带上第一次返回的</param>
        /// <returns></returns>
        public micromsg.FavSyncResponse FavSync(string wxId, byte[] keybuf = null)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = keybuf;
            micromsg.SKBuiltinBuffer_t keybuf_ = new micromsg.SKBuiltinBuffer_t();
            if (keybuf != null)
            {
                keybuf_.Buffer = keybuf;
                keybuf_.iLen = (uint)keybuf.Length;
            }

            micromsg.FavSyncRequest favSync_ = new micromsg.FavSyncRequest()
            {
                KeyBuf = keybuf_,
                Selector = 1,
            };

            var src = Util.Serialize(favSync_);

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_FAVSYNC, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_FAVSYNC, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var FavSyncResponse_ = Util.Deserialize<micromsg.FavSyncResponse>(RespProtobuf);
            return FavSyncResponse_;
        }

        public IList<micromsg.AddFavItem> ToAddFavItem(micromsg.FavSyncResponse favSyncResponse)
        {
            IList<micromsg.AddFavItem> list = new List<micromsg.AddFavItem>();
            foreach (var s in favSyncResponse.CmdList.List)
            {
                micromsg.AddFavItem shareFav = Util.Deserialize<micromsg.AddFavItem>(s.CmdBuf.Buffer);
                list.Add(shareFav);
            }
            return list;

        }
        /// <summary>
        ///获取单条收藏
        /// </summary>
        /// <param name="FavId">收藏id</param>
        /// <returns></returns>
        public micromsg.BatchGetFavItemResponse GetFavItem(string wxId, int FavId)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.BatchGetFavItemRequest batchGetFavItem = new micromsg.BatchGetFavItemRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            batchGetFavItem.Count = 1;
            batchGetFavItem.FavIdList.Add((uint)FavId);

            var src = Util.Serialize(batchGetFavItem);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_BATCHGETFAVITEM, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_BATCHGETFAVITEM, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var BatchGetFavItemResponse_ = Util.Deserialize<micromsg.BatchGetFavItemResponse>(RespProtobuf);
            return BatchGetFavItemResponse_;
        }

        /// <summary>
        /// 删除收藏 这里可删除多条收藏
        /// </summary>
        /// <param name="FavId">收藏id</param>
        /// <returns></returns>
        public micromsg.BatchDelFavItemResponse DelFavItem(string wxId, uint[] FavId)
        {


            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.BatchDelFavItemRequest DelFavItem = new micromsg.BatchDelFavItemRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            DelFavItem.Count = (uint)FavId.Length;
            foreach (uint ID in FavId)
            {
                DelFavItem.FavIdList.Add(ID);
            }


            var src = Util.Serialize(DelFavItem);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 484, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/batchdelfavitem", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var BatchDelFavItemResponse_ = Util.Deserialize<micromsg.BatchDelFavItemResponse>(RespProtobuf);
            return BatchDelFavItemResponse_;
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="object_"></param>
        /// <param name="SourceId_"></param>
        /// <returns></returns>
        public micromsg.AddFavItemResponse addFavItem(string wxId, string object_, string SourceId_ = "")
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }   
            micromsg.AddFavItemRequest addFav = new micromsg.AddFavItemRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                ClientId = CurrentTime_().ToString(),
                Object = object_,
                Type = 1,
                SourceId = SourceId_,
                SourceType = 2,
            };

            var src = Util.Serialize(addFav);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 401, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/addfavitem", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var AddFavItemResponse_ = Util.Deserialize<micromsg.AddFavItemResponse>(RespProtobuf);
            return AddFavItemResponse_;
        }




        public TenPayResponse TenPay(string wxId, enMMTenPayCgiCmd cgiCmd, string reqText = "", string reqTextWx = "")
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];

            SKBuiltinString_S reqText_ = new SKBuiltinString_S();
            reqText_.buffer = reqText;
            reqText_.iLen = (uint)reqText.Length;

            SKBuiltinString_S reqTextWx_ = new SKBuiltinString_S();
            reqTextWx_.buffer = reqTextWx;
            reqTextWx_.iLen = (uint)reqTextWx.Length;
            TenPayRequest tenPay_ = new TenPayRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                cgiCmd = cgiCmd,
                outPutType = (uint)1,
                reqText = reqText_,
                reqTextWx = reqTextWx_

            };
            int mUid = 0;
            string cookie = null;
            var src = Util.Serialize(tenPay_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_TENPAY, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_TENPAY, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var TenPayResponse_ = Util.Deserialize<TenPayResponse>(RespProtobuf);
            return TenPayResponse_;
        }


        /// <summary>
        /// 取收款码
        /// </summary>
        /// <returns></returns>
        public F2FQrcodeResponse F2FQrcode(string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            var RespProtobuf = new byte[0];

            F2FQrcodeRequest F2FQrcode_ = new F2FQrcodeRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },

            };
            var src = Util.Serialize(F2FQrcode_);



            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_F2FQRCODE, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_F2FQRCODE, customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var f2fcode = Util.Deserialize<F2FQrcodeResponse>(RespProtobuf);
            return f2fcode;
        }

        public UploadVideoResponse SendVideoMessage(string wxId, string toWxId, int playLength, byte[] buffer, byte[] imageBuffer)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];


            int Startpos = 0;//起始位置       
            int datalen = 50000;//数据分块长度    

            int imageStartOps = 0;


            MemoryStream dataStream = new MemoryStream(buffer);
            long datatotalength = dataStream.Length;


            MemoryStream imgStream = new MemoryStream(imageBuffer);
            long imagetotalength = imgStream.Length;

            string ClientImgId_ = CurrentTime_().ToString();

            var UploadMsgImgResponse_ = new UploadVideoResponse();
            int mUid = 0;
            string cookie = null;


            while (imageStartOps < (int)imagetotalength)
            {
                int count = 0;
                if (imagetotalength - imageStartOps > datalen)
                {
                    count = datalen;
                }
                else
                {
                    count = (int)imagetotalength - imageStartOps;
                }
                byte[] data = new byte[count];
                imgStream.Seek(imageStartOps, SeekOrigin.Begin);
                imgStream.Read(data, 0, count);

                SKBuiltinString_ data_ = new SKBuiltinString_();
                data_.buffer = new byte[0];
                data_.iLen = (uint)0;

                UploadVideoRequest uploadMsgImg_ = new UploadVideoRequest()
                {
                    BaseRequest = new BaseRequest()
                    {
                        sessionKey = customerInfoCache.BaseRequest.sessionKey,
                        uin = customerInfoCache.BaseRequest.uin,
                        devicelId = customerInfoCache.BaseRequest.devicelId,
                        clientVersion = customerInfoCache.BaseRequest.clientVersion,
                        osType = customerInfoCache.BaseRequest.osType,
                        scene = customerInfoCache.BaseRequest.scene
                    },
                    clientMsgId = ClientImgId_,
                    videoData = data_,
                    videoTotalLen = buffer.Length,
                    playLength = (uint)playLength,
                    videoStartPos = (uint)Startpos,
                    funcFlag = (uint)2,
                    cameraType = 2,
                    videoFrom = 0,
                    from = wxId,
                    to = toWxId,
                    networkEnv = 1,
                    reqTime = Convert.ToUInt32(CurrentTime_()),
                    encryVer = 0,
                    //cDNThumbImgHeight = 512,
                    //cDNThumbImgWidth = 290,
                    //msgForwardType = 43,

                };

                uploadMsgImg_.thumbStartPos = (uint)imageStartOps;
                uploadMsgImg_.thumbTotalLen = imageBuffer.Length;
                uploadMsgImg_.thumbData = new SKBuiltinString_()
                {
                    iLen = (uint)data.Length,
                    buffer = data
                };

                imageStartOps = imageStartOps + count;
                var src = Util.Serialize(uploadMsgImg_);
                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, (int)110, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadvideo", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }

                UploadMsgImgResponse_ = Util.Deserialize<UploadVideoResponse>(RespProtobuf);
                if (UploadMsgImgResponse_ == null || UploadMsgImgResponse_.baseResponse != null && UploadMsgImgResponse_.baseResponse.ret != RetConst.MM_OK)
                {
                    throw new Exception($"{wxId}发送{toWxId}失败");
                }
            }




            while (Startpos < (int)datatotalength)
            {//
                int count = 0;
                if (datatotalength - Startpos > datalen)
                {
                    count = datalen;
                }
                else
                {
                    count = (int)datatotalength - Startpos;
                }

                byte[] data = new byte[count];
                dataStream.Seek(Startpos, SeekOrigin.Begin);
                dataStream.Read(data, 0, count);

                SKBuiltinString_ data_ = new SKBuiltinString_();
                data_.buffer = data;
                data_.iLen = (uint)data.Length;

                UploadVideoRequest uploadMsgImg_ = new UploadVideoRequest()
                {
                    BaseRequest = new BaseRequest()
                    {
                        sessionKey = customerInfoCache.BaseRequest.sessionKey,
                        uin = customerInfoCache.BaseRequest.uin,
                        devicelId = customerInfoCache.BaseRequest.devicelId,
                        clientVersion = customerInfoCache.BaseRequest.clientVersion,
                        osType = customerInfoCache.BaseRequest.osType,
                        scene = customerInfoCache.BaseRequest.scene
                    },
                    clientMsgId = ClientImgId_,
                    videoData = data_,
                    videoTotalLen = buffer.Length,
                    playLength = (uint)playLength,
                    videoStartPos = (uint)Startpos,
                    funcFlag = (uint)2,
                    cameraType = 2,
                    videoFrom = 0,
                    from = wxId,
                    to = toWxId,
                    networkEnv = 1,
                    reqTime = Convert.ToUInt32(CurrentTime_()),
                    encryVer = 0,
                    //cDNThumbImgHeight = 512,
                    //cDNThumbImgWidth = 290,
                    //msgForwardType = 43,

                };

                uploadMsgImg_.thumbStartPos = (uint)imageBuffer.Length;
                uploadMsgImg_.thumbTotalLen = imageBuffer.Length;
                uploadMsgImg_.thumbData = new SKBuiltinString_()
                {
                    iLen = 0,
                    buffer = new byte[0]
                };

                //if (Startpos == 0)
                //{
                //    uploadMsgImg_.thumbStartPos = (uint)0;
                //    uploadMsgImg_.thumbTotalLen = imageBuffer.Length;
                //    uploadMsgImg_.thumbData = new SKBuiltinString_()
                //    {
                //        iLen = (uint)imageBuffer.Length,
                //        buffer = imageBuffer
                //    };
                //}
                //else
                //{
                //    uploadMsgImg_.thumbStartPos = (uint)imageBuffer.Length;
                //    uploadMsgImg_.thumbTotalLen = imageBuffer.Length;
                //    uploadMsgImg_.thumbData = new SKBuiltinString_()
                //    {
                //        iLen = 0,
                //        buffer = new byte[0]
                //    };
                //}


                Startpos = Startpos + count;
                var src = Util.Serialize(uploadMsgImg_);
                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, (int)110, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadvideo", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }

                UploadMsgImgResponse_ = Util.Deserialize<UploadVideoResponse>(RespProtobuf);
                if (UploadMsgImgResponse_ == null || UploadMsgImgResponse_.baseResponse != null && UploadMsgImgResponse_.baseResponse.ret != RetConst.MM_OK)
                {
                    throw new Exception("发送失败");
                }
            }


            return UploadMsgImgResponse_;
        }






        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="toWxId"></param>
        /// <param name="buffer"></param>
        /// <param name="VideoFrom"></param>
        /// <returns></returns>
        public micromsg.UploadVideoResponse SendVideoMessage1(string wxId, string toWxId, byte[] buffer, int VideoFrom = 0)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            int mUid = 0;
            string cookie = null;

            micromsg.UploadVideoRequest uploadVoice_ = new micromsg.UploadVideoRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                FromUserName = wxId,
                ToUserName = toWxId,
                ClientMsgId = CurrentTime_().ToString(),
                VideoFrom = VideoFrom,
                VideoData = new micromsg.SKBuiltinBuffer_t()
                {
                    Buffer = buffer,
                    iLen = (uint)buffer.Length
                },

                PlayLength = 4,
                VideoTotalLen = (uint)buffer.Length,
                VideoStartPos = 0,
                EncryVer = 1,
                NetworkEnv = 1,
                FuncFlag = 2,
                //ThumbData = new micromsg.SKBuiltinBuffer_t()
                //{
                //    Buffer = new byte[0],
                //    iLen = 0

                //},
                CameraType = 2,
                ThumbStartPos = (uint)buffer.Length,
                ReqTime = Convert.ToUInt32(CurrentTime_())

            };

            var src = Util.Serialize(uploadVoice_);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 149, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadvideo", customerInfoCache.Proxy);
            byte[] RespProtobuf = new byte[0];

            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var UploadVideoResponse_ = Util.Deserialize<micromsg.UploadVideoResponse>(RespProtobuf);

            string ret = JsonConvert.SerializeObject(UploadVideoResponse_);


            return UploadVideoResponse_;
        }

        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="toWxId"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public UploadMsgImgResponse SendImageMessage(string wxId, string toWxId, byte[] buffer)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            MemoryStream imgStream = new MemoryStream(buffer);

            int Startpos = 0;//起始位置
            int datalen = 50000;//数据分块长度
            long datatotalength = imgStream.Length;

            SKBuiltinString ClientImgId_ = new SKBuiltinString();
            ClientImgId_.@string = CurrentTime_().ToString();

            SKBuiltinString to_ = new SKBuiltinString();
            to_.@string = toWxId;

            SKBuiltinString from_ = new SKBuiltinString();
            from_.@string = wxId;

            var UploadMsgImgResponse_ = new UploadMsgImgResponse();
            int mUid = 0;
            string cookie = null;
            while (Startpos < (int)datatotalength)
            {//
                int count = 0;
                if (datatotalength - Startpos > datalen)
                {
                    count = datalen;
                }
                else
                {
                    count = (int)datatotalength - Startpos;
                }

                byte[] data = new byte[count];
                imgStream.Seek(Startpos, SeekOrigin.Begin);
                imgStream.Read(data, 0, count);


                SKBuiltinString_ data_ = new SKBuiltinString_();
                data_.buffer = data;
                data_.iLen = (uint)data.Length;

                UploadMsgImgRequest uploadMsgImg_ = new UploadMsgImgRequest()
                {
                    BaseRequest = new BaseRequest()
                    {
                        sessionKey = customerInfoCache.BaseRequest.sessionKey,
                        uin = customerInfoCache.BaseRequest.uin,
                        devicelId = customerInfoCache.BaseRequest.devicelId,
                        clientVersion = customerInfoCache.BaseRequest.clientVersion,
                        osType = customerInfoCache.BaseRequest.osType,
                        scene = customerInfoCache.BaseRequest.scene
                    },
                    clientImgId = ClientImgId_,
                    data = data_,
                    dataLen = (uint)data.Length,
                    totalLen = (uint)datatotalength,
                    to = to_,
                    msgType = (uint)3,
                    from = from_,
                    startPos = (uint)Startpos,
                    messageExt = "png",

                    reqTime = Convert.ToUInt32(CurrentTime_()),
                    encryVer = 0

                };
                Startpos = Startpos + count;
                var src = Util.Serialize(uploadMsgImg_);
                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, (int)110, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadmsgimg", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }

                UploadMsgImgResponse_ = Util.Deserialize<UploadMsgImgResponse>(RespProtobuf);
                if (UploadMsgImgResponse_ == null || UploadMsgImgResponse_.baseResponse != null && UploadMsgImgResponse_.baseResponse.ret != RetConst.MM_OK)
                {
                    throw new Exception("发送失败");
                }
            }//

            return UploadMsgImgResponse_;
        }




        /// <summary>
        /// 发送卡片信息
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="toWxid"></param>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public micromsg.SendAppMsgResponse SendCardMsg(string Content, string toWxid, string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SendCardRequest sendCardRequest = new micromsg.SendCardRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            sendCardRequest.UserName = toWxid;
            sendCardRequest.Content = Content;
            sendCardRequest.SendCardBitFlag = 1;
            sendCardRequest.Style = 1;
            sendCardRequest.ContentEx = "";

            var src = Util.Serialize(sendCardRequest);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 222, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/sendcard", customerInfoCache.Proxy);

            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var SendAppMsgResponse_ = Util.Deserialize<micromsg.SendAppMsgResponse>(RespProtobuf);
            return SendAppMsgResponse_;

        }

        ///// <summary>
        ///// 上传文件
        ///// </summary>
        ///// <param name="wxId"></param>
        ///// <param name="buffer"></param>
        ///// <param name="mediaType"></param>
        ///// <returns></returns>
        //public micromsg.UploadMediaResponse UploadFile(string wxId, byte[] buffer, int mediaType)
        //{
        //    var cache = this._redisCache;
        //    var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
        //    if (customerInfoCache == null)
        //    {
        //        throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
        //    }
        //    byte[] RespProtobuf = new byte[0];
        //    MemoryStream imgStream = new MemoryStream(buffer);

        //    int Startpos = 0;//起始位置
        //    int datalen = 50000;//数据分块长度
        //    long datatotalength = imgStream.Length;

        //    micromsg.SKBuiltinString_t ClientImgId_ = new micromsg.SKBuiltinString_t();
        //    ClientImgId_.String = CurrentTime_().ToString();
        //    var uploadMediaRes = new micromsg.UploadMediaResponse();
        //    int mUid = 0;
        //    string cookie = null;
        //    while (Startpos < (int)datatotalength)
        //    {//
        //        int count = 0;
        //        if (datatotalength - Startpos > datalen)
        //        {
        //            count = datalen;
        //        }
        //        else
        //        {
        //            count = (int)datatotalength - Startpos;
        //        }

        //        byte[] data = new byte[count];
        //        imgStream.Seek(Startpos, SeekOrigin.Begin);
        //        imgStream.Read(data, 0, count);


        //        micromsg.SKBuiltinBuffer_t data_ = new micromsg.SKBuiltinBuffer_t();
        //        data_.Buffer = data;
        //        data_.iLen = (uint)data.Length;

        //        micromsg.UploadMediaRequest uploadMediaReq = new micromsg.UploadMediaRequest()
        //        {
        //            BaseRequest = new micromsg.BaseRequest()
        //            {
        //                SessionKey = customerInfoCache.BaseRequest.sessionKey,
        //                Uin = (uint)customerInfoCache.BaseRequest.uin,
        //                DeviceID = customerInfoCache.BaseRequest.devicelId,
        //                ClientVersion = customerInfoCache.BaseRequest.clientVersion,
        //                DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
        //                Scene = (uint)customerInfoCache.BaseRequest.scene
        //            },
        //            ClientMediaId = ClientImgId_,
        //            Data = data_,
        //            DataMD5 = new micromsg.SKBuiltinString_t() { String = "" },
        //            DataLen = (uint)data.Length,
        //            TotalLen = (uint)datatotalength,
        //            MediaType = (uint)mediaType,
        //            StartPos = (uint)Startpos,

        //        };
        //        Startpos = Startpos + count;
        //        var src = Util.Serialize(uploadMediaReq);
        //        int bufferlen = src.Length;
        //        //组包
        //        byte[] SendDate = pack(src, (int)137, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
        //        //发包
        //        byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl,SendDate, "/cgi-bin/micromsg-bin/bakchatuploadmedia", customerInfoCache.Proxy);
        //        if (RetDate.Length > 32)
        //        {
        //            var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
        //            RespProtobuf = packinfo.body;
        //            if (packinfo.m_bCompressed)
        //            {
        //                RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
        //            }
        //            else
        //            {
        //                RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
        //            }

        //        }
        //        else
        //        {
        //            throw new ExpiredException("用户可能退出,请重新登陆");
        //        }

        //        uploadMediaRes = Util.Deserialize<micromsg.UploadMediaResponse>(RespProtobuf);
        //        if (uploadMediaRes == null || uploadMediaRes.BaseResponse != null && uploadMediaRes.BaseResponse.Ret != (int)RetConst.MM_OK)
        //        {
        //            throw new Exception("发送失败");
        //        }
        //    }//

        //    return uploadMediaRes;
        //}

        public micromsg.UploadHDHeadImgResponse UploadHeadImage(string wxId, byte[] buffer)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            MemoryStream imgStream = new MemoryStream(buffer);

            int Startpos = 0;//起始位置
            int datalen = 50000;//数据分块长度
            long datatotalength = imgStream.Length;

            var uploadHDHeadImgResponse = new micromsg.UploadHDHeadImgResponse();
            int mUid = 0;
            string cookie = null;
            var currentTime = CurrentTime_().ToString();
            while (Startpos < (int)datatotalength)
            {//
                int count = 0;
                if (datatotalength - Startpos > datalen)
                {
                    count = datalen;
                }
                else
                {
                    count = (int)datatotalength - Startpos;
                }

                byte[] data = new byte[count];
                imgStream.Seek(Startpos, SeekOrigin.Begin);
                imgStream.Read(data, 0, count);


                micromsg.SKBuiltinBuffer_t data_ = new micromsg.SKBuiltinBuffer_t();
                data_.Buffer = data;
                data_.iLen = (uint)data.Length;

                micromsg.UploadHDHeadImgRequest uploadHDHeadImgRequest = new micromsg.UploadHDHeadImgRequest()
                {
                    BaseRequest = new micromsg.BaseRequest()
                    {
                        SessionKey = customerInfoCache.BaseRequest.sessionKey,
                        Uin = (uint)customerInfoCache.BaseRequest.uin,
                        DeviceID = customerInfoCache.BaseRequest.devicelId,
                        ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                        DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                        Scene = (uint)customerInfoCache.BaseRequest.scene
                    },
                    HeadImgType = 1,
                    ImgHash = currentTime,
                    Data = data_,
                    UserName = wxId,
                    TotalLen = (uint)datatotalength,
                    StartPos = (uint)Startpos,


                };
                Startpos = Startpos + count;
                var src = Util.Serialize(uploadHDHeadImgRequest);
                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, (int)0x9d, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadhdheadimg", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }

                uploadHDHeadImgResponse = Util.Deserialize<micromsg.UploadHDHeadImgResponse>(RespProtobuf);
                if (uploadHDHeadImgResponse == null || uploadHDHeadImgResponse.BaseResponse != null && uploadHDHeadImgResponse.BaseResponse.Ret != (int)RetConst.MM_OK)
                {
                    throw new Exception("上传失败");
                }
            }//

            return uploadHDHeadImgResponse;
        }

        public micromsg.UploadAppAttachResponse UploadFile(string wxId, byte[] buffer, int mediaType)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            MemoryStream imgStream = new MemoryStream(buffer);

            int Startpos = 0;//起始位置
            int datalen = 50000;//数据分块长度
            long datatotalength = imgStream.Length;

            var uploadAppAttachResponse = new micromsg.UploadAppAttachResponse();
            int mUid = 0;
            string cookie = null;
            while (Startpos < (int)datatotalength)
            {//
                int count = 0;
                if (datatotalength - Startpos > datalen)
                {
                    count = datalen;
                }
                else
                {
                    count = (int)datatotalength - Startpos;
                }

                byte[] data = new byte[count];
                imgStream.Seek(Startpos, SeekOrigin.Begin);
                imgStream.Read(data, 0, count);


                micromsg.SKBuiltinBuffer_t data_ = new micromsg.SKBuiltinBuffer_t();
                data_.Buffer = data;
                data_.iLen = (uint)data.Length;

                micromsg.UploadAppAttachRequest uploadMediaReq = new micromsg.UploadAppAttachRequest()
                {
                    BaseRequest = new micromsg.BaseRequest()
                    {
                        SessionKey = customerInfoCache.BaseRequest.sessionKey,
                        Uin = (uint)customerInfoCache.BaseRequest.uin,
                        DeviceID = customerInfoCache.BaseRequest.devicelId,
                        ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                        DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                        Scene = (uint)customerInfoCache.BaseRequest.scene
                    },
                    ClientAppDataId = CurrentTime_().ToString(),
                    Data = data_,
                    UserName = wxId,
                    DataLen = (uint)data.Length,
                    TotalLen = (uint)datatotalength,
                    Type = (uint)mediaType,
                    StartPos = (uint)Startpos,


                };
                Startpos = Startpos + count;
                var src = Util.Serialize(uploadMediaReq);
                int bufferlen = src.Length;
                //组包
                byte[] SendDate = pack(src, (int)105, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                //发包
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/uploadappattach", customerInfoCache.Proxy);
                if (RetDate.Length > 32)
                {
                    var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }

                uploadAppAttachResponse = Util.Deserialize<micromsg.UploadAppAttachResponse>(RespProtobuf);
                if (uploadAppAttachResponse == null || uploadAppAttachResponse.BaseResponse != null && uploadAppAttachResponse.BaseResponse.Ret != (int)RetConst.MM_OK)
                {
                    throw new Exception("发送失败");
                }
            }//

            return uploadAppAttachResponse;
        }

        /// <summary>
        /// 发送app信息
        /// </summary>
        /// <param name="Content">xml内容</param>
        /// <param name="ToUserName">接收人</param>
        /// <param name="FromUserName">发送人</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public micromsg.SendAppMsgResponse SendAppMsg(string Content, string toWxid, string wxId, int type = 8)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.SendAppMsgRequest sendAppMsg_ = new micromsg.SendAppMsgRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
            };
            sendAppMsg_.Msg = new micromsg.AppMsg();
            sendAppMsg_.Msg.ClientMsgId = CurrentTime_().ToString();
            sendAppMsg_.Msg.Content = Content;
            sendAppMsg_.Msg.ToUserName = toWxid;
            sendAppMsg_.Msg.FromUserName = wxId;
            sendAppMsg_.Msg.Type = (uint)type;

            var src = Util.Serialize(sendAppMsg_);

            byte[] RespProtobuf = new byte[0];

            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 222, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/sendappmsg", customerInfoCache.Proxy);

            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var SendAppMsgResponse_ = Util.Deserialize<micromsg.SendAppMsgResponse>(RespProtobuf);
            return SendAppMsgResponse_;

        }

        public micromsg.HeartBeatResponse HeartBeat(string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.HeartBeatRequest heartBeatRequest = new micromsg.HeartBeatRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                TimeStamp = (uint)CurrentTime_(),
                KeyBuf = new micromsg.SKBuiltinBuffer_t(),
                BlueToothBroadCastContent = new micromsg.SKBuiltinBuffer_t(),
                Scene = 0



            };

            byte[] RespProtobuf = null;
            var src = Util.Serialize(heartBeatRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_HEARTBEAT, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_HEARTBEAT, customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var heartBeatResponse = Util.Deserialize<micromsg.HeartBeatResponse>(RespProtobuf);

            return heartBeatResponse;
        }

        /// <summary>
        /// 获取新的朋友
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="opType"></param>
        /// <returns></returns>
        public micromsg.GetMFriendResponse GetMFriend(string wxId, int opType)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            string md5 = Guid.NewGuid().ToString();
            int sence = 0;
            micromsg.GetMFriendRequest mFriendRequest = new micromsg.GetMFriendRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                OpType = (uint)opType,
                MD5 = md5,
                Scene = (uint)sence,

            };

            byte[] RespProtobuf = null;
            var src = Util.Serialize(mFriendRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)0x8e, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/getmfriend", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var profileResponse = Util.Deserialize<micromsg.GetMFriendResponse>(RespProtobuf);

            return profileResponse;
        }

        public NewGetInviteFriendResponse GetNewGetInviteFriend(string wxId, int friendType = 0)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];


            NewGetInviteFriendRequest newGetInviteFriendRequest = new NewGetInviteFriendRequest()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                friendType = (uint)friendType,
            };

            var src = Util.Serialize(newGetInviteFriendRequest);


            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_NEWGETINVITEFRIEND, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_NEWGETINVITEFRIEND, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var newGetInviteFriendResponse = Util.Deserialize<NewGetInviteFriendResponse>(RespProtobuf);
            return newGetInviteFriendResponse;
        }


        /// <summary>
        /// 获取登陆Url
        /// </summary>
        /// <param name="wxId">微信Id</param>
        /// <param name="uuid">uuid</param>
        /// <returns></returns>
        public micromsg.GetLoginURLResponse GetLoginURL(string wxId, string uuid)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            micromsg.GetLoginURLRequest loginURLRequest = new micromsg.GetLoginURLRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                UUID = uuid,
                FromDeviceID = customerInfoCache.DeviceId
            };

            byte[] RespProtobuf = null;
            var src = Util.Serialize(loginURLRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)0x217, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/getloginurl", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var profileResponse = Util.Deserialize<micromsg.GetLoginURLResponse>(RespProtobuf);

            return profileResponse;
        }


        /// <summary>
        /// # cmdid = 23 设置个人选项开关 key 4=加我为朋友时需要验证 |7=向我推荐通讯录好友 value:1=open 2=close
        ///# cmdid = 64 设置昵称签名    key 1=设置昵称 2=设置起签名，value=值
        ///# cmdid = 16 推出群聊 key = 0， value = 群号
        ///# cmdid =1 设置性别地区签名 key = 0  value = {"sex":1,"province":"Hunan","city":"Changsha","signature":"666666"}
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="cmdId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public micromsg.OplogResponse OpLpg(string wxId, int cmdId, object value)
        {
            //这里是从redis里获取用户的信息包括了aeskey,cookie,等一系列信息
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            //这里是判断信息是失效
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            //这里开始组包了
            //这里是构建一个变量中存放着组包信息,这句你在mmpro里面可以找到
            micromsg.OplogRequest oplogRequest = new micromsg.OplogRequest();
            micromsg.CmdList cmdList = new micromsg.CmdList();

          
            //这里是参数,具体怎么获得的这个参数呢,就查看MMPRO
            micromsg.CmdItem cmdItem = new micromsg.CmdItem()
            {
                CmdId = cmdId

            };
            //buff就不说是什么了，你肯定懂得
            var buffer = Util.Serialize(value);

    

            //这里就是序列长度了.并且把数据存放进去
            micromsg.SKBuiltinBuffer_t dATA = new micromsg.SKBuiltinBuffer_t()
            {
                iLen = (uint)buffer.Length,
                Buffer = buffer
            };

            //dATA是一个全局变量,你去看看是啥
            cmdItem.CmdBuf = dATA;
            cmdList.List.Add(cmdItem);
            cmdList.Count = 1;
            //这里是往里面添加参数。具体参数是需要去调试的
            oplogRequest.Oplog = cmdList;

            byte[] RespProtobuf = null;
            var src = Util.Serialize(oplogRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)0x217, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/oplog", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var oplogResponse = Util.Deserialize<micromsg.OplogResponse>(RespProtobuf);

            return oplogResponse;
        }


        public micromsg.ExtDeviceLoginConfirmGetResponse ExtDeviceLoginConfirmGet(string wxId, string url)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.ExtDeviceLoginConfirmGetRequest loginURLRequest = new micromsg.ExtDeviceLoginConfirmGetRequest()
            {
                LoginUrl = url
            };

            byte[] RespProtobuf = null;
            var src = Util.Serialize(loginURLRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)971, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/extdeviceloginconfirmget", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var extDeviceLoginConfirmGetResponse = Util.Deserialize<micromsg.ExtDeviceLoginConfirmGetResponse>(RespProtobuf);

            return extDeviceLoginConfirmGetResponse;
        }

        public string Get62Data(string wxId)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            return Util.SixTwoData(customerInfoCache.DeviceId);

        }
        /// <summary>
        /// 确认扫码登陆
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="loginUrl"></param>
        /// <returns></returns>
        public micromsg.ExtDeviceLoginConfirmOKResponse ExtDeviceLoginConfirmOK(string wxId, string loginUrl)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }

            micromsg.ExtDeviceLoginConfirmOKRequest loginURLRequest = new micromsg.ExtDeviceLoginConfirmOKRequest()
            {
                LoginUrl = loginUrl
            };

            byte[] RespProtobuf = null;
            var src = Util.Serialize(loginURLRequest);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 972, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/extdeviceloginconfirmok", customerInfoCache.Proxy);
            int muid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            var extDeviceLoginConfirmOKResponse = Util.Deserialize<micromsg.ExtDeviceLoginConfirmOKResponse>(RespProtobuf);

            return extDeviceLoginConfirmOKResponse;
        }

        /// <summary>
        /// v1 v2操作
        /// </summary>
        /// <param name="opCode">1关注公众号2打招呼 主动添加好友3通过好友请求</param>
        /// <param name="Content">内容</param>
        /// <param name="antispamTicket">v2</param>
        /// <param name="value">v1</param>
        /// <param name="sceneList">2来源邮箱3来源微信号12来源QQ 13来源通讯录14群聊15手机号17 名片18附近的人25漂流瓶29摇一摇30二维码</param>
        /// <returns></returns>
        public VerifyUserResponese VerifyUser(string wxId, VerifyUserOpCode opCode, string Content, string antispamTicket, string value, byte sceneList = 0x0f)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            VerifyUser[] verifyUser_ = new VerifyUser[1];
            VerifyUser user = new VerifyUser();

            user.value = value;

            user.antispamTicket = antispamTicket;
            user.friendFlag = 0;
            user.scanQrcodeFromScene = 0;
            if (opCode == VerifyUserOpCode.MM_VERIFYUSER_VERIFYOK)
            {
                user.verifyUserTicket = antispamTicket;
            }
            verifyUser_[0] = user;

            VerifyUserRequest1 verifyUser_b = new VerifyUserRequest1()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                SceneListNumFieldNumber = (uint)1,
                opcode = opCode,
                sceneList = new byte[] { sceneList },
                verifyContent = Content,
                verifyUserListSize = 1,
                verifyUserList = verifyUser_,
            };

            var src = Util.Serialize(verifyUser_b);


            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_VERIFYUSER, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_VERIFYUSER, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var VerifyUseResponse_ = Util.Deserialize<VerifyUserResponese>(RespProtobuf);
            return VerifyUseResponse_;
        }

        /// <summary>
        /// v1 v2操作
        /// </summary>
        /// <param name="opCode">1关注公众号2打招呼 主动添加好友3通过好友请求</param>
        /// <param name="Content">内容</param>
        /// <param name="antispamTicket">v2</param>
        /// <param name="value">v1</param>
        /// <param name="sceneList">1来源QQ2来源邮箱3来源微信号14群聊15手机号18附近的人25漂流瓶29摇一摇30二维码13来源通讯录</param>
        /// <returns></returns>
        public VerifyUserResponese VerifyUserList(string wxId, VerifyUserOpCode opCode, string Content, VerifyUser[] verifyUsers, byte[] sceneList )
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            byte[] RespProtobuf = new byte[0];
            //VerifyUser[] verifyUser_ = verifyUsers;

            //VerifyUser user = new VerifyUser();
            //user.value = value;
            //user.antispamTicket = antispamTicket;
            //user.friendFlag = 0;
            //user.scanQrcodeFromScene = 0;


            VerifyUserRequest1 verifyUser_b = new VerifyUserRequest1()
            {
                baseRequest = new BaseRequest()
                {
                    sessionKey = customerInfoCache.BaseRequest.sessionKey,
                    uin = customerInfoCache.BaseRequest.uin,
                    devicelId = customerInfoCache.BaseRequest.devicelId,
                    clientVersion = customerInfoCache.BaseRequest.clientVersion,
                    osType = customerInfoCache.BaseRequest.osType,
                    scene = customerInfoCache.BaseRequest.scene
                },
                SceneListNumFieldNumber = (uint)sceneList.Count(),
                opcode = opCode,
                sceneList = sceneList,
                verifyContent = Content,
                verifyUserListSize = (uint)verifyUsers.Count(),
                verifyUserList = verifyUsers,
            };

            var src = Util.Serialize(verifyUser_b);


            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_VERIFYUSER, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_VERIFYUSER, customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var VerifyUseResponse_ = Util.Deserialize<VerifyUserResponese>(RespProtobuf);
            return VerifyUseResponse_;
        }
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        /// <param name="customerInfoCache"></param>
        /// <returns></returns>
        public mm.command.NewInitResponse NewInit(CustomerInfoCache customerInfoCache)
        {
            //
            //var cache = this._redisCache;
            //var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            //if (customerInfoCache == null)
            //{
            //    throw new ExpiredException("缓存失效，请重新生成二维码登录");
            //}
            var RespProtobuf = new byte[0];
            //压缩前长度和压缩后长度
            int lenBeforeZip = 0;
            int lenAfterZip = 0;

            //生成google对象
            mm.command.NewInitRequest niqObj = GoogleProto.CreateNewInitRequestEntity((uint)customerInfoCache.MUid, Encoding.Default.GetString(customerInfoCache.AesKey), customerInfoCache.WxId, customerInfoCache.DeviceId, osType, customerInfoCache.InitSyncKey, customerInfoCache.MaxSyncKey, version);

            byte[] niqData = niqObj.ToByteArray();
            int mUid = 0;
            string cookie = null;

            int bufferlen = niqData.Length;
            //组包
            byte[] SendDate = pack(niqData, 139, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/newinit", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            mm.command.NewInitResponse niReceive = mm.command.NewInitResponse.ParseFrom(RespProtobuf);
            if (niReceive.Base.Ret == 0)
            {
                customerInfoCache.InitSyncKey = niReceive.CurrentSynckey.Buffer.ToByteArray();
                customerInfoCache.MaxSyncKey = niReceive.MaxSynckey.Buffer.ToByteArray();
            }
            return niReceive;
        }

        /// <summary>
        /// 获取高清图片
        /// </summary>
        /// <param name="datatotalength"></param>
        /// <param name="MsgId"></param>
        /// <param name="wxId"></param>
        /// <param name="toWxid"></param>
        /// <param name="CompressType"></param>
        /// <returns></returns>
        public byte[] GetMsgBigImg(long datatotalength, int MsgId, string wxId, string toWxid, int StartPos, int datalen, uint CompressType = 1)
        {

            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            List<byte> downImgData = new List<byte>();
            var GetMsgImgResponse_ = new micromsg.GetMsgImgResponse();
            if (datalen > 65535)
            {
                datalen = 65535;
            }
            using (MemoryStream ms = new MemoryStream((int)datatotalength))
            {
                while (StartPos < datatotalength)
                {

                    int count = 0;
                    if (datatotalength - StartPos >= datalen)
                    {
                        count = datalen;
                    }
                    else
                    {
                        count = (int)datatotalength - StartPos;
                    }

                    micromsg.SKBuiltinString_t ToUserName_ = new micromsg.SKBuiltinString_t();
                    ToUserName_.String = toWxid;

                    micromsg.SKBuiltinString_t FromUserName_ = new micromsg.SKBuiltinString_t();
                    FromUserName_.String = wxId;
                    micromsg.GetMsgImgRequest getMsgImg_ = new micromsg.GetMsgImgRequest()
                    {
                        BaseRequest = new micromsg.BaseRequest()
                        {
                            SessionKey = customerInfoCache.BaseRequest.sessionKey,
                            Uin = (uint)customerInfoCache.BaseRequest.uin,
                            DeviceID = customerInfoCache.BaseRequest.devicelId,
                            ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                            DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                            Scene = (uint)customerInfoCache.BaseRequest.scene
                        },

                        MsgId = (uint)MsgId,
                        StartPos = (uint)StartPos,
                        DataLen = (uint)count,
                        TotalLen = (uint)datatotalength,
                        CompressType = CompressType,//hdlength  1高清0缩略
                        ToUserName = ToUserName_,
                        FromUserName = FromUserName_
                    };

                    var src = Util.Serialize(getMsgImg_);

                    byte[] RespProtobuf = new byte[0];

                    int mUid = 0;
                    string cookie = null;
                    int bufferlen = src.Length;
                    //组包
                    byte[] SendDate = pack(src, 109, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                    //发包
                    byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/getmsgimg", customerInfoCache.Proxy);
                    if (RetDate.Length > 32)
                    {
                        var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                        //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                        RespProtobuf = packinfo.body;
                        if (packinfo.m_bCompressed)
                        {
                            RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                        }
                        else
                        {
                            RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                        }

                    }
                    else
                    {
                        throw new ExpiredException("用户可能退出,请重新登陆");
                    }

                    GetMsgImgResponse_ = Util.Deserialize<micromsg.GetMsgImgResponse>(RespProtobuf);
                    if (GetMsgImgResponse_.Data != null)
                    {
                        count = (int)GetMsgImgResponse_.Data.iLen;
                        StartPos += count;
                        ms.Write(GetMsgImgResponse_.Data.Buffer, 0, (int)GetMsgImgResponse_.Data.iLen);
                        Thread.Sleep(50);
                    }


                }
                return ms.ToBuffer();
            }

        }

        /// <summary>
        /// 获取视频
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="toWxid"></param>
        /// <param name="MsgId"></param>
        /// <param name="datatotalength"></param>
        /// <param name="StartPos"></param>
        /// <param name="datalen"></param>
        /// <param name="TotalLen"></param>
        /// <returns></returns>
        public byte[] GetVideo(string wxId, string toWxid, int MsgId, long datatotalength, int StartPos, int datalen, uint CompressType = 1)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            if (datalen > 65535)
            {
                datalen = 65535;
            }
            using (MemoryStream ms = new MemoryStream((int)datatotalength))
            {
                while (StartPos < datatotalength)
                {

                    int count = 0;
                    if (datatotalength - StartPos >= datalen)
                    {
                        count = datalen;
                    }
                    else
                    {
                        count = (int)datatotalength - StartPos;
                    }
                    var GetMsgImgResponse_ = new micromsg.DownloadVideoResponse();

                    micromsg.SKBuiltinString_t ToUserName_ = new micromsg.SKBuiltinString_t();
                    ToUserName_.String = toWxid;
                    micromsg.SKBuiltinString_t FromUserName_ = new micromsg.SKBuiltinString_t();
                    FromUserName_.String = wxId;
                    micromsg.DownloadVideoRequest downloadVideoRequest = new micromsg.DownloadVideoRequest()
                    {
                        BaseRequest = new micromsg.BaseRequest()
                        {
                            SessionKey = customerInfoCache.BaseRequest.sessionKey,
                            Uin = (uint)customerInfoCache.BaseRequest.uin,
                            DeviceID = customerInfoCache.BaseRequest.devicelId,
                            ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                            DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                            Scene = (uint)customerInfoCache.BaseRequest.scene
                        },

                        MsgId = (uint)MsgId,
                        StartPos = (uint)StartPos,
                        NetworkEnv = 1,
                        TotalLen = (uint)count,
                        MxPackSize = (uint)datatotalength,


                    };

                    var src = Util.Serialize(downloadVideoRequest);

                    byte[] RespProtobuf = new byte[0];

                    int mUid = 0;
                    string cookie = null;
                    int bufferlen = src.Length;
                    //组包
                    byte[] SendDate = pack(src, 150, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
                    //发包
                    byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/downloadvideo", customerInfoCache.Proxy);
                    if (RetDate.Length > 32)
                    {
                        var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                        //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                        RespProtobuf = packinfo.body;
                        if (packinfo.m_bCompressed)
                        {
                            RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                        }
                        else
                        {
                            RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                        }

                    }
                    else
                    {
                        throw new ExpiredException("用户可能退出,请重新登陆");
                    }

                    GetMsgImgResponse_ = Util.Deserialize<micromsg.DownloadVideoResponse>(RespProtobuf);

                    if (GetMsgImgResponse_.Data.iLen != 0)
                    {
                        count = (int)GetMsgImgResponse_.Data.iLen;
                        StartPos += count;
                        ms.Write(GetMsgImgResponse_.Data.Buffer, 0, (int)GetMsgImgResponse_.Data.iLen);
                        Thread.Sleep(50);
                    }


                }
                return ms.ToBuffer();
            }

        }



        public ManualAuthResponse TwiceLogin(string wxId, int count = 1)
        {
            var cache = this._redisCache;
            var customerInfoCache = cache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), wxId);
            if (customerInfoCache == null)
            {
                throw new ExpiredException($"{wxId}缓存失效，请重新生成二维码登录");
            }
            var result = checkManualAuth(customerInfoCache, count);
            cache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.WxId, customerInfoCache);
            return result;
        }


        /// <summary>
        /// 二次登录
        /// </summary>
        /// <param name="AutoAuthKey">一次成功登录时返回的autoauthkey</param>
        /// <returns></returns>
        public ManualAuthResponse AutoAuthRequest(CustomerInfoCache customerInfoCache)
        {
            //GenerateECKey(713, customerInfoCache.PubKeyHUb, customerInfoCache.PriKeyBuf);
            micromsg.AutoAuthRequest autoAuthRequest = new micromsg.AutoAuthRequest()
            {
                AesReqData = new micromsg.AutoAuthAesReqData()
                {
                    BaseRequest = new micromsg.BaseRequest()
                    {
                        SessionKey = customerInfoCache.BaseRequest.sessionKey,
                        Uin = (uint)customerInfoCache.BaseRequest.uin,
                        DeviceID = customerInfoCache.BaseRequest.devicelId,
                        ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                        DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                        Scene = (uint)customerInfoCache.BaseRequest.scene
                    },
                    AutoAuthKey = new micromsg.SKBuiltinBuffer_t()
                    {
                        Buffer = customerInfoCache.AutoAuthTicket,
                        iLen = (uint)customerInfoCache.AutoAuthTicket.Length
                    },
                    BaseReqInfo = new micromsg.BaseAuthReqInfo()
                    {
                        AuthReqFlag = new uint(),
                        AuthTicket = "",
                        CliDBEncryptInfo = new micromsg.SKBuiltinBuffer_t()
                        {
                            Buffer = new byte[0],
                            iLen = 0
                        },
                        CliDBEncryptKey = new micromsg.SKBuiltinBuffer_t()
                        {
                            Buffer = new byte[0],
                            iLen = 0
                        },
                        WTLoginImgReqInfo = new micromsg.WTLoginImgReqInfo()
                        {
                            ImgCode = "",
                            ImgSid = "",
                            KSid = new micromsg.SKBuiltinBuffer_t()
                            {
                                Buffer = new byte[0],
                                iLen = 0
                            },

                        },

                        WxVerifyCodeReqInfo = new micromsg.WxVerifyCodeReqInfo()//3
                        {
                            VerifyContent = "",//2
                            VerifySignature = ""//1
                        },
                        WTLoginReqBuff = new micromsg.SKBuiltinBuffer_t()//1
                        {
                            Buffer = new byte[] { },//2
                            iLen = 0,//1
                        },
                    },
                    IMEI = Encoding.UTF8.GetString(customerInfoCache.DeviceId),
                    TimeZone = "8.00",
                    DeviceName = customerInfoCache.Device,
                    Language = "zh_CN",
                    BuiltinIPSeq = 0,
                    Signature = "",
                    DeviceType = customerInfoCache.BaseRequest.osType,// $@"<softtype><k3>9.0.2</k3><k9>iPad</k9><k10>2</k10><k19>{Guid.NewGuid().ToString().ToUpper()}</k19><k20>{Guid.NewGuid().ToString().ToUpper()}</k20><k21>neihe_5GHz</k21><k22>(null)</k22><k24>b8:73:cf:87:a9:53</k24><k33>\345\276\256\344\277\241</k33><k47>1</k47><k50>1</k50><k51>com.tencent.xin</k51><k54>iPad4,4</k54></softtype>",

                },
                RsaReqData = new micromsg.AutoAuthRsaReqData()
                {
                    AesEncryptKey = new micromsg.SKBuiltinBuffer_t()
                    {
                        Buffer = customerInfoCache.AesKey,
                        iLen = 16
                    },
                    CliPubECDHKey = new micromsg.ECDHKey()
                    {
                        Key = new micromsg.SKBuiltinBuffer_t()
                        {
                            Buffer = customerInfoCache.PubKeyHUb,
                            iLen = (uint)customerInfoCache.PubKeyHUb.Length
                        },
                        Nid = 713,

                    }
                }

            };

            autoAuthRequest.AesReqData.ClientSeqID = autoAuthRequest.AesReqData.IMEI + "-" + ((int)CurrentTime_()).ToString();

            //用rsa对authkey进行压缩加密
            byte[] RsaReqBuf = Util.Serialize(autoAuthRequest.RsaReqData);
            //Console.WriteLine("RsaReq:\r\n" + CommUtil.ToHexStr(RsaReqBuf));
            byte[] rsaData = Util.compress_rsa_LOGIN(RsaReqBuf);

            //用aes对authkey进行压缩加密
            byte[] AuthAesData = Util.compress_aes(RsaReqBuf, customerInfoCache.AesKey);

            //用aes对设备信息进行压缩加密
            byte[] AesReqBuf = Util.Serialize(autoAuthRequest.AesReqData);
            //Console.WriteLine("aesReq:\r\n" + CommUtil.ToHexStr(AesReqBuf));
            byte[] aesData = Util.compress_aes(AesReqBuf, customerInfoCache.AesKey);


            byte[] Body = new byte[] { };
            Body = Body.Concat(RsaReqBuf.Length.ToByteArray(Endian.Big)).ToArray();
            Body = Body.Concat(AesReqBuf.Length.ToByteArray(Endian.Big)).ToArray();
            Body = Body.Concat(rsaData.Length.ToByteArray(Endian.Big)).ToArray();
            Body = Body.Concat(AuthAesData.Length.ToByteArray(Endian.Big)).ToArray();
            Body = Body.Concat(rsaData).ToArray();
            Body = Body.Concat(AuthAesData).ToArray();
            Body = Body.Concat(aesData).ToArray();
            var head = MakeHead(Body, 702, Body.Length, customerInfoCache.MUid, customerInfoCache.Cookie, 9, true, true);

            byte[] retData = head.Concat(Body).ToArray();



            byte[] RespProtobuf = new byte[0];

            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, retData, "/cgi-bin/micromsg-bin/autoauth", customerInfoCache.Proxy);
            //Console.WriteLine(RetDate.ToString(16, 2));
            //var ret = HttpPost(@short + MM.URL.CGI_MANUALAUTH, head, null);
            //var lhead = LongLinkPack(LongLinkCmdId.SEND_MANUALAUTH_CMDID, seq++, head.Length);
            int mUid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                customerInfoCache.MUid = mUid;
                customerInfoCache.Cookie = cookie;
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            Debug.Print(RespProtobuf.ToString(16, 2));
            var ManualAuthResponse = Util.Deserialize<ManualAuthResponse>(RespProtobuf);
            return ManualAuthResponse;
        }



        /// <summary>
        /// 确定登录包 改用长连接
        /// </summary>
        /// <param name="wxnewpass">这是扫码成功过来伪密码</param>
        /// <param name="wxid">wxid</param>
        /// <returns></returns>
        private ManualAuthResponse ManualAuth_old(CustomerInfoCache customerInfoCache)
        {
            var RespProtobuf = new byte[0];
            GenerateECKey(713, customerInfoCache.PubKeyHUb, customerInfoCache.PriKeyBuf);
            //OpenSSLNativeClass.ECDH.GenEcdh(713, ref pub_key_buf, ref pri_key_buf);
            ManualAuthAccountRequest manualAuthAccountRequest = new ManualAuthAccountRequest()
            {
                aes = new AesKey()
                {
                    len = 16,
                    key = customerInfoCache.AesKey
                },
                ecdh = new Ecdh()
                {
                    ecdhkey = new EcdhKey()
                    {
                        key = customerInfoCache.PubKeyHUb,
                        len = 57
                    },
                    nid = 713
                },

                password1 = customerInfoCache.WxNewPass,
                password2 = null,
                userName = customerInfoCache.WxId
            };
            ManualAuthDeviceRequest manualAuthDeviceRequest = new ManualAuthDeviceRequest();
            //manualAuthDeviceRequest = Util.Deserialize<ManualAuthDeviceRequest>("0A310A0010001A1049AA7DB2F4A3FFE0E96218F6B92CDE3220A08E98B0012A1169506164206950686F6E65204F53382E34300112023A001A203363616137646232663461336666653065393632313866366239326364653332228D023C736F6674747970653E3C6B333E382E343C2F6B333E3C6B393E695061643C2F6B393E3C6B31303E323C2F6B31303E3C6B31393E45313841454344332D453630422D344635332D423838372D4339343436344437303836393C2F6B31393E3C6B32303E3C2F6B32303E3C6B32313E313030333C2F6B32313E3C6B32323E286E756C6C293C2F6B32323E3C6B32343E62383A66383A38333A33393A61643A62393C2F6B32343E3C6B33333EE5BEAEE4BFA13C2F6B33333E3C6B34373E313C2F6B34373E3C6B35303E313C2F6B35303E3C6B35313E6461697669732E495041443C2F6B35313E3C6B35343E69506164322C353C2F6B35343E3C6B36313E323C2F6B36313E3C2F736F6674747970653E2800322B33636161376462326634613366666530653936323138663662393263646533322D313532383535343230314204695061644A046950616452057A685F434E5A04382E3030680070AFC6EFD8057A054170706C65920102434E9A010B6461697669732E49504144AA010769506164322C35B00102BA01D50608CF0612CF060A08303030303030303310011AC0068A8DCEEE5AB9F4E16054EDA0545F7288B7951621A41446C1AEC0621B3CFE6926737F8298D0B52F467FDFC5EC936D512D332A1AC664E7DFEE734A5E403A72225F852734BF32F6FD623B95D17B64DC8D18FBB2CA2015113CD17518274BED4687D26F5D9E270687745541FA84921A16B50CFE487B1A88C3A91D838A2520AF8757F0E5ACE55BA599B9FCDF1595C3DAAD8E3A34C28BA39951D7A4CF9075CCC28721BA61E48C2DA1B853F3BE0D79AC63F47F2E3C4FF10D4D1CCC1D3002B6F63C228641C1EEB24686BA300853C355C268057D733B7898D20E6B43621419D8BCFCAED82C45377653234B7421238D00B25089670DDEBB03274B1D0D8C45D5A0EA7ECA9086254CCEAA8674ADE4DF905914437BC73D4C9D50CEC9ABCB927590D068DC10A810D376DAFB17A31F947765FF6A7F3B191EC40EEC4AA86FF8771CD2D717D25EE2B7555179AF4C611B9C6AD802B8FDAEAE36CA3497C438E8D4A06B1A7A570D74AAF6C244E8D23BA635FF0F27DCFCF5F6C4754A0049A620AE99012EB4936D34BAD267EAFDB12B67D5274272D3BC795B6454B4C2B768929007D0993F742A519D567ACD0369FCC9196D3CC04578F795026C336F2A29A012608C66E2068F5994210173C5A3B2720A4D040A6D2C3E873D56CE88F85CEFE4847743DEF1102653D42FBC3A31CA5BFE2E666D3542E6E1C5BCCE54D99EC934B183EED69FEA87D975666065E5903F366EFFE04627603FD64861C142A5A19EBD344BF194DE427FB4B70AA0D3CD972AC0A11EA6913E17366CA48966090E10B246BABABA553DBF89BEA4F55004C37E546ABABB8AA20E80B2A0ED21B6700F89699FD01983EDA71ACE6A44B6397605D30E88683BA4BB92A50DC7AFFB820089F157B8C83F7B5DCD35BABCC90501E2E6BDF83327A1059908C72EAF1B5A07CA6565A0888883966D26386C69293649BEC0913FE12C1ABA7B0B16261176E2F7D109FCF68A46B7C3AF7126E77224AA36891B703655CFEA2AAA8B5E095D8B204308133E63D0F0309E8B1CB5A21E9C8B27090859139C076723DE4C74578F6584888220A11A45CDDEC43A1F542552604C96FFE3A01006946086A864C182361B3659C1BDE9ECEA5236F5F38BA98A4C7E8C81A39D5CBA39B7A0F9FFA75AC59BB956595B58DAED58A0851D48B0B7A7407FA576E4956C".ToByteArray(16, 2));
            manualAuthDeviceRequest.Timestamp = (int)CurrentTime_();

            var clientCheckdata1 = new Random().NextBytes(847);
            manualAuthDeviceRequest.Clientcheckdat = new SKBuiltinString_() { buffer = clientCheckdata1, iLen = (uint)clientCheckdata1.Length };
            manualAuthDeviceRequest.imei = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString().Replace("-", ""));
            manualAuthDeviceRequest.clientSeqID = Encoding.UTF8.GetString(manualAuthDeviceRequest.imei) + "-" + ((int)CurrentTime_()).ToString();
            manualAuthDeviceRequest.baseRequest = GetBaseRequest(customerInfoCache.AesKey, customerInfoCache.DeviceId, 1);


            manualAuthDeviceRequest.softInfoXml = $"<softtype><k3>8.4</k3><k9>iPad</k9><k10>2</k10><k19>{Encoding.UTF8.GetString(customerInfoCache.DeviceId)}</k19><k20>{Encoding.UTF8.GetString(customerInfoCache.DeviceId)}</k20><k21>1003</k21><k22>(null)</k22><k24>b{new Random().Next(1, 9)}:f{new Random().Next(1, 9)}:{new Random().Next(1, 9)}3:39:{new Random().Next(1, 9)}d:b{new Random().Next(1, 9)}</k24><k33>微信</k33><k47>1</k47><k50>1</k50><k51>daivis.IPAD</k51><k54>iPad2,5</k54><k61>2</k61></softtype>";
            manualAuthDeviceRequest.loginDeviceName = customerInfoCache.Device;
            manualAuthDeviceRequest.deviceInfoXml = customerInfoCache.Device;
            manualAuthDeviceRequest.language = "zh_CN";
            manualAuthDeviceRequest.timeZone = "8.00";
            manualAuthDeviceRequest.deviceBrand = customerInfoCache.Device;
            manualAuthDeviceRequest.Iphonever = "iPad2,5";
            manualAuthDeviceRequest.Inputtype = 2;

            var account = Util.Serialize(manualAuthAccountRequest);
            byte[] device = Util.Serialize(manualAuthDeviceRequest);
            byte[] subHeader = new byte[] { };
            int dwLenAccountProtobuf = account.Length;
            subHeader = subHeader.Concat(dwLenAccountProtobuf.ToByteArray(Endian.Big)).ToArray();
            int dwLenDeviceProtobuf = device.Length;
            subHeader = subHeader.Concat(dwLenDeviceProtobuf.ToByteArray(Endian.Big)).ToArray();
            if (subHeader.Length > 0 && account.Length > 0 && device.Length > 0)
            {
                var cdata = Util.compress_rsa_LOGIN(account);
                int dwLenAccountRsa = cdata.Length;
                subHeader = subHeader.Concat(dwLenAccountRsa.ToByteArray(Endian.Big)).ToArray();
                byte[] body = subHeader;
                ManualAuthDeviceRequest m_ManualAuthDeviceRequest = Util.Deserialize<ManualAuthDeviceRequest>(device);
                //var t2=m_ManualAuthDeviceRequest.tag2.ToString(16, 2);

                var memoryStream = Util.Serialize(m_ManualAuthDeviceRequest);

                body = body.Concat(cdata).ToArray();

                body = body.Concat(Util.compress_aes(device, customerInfoCache.AesKey)).ToArray();
                //var head = MakeHead( body, MM.CGI_TYPE.CGI_TYPE_MANUALAUTH, 7);
                var head = MakeHead(body, (int)CGI_TYPE.CGI_TYPE_MANUALAUTH, body.Length, customerInfoCache.MUid, customerInfoCache.Cookie, 7, false);

                body = head.Concat(body).ToArray();

                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, body, URL.CGI_MANUALAUTH, customerInfoCache.Proxy);
                //Console.WriteLine(RetDate.ToString(16, 2));
                //var ret = HttpPost(@short + MM.URL.CGI_MANUALAUTH, head, null);
                //var lhead = LongLinkPack(LongLinkCmdId.SEND_MANUALAUTH_CMDID, seq++, head.Length);
                if (RetDate.Length > 32)
                {
                    int muid = 0;
                    string cookie = null;
                    var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                    customerInfoCache.MUid = muid;
                    customerInfoCache.Cookie = cookie;
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }

                }
                else
                {
                    throw new ExpiredException("用户可能退出,请重新登陆");
                }
                if (RespProtobuf == null) return null;
                var ManualAuthResponse = Util.Deserialize<ManualAuthResponse>(RespProtobuf);
                return ManualAuthResponse;
            }
            else
                return null;
            //return null;

        }

        /// <summary>
        /// 确定登录包 改用长连接
        /// </summary>
        /// <param name="wxnewpass">这是扫码成功过来伪密码</param>
        /// <param name="wxid">wxid</param>
        /// <returns></returns>
        public MM.ManualAuthResponse ManualAuth(CustomerInfoCache customerInfoCache)
        {

            //customerInfoCache.DeviceId = "49aa6db2f4a3ffe0e96618f6b92cde11".ToByteArray(16, 2);
            byte[] RespProtobuf = new byte[0];
            GenerateECKey(713, customerInfoCache.PubKeyHUb, customerInfoCache.PriKeyBuf);
            MM.ManualAuthAccountRequest manualAuthAccountRequest = new MM.ManualAuthAccountRequest
            {
                aes = new MM.AesKey
                {
                    len = 16,
                    key = customerInfoCache.AesKey
                },
                ecdh = new MM.Ecdh
                {
                    ecdhkey = new MM.EcdhKey
                    {
                        key = customerInfoCache.PubKeyHUb,
                        len = 57
                    },
                    nid = 713
                },
                password1 = customerInfoCache.WxNewPass,
                password2 = null,
                userName = customerInfoCache.WxId
            };
            MM.ManualAuthDeviceRequest manualAuthDeviceRequest = new MM.ManualAuthDeviceRequest();
            manualAuthDeviceRequest = Util.Deserialize<MM.ManualAuthDeviceRequest>("0A310A0010001A1049AA7DB2F4A3FFE0E96218F6B92CDE3220A08E98B0012A1169506164206950686F6E65204F53382E34300112023A001A203363616137646232663461336666653065393632313866366239326364653332228D023C736F6674747970653E3C6B333E382E343C2F6B333E3C6B393E695061643C2F6B393E3C6B31303E323C2F6B31303E3C6B31393E45313841454344332D453630422D344635332D423838372D4339343436344437303836393C2F6B31393E3C6B32303E3C2F6B32303E3C6B32313E313030333C2F6B32313E3C6B32323E286E756C6C293C2F6B32323E3C6B32343E62383A66383A38333A33393A61643A62393C2F6B32343E3C6B33333EE5BEAEE4BFA13C2F6B33333E3C6B34373E313C2F6B34373E3C6B35303E313C2F6B35303E3C6B35313E6461697669732E495041443C2F6B35313E3C6B35343E69506164322C353C2F6B35343E3C6B36313E323C2F6B36313E3C2F736F6674747970653E2800322B33636161376462326634613366666530653936323138663662393263646533322D313532383535343230314204695061644A046950616452057A685F434E5A04382E3030680070AFC6EFD8057A054170706C65920102434E9A010B6461697669732E49504144AA010769506164322C35B00102BA01D50608CF0612CF060A08303030303030303310011AC0068A8DCEEE5AB9F4E16054EDA0545F7288B7951621A41446C1AEC0621B3CFE6926737F8298D0B52F467FDFC5EC936D512D332A1AC664E7DFEE734A5E403A72225F852734BF32F6FD623B95D17B64DC8D18FBB2CA2015113CD17518274BED4687D26F5D9E270687745541FA84921A16B50CFE487B1A88C3A91D838A2520AF8757F0E5ACE55BA599B9FCDF1595C3DAAD8E3A34C28BA39951D7A4CF9075CCC28721BA61E48C2DA1B853F3BE0D79AC63F47F2E3C4FF10D4D1CCC1D3002B6F63C228641C1EEB24686BA300853C355C268057D733B7898D20E6B43621419D8BCFCAED82C45377653234B7421238D00B25089670DDEBB03274B1D0D8C45D5A0EA7ECA9086254CCEAA8674ADE4DF905914437BC73D4C9D50CEC9ABCB927590D068DC10A810D376DAFB17A31F947765FF6A7F3B191EC40EEC4AA86FF8771CD2D717D25EE2B7555179AF4C611B9C6AD802B8FDAEAE36CA3497C438E8D4A06B1A7A570D74AAF6C244E8D23BA635FF0F27DCFCF5F6C4754A0049A620AE99012EB4936D34BAD267EAFDB12B67D5274272D3BC795B6454B4C2B768929007D0993F742A519D567ACD0369FCC9196D3CC04578F795026C336F2A29A012608C66E2068F5994210173C5A3B2720A4D040A6D2C3E873D56CE88F85CEFE4847743DEF1102653D42FBC3A31CA5BFE2E666D3542E6E1C5BCCE54D99EC934B183EED69FEA87D975666065E5903F366EFFE04627603FD64861C142A5A19EBD344BF194DE427FB4B70AA0D3CD972AC0A11EA6913E17366CA48966090E10B246BABABA553DBF89BEA4F55004C37E546ABABB8AA20E80B2A0ED21B6700F89699FD01983EDA71ACE6A44B6397605D30E88683BA4BB92A50DC7AFFB820089F157B8C83F7B5DCD35BABCC90501E2E6BDF83327A1059908C72EAF1B5A07CA6565A0888883966D26386C69293649BEC0913FE12C1ABA7B0B16261176E2F7D109FCF68A46B7C3AF7126E77224AA36891B703655CFEA2AAA8B5E095D8B204308133E63D0F0309E8B1CB5A21E9C8B27090859139C076723DE4C74578F6584888220A11A45CDDEC43A1F542552604C96FFE3A01006946086A864C182361B3659C1BDE9ECEA5236F5F38BA98A4C7E8C81A39D5CBA39B7A0F9FFA75AC59BB956595B58DAED58A0851D48B0B7A7407FA576E4956C".ToByteArray(16, 2));
            manualAuthDeviceRequest.Timestamp = (int)CurrentTime_();
            manualAuthDeviceRequest.imei = customerInfoCache.DeviceId;
            manualAuthDeviceRequest.clientSeqID = manualAuthDeviceRequest.imei + "-" + ((int)CurrentTime_()).ToString();
            manualAuthDeviceRequest.baseRequest = GetBaseRequest(customerInfoCache.AesKey, customerInfoCache.DeviceId, 1); ;
            byte[] account = Util.Serialize<MM.ManualAuthAccountRequest>(manualAuthAccountRequest);
            byte[] device = Util.Serialize<MM.ManualAuthDeviceRequest>(manualAuthDeviceRequest);
            byte[] subHeader = new byte[0];
            int dwLenAccountProtobuf = account.Length;
            subHeader = subHeader.Concat(dwLenAccountProtobuf.ToByteArray(Endian.Big)).ToArray<byte>();
            int dwLenDeviceProtobuf = device.Length;
            subHeader = subHeader.Concat(dwLenDeviceProtobuf.ToByteArray(Endian.Big)).ToArray<byte>();
            bool flag = subHeader.Length != 0 && account.Length != 0 && device.Length != 0;
            MM.ManualAuthResponse result;
            if (flag)
            {
                byte[] cdata = Util.compress_rsa_LOGIN(account);
                int dwLenAccountRsa = cdata.Length;
                subHeader = subHeader.Concat(dwLenAccountRsa.ToByteArray(Endian.Big)).ToArray<byte>();
                byte[] body = subHeader;
                MM.ManualAuthDeviceRequest m_ManualAuthDeviceRequest = Util.Deserialize<MM.ManualAuthDeviceRequest>(device);
                byte[] memoryStream = Util.Serialize<MM.ManualAuthDeviceRequest>(m_ManualAuthDeviceRequest);
                body = body.Concat(cdata).ToArray<byte>();
                body = body.Concat(Util.compress_aes(device, customerInfoCache.AesKey)).ToArray<byte>();
                byte[] head = MakeHead(body, (int)CGI_TYPE.CGI_TYPE_MANUALAUTH, body.Length, customerInfoCache.MUid, customerInfoCache.Cookie, 7, false); ;
                body = head.Concat(body).ToArray<byte>();
                byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, body, URL.CGI_MANUALAUTH, customerInfoCache.Proxy);
                bool flag2 = RetDate.Length > 32;
                if (flag2)
                {
                    int muid = 0;
                    string cookie = null;
                    var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                    customerInfoCache.MUid = muid;
                    customerInfoCache.Cookie = cookie;
                    RespProtobuf = packinfo.body;
                    bool bCompressed = packinfo.m_bCompressed;
                    if (bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                    }
                }
                bool flag3 = RespProtobuf == null;
                if (flag3)
                {
                    result = null;
                }
                else
                {
                    MM.ManualAuthResponse ManualAuthResponse = Util.Deserialize<MM.ManualAuthResponse>(RespProtobuf);
                    result = ManualAuthResponse;
                }
            }
            else
            {
                result = null;
            }
            return result;
        }

        public ManualAuthResponse UserLogin(string username, string pass, string Data62, string proxyip = null, string proxyusername = null, string proxypassword = null, CustomerInfoCache customerInfoCache = null, int index = 1)
        {
            string imei = null;
            string devicelId = null;
            byte[] aesKey = GetAeskey();
            ProxyIpCacheResp proxy = null;
            //if (IpHelper.IsProxy)
            //{
                //proxy = IpHelper.GetProxy();
                if (!string.IsNullOrEmpty(proxyip))
                {
                    proxy = new ProxyIpCacheResp()
                    {
                        ProxyIp = proxyip,
                        Username = proxyusername,
                        Password = proxypassword
                    };
                    try
                    {
                        var res = Wechat.Protocol.Util.HttpPostTestProxy("http://www.baidu.com", proxy);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"{proxy.ProxyIp}代理超时");
                        proxy = null;
                    }

                }

         //   }
            if (Data62 != "")
            {
                devicelId = Util.Get62Key(Data62);
                imei = devicelId;
                devicelId = "49" + imei.Substring(2, imei.Length - 2); //202c2405786fefb2a6cc841063e360f9
            }
            else
            {
                imei = devicelId; //'326db4438a32895c03a878ab248439fe';
            }

            var RespProtobuf = new byte[0];

            byte[] pri_key_buf = new byte[328];
            byte[] pub_key_buf = new byte[57];
            GenerateECKey(713, pub_key_buf, pri_key_buf);
            //OpenSSLNativeClass.ECDH.GenEcdh(713, ref pub_key_buf, ref pri_key_buf);
            ManualAuthAccountRequest manualAuthAccountRequest = new ManualAuthAccountRequest()
            {
                aes = new AesKey()
                {
                    len = 16,
                    key = GetAeskey()
                },
                ecdh = new Ecdh()
                {
                    ecdhkey = new EcdhKey()
                    {
                        key = pub_key_buf,
                        len = 57
                    },
                    nid = 713
                },

                password1 = Util.MD5Encrypt(pass),
                password2 = Util.MD5Encrypt(pass),
                userName = username
            };
            ManualAuthDeviceRequest manualAuthDeviceRequest = new ManualAuthDeviceRequest();
            //manualAuthDeviceRequest = Util.Deserialize<ManualAuthDeviceRequest>("0A310A0010001A1049AA7DB2F4A3FFE0E96218F6B92CDE3220A08E98B0012A1169506164206950686F6E65204F53382E34300112023A001A203363616137646232663461336666653065393632313866366239326364653332228D023C736F6674747970653E3C6B333E382E343C2F6B333E3C6B393E695061643C2F6B393E3C6B31303E323C2F6B31303E3C6B31393E45313841454344332D453630422D344635332D423838372D4339343436344437303836393C2F6B31393E3C6B32303E3C2F6B32303E3C6B32313E313030333C2F6B32313E3C6B32323E286E756C6C293C2F6B32323E3C6B32343E62383A66383A38333A33393A61643A62393C2F6B32343E3C6B33333EE5BEAEE4BFA13C2F6B33333E3C6B34373E313C2F6B34373E3C6B35303E313C2F6B35303E3C6B35313E6461697669732E495041443C2F6B35313E3C6B35343E69506164322C353C2F6B35343E3C6B36313E323C2F6B36313E3C2F736F6674747970653E2800322B33636161376462326634613366666530653936323138663662393263646533322D313532383535343230314204695061644A046950616452057A685F434E5A04382E3030680070AFC6EFD8057A054170706C65920102434E9A010B6461697669732E49504144AA010769506164322C35B00102BA01D50608CF0612CF060A08303030303030303310011AC0068A8DCEEE5AB9F4E16054EDA0545F7288B7951621A41446C1AEC0621B3CFE6926737F8298D0B52F467FDFC5EC936D512D332A1AC664E7DFEE734A5E403A72225F852734BF32F6FD623B95D17B64DC8D18FBB2CA2015113CD17518274BED4687D26F5D9E270687745541FA84921A16B50CFE487B1A88C3A91D838A2520AF8757F0E5ACE55BA599B9FCDF1595C3DAAD8E3A34C28BA39951D7A4CF9075CCC28721BA61E48C2DA1B853F3BE0D79AC63F47F2E3C4FF10D4D1CCC1D3002B6F63C228641C1EEB24686BA300853C355C268057D733B7898D20E6B43621419D8BCFCAED82C45377653234B7421238D00B25089670DDEBB03274B1D0D8C45D5A0EA7ECA9086254CCEAA8674ADE4DF905914437BC73D4C9D50CEC9ABCB927590D068DC10A810D376DAFB17A31F947765FF6A7F3B191EC40EEC4AA86FF8771CD2D717D25EE2B7555179AF4C611B9C6AD802B8FDAEAE36CA3497C438E8D4A06B1A7A570D74AAF6C244E8D23BA635FF0F27DCFCF5F6C4754A0049A620AE99012EB4936D34BAD267EAFDB12B67D5274272D3BC795B6454B4C2B768929007D0993F742A519D567ACD0369FCC9196D3CC04578F795026C336F2A29A012608C66E2068F5994210173C5A3B2720A4D040A6D2C3E873D56CE88F85CEFE4847743DEF1102653D42FBC3A31CA5BFE2E666D3542E6E1C5BCCE54D99EC934B183EED69FEA87D975666065E5903F366EFFE04627603FD64861C142A5A19EBD344BF194DE427FB4B70AA0D3CD972AC0A11EA6913E17366CA48966090E10B246BABABA553DBF89BEA4F55004C37E546ABABB8AA20E80B2A0ED21B6700F89699FD01983EDA71ACE6A44B6397605D30E88683BA4BB92A50DC7AFFB820089F157B8C83F7B5DCD35BABCC90501E2E6BDF83327A1059908C72EAF1B5A07CA6565A0888883966D26386C69293649BEC0913FE12C1ABA7B0B16261176E2F7D109FCF68A46B7C3AF7126E77224AA36891B703655CFEA2AAA8B5E095D8B204308133E63D0F0309E8B1CB5A21E9C8B27090859139C076723DE4C74578F6584888220A11A45CDDEC43A1F542552604C96FFE3A01006946086A864C182361B3659C1BDE9ECEA5236F5F38BA98A4C7E8C81A39D5CBA39B7A0F9FFA75AC59BB956595B58DAED58A0851D48B0B7A7407FA576E4956C".ToByteArray(16, 2));
            manualAuthDeviceRequest.Timestamp = (int)CurrentTime_();
            var clientCheckdata1 = new Random().NextBytes(847);
            manualAuthDeviceRequest.Clientcheckdat = new SKBuiltinString_() { buffer = clientCheckdata1, iLen = (uint)clientCheckdata1.Length };

            //manualAuthDeviceRequest.Clientcheckdat = new SKBuiltinString_() { buffer = new byte[] { }, iLen = 0 };
            manualAuthDeviceRequest.imei = imei.ToByteArray(16, 2);
            manualAuthDeviceRequest.clientSeqID = imei + "-" + ((int)CurrentTime_()).ToString();
            manualAuthDeviceRequest.baseRequest = new BaseRequest()
            {
                clientVersion = version,
                devicelId = devicelId.ToByteArray(16, 2),
                scene = 1,
                uin = 0,
                osType = osType,
                sessionKey = aesKey
            };


            manualAuthDeviceRequest.Adsource = Guid.NewGuid().ToString();
            manualAuthDeviceRequest.Bundleid = "com.tencent.xin";

            manualAuthDeviceRequest.Iphonever = phoneOsType;

            manualAuthDeviceRequest.softInfoXml = $@"<softtype><k3>9.0.2</k3><k9>iPad</k9><k10>2</k10><k19>{Guid.NewGuid().ToString().ToUpper()}</k19><k20>{Guid.NewGuid().ToString().ToUpper()}</k20><k21>neihe_5GHz</k21><k22>(null)</k22><k24>{new Random().Next(1, 9)}e:70:{new Random().Next(1, 9)}a:{new Random().Next(1, 9)}d:{new Random().Next(1, 9)}e:{new Random().Next(1, 9)}d</k24><k33>\345\276\256\344\277\241</k33><k47>1</k47><k50>1</k50><k51>com.tencent.xin</k51><k54>iPad4,4</k54></softtype>";

            var account = Util.Serialize(manualAuthAccountRequest);
            byte[] device = Util.Serialize(manualAuthDeviceRequest);
            Debug.Print(device.ToString(16, 2));
            byte[] subHeader = new byte[] { };
            int dwLenAccountProtobuf = account.Length;
            subHeader = subHeader.Concat(dwLenAccountProtobuf.ToByteArray(Endian.Big)).ToArray();
            int dwLenDeviceProtobuf = device.Length;
            subHeader = subHeader.Concat(dwLenDeviceProtobuf.ToByteArray(Endian.Big)).ToArray();

            if (subHeader.Length > 0 && account.Length > 0 && device.Length > 0)
            {
                var cdata = Util.compress_rsa_LOGIN(account);
                int dwLenAccountRsa = cdata.Length;
                subHeader = subHeader.Concat(dwLenAccountRsa.ToByteArray(Endian.Big)).ToArray();
                byte[] body = subHeader;
                ManualAuthDeviceRequest m_ManualAuthDeviceRequest = Util.Deserialize<ManualAuthDeviceRequest>(device);
                //var t2=m_ManualAuthDeviceRequest.tag2.ToString(16, 2);

                var memoryStream = Util.Serialize(m_ManualAuthDeviceRequest);

                body = body.Concat(cdata).ToArray();

                body = body.Concat(Util.compress_aes(device, manualAuthAccountRequest.aes.key)).ToArray();
                //var head = MakeHead( body, MM.CGI_TYPE.CGI_TYPE_MANUALAUTH, 7);
                var head = MakeHead(body, (int)CGI_TYPE.CGI_TYPE_MANUALAUTH, body.Length, 0, "", 7, false);

                body = head.Concat(body).ToArray();

                byte[] RetDate = Util.HttpPost(customerInfoCache?.HostUrl, body, URL.CGI_MANUALAUTH, proxy);
                //Console.WriteLine(RetDate.ToString(16, 2));
                //var ret = HttpPost(@short + MM.URL.CGI_MANUALAUTH, head, null);
                //var lhead = LongLinkPack(LongLinkCmdId.SEND_MANUALAUTH_CMDID, seq++, head.Length);
                int muid = 0;
                string cookie = null;
                if (RetDate.Length > 32)
                {

                    var packinfo = UnPackHeader(RetDate, out muid, out cookie);
                    //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                    RespProtobuf = packinfo.body;
                    if (packinfo.m_bCompressed)
                    {
                        RespProtobuf = Util.uncompress_aes(packinfo.body, manualAuthAccountRequest.aes.key);
                    }
                    else
                    {
                        RespProtobuf = Util.nouncompress_aes(packinfo.body, manualAuthAccountRequest.aes.key);
                    }

                }
                else
                {
                    throw new ExpiredException("数据存在问题,请重试");
                }
                if (RespProtobuf == null) return null;
                var manualAuthResponse = Util.Deserialize<ManualAuthResponse>(RespProtobuf);

                if (manualAuthResponse.baseResponse.ret == MMPro.MM.RetConst.MM_ERR_IDC_REDIRECT)
                {
                    if (customerInfoCache == null)
                    {
                        customerInfoCache = new CustomerInfoCache();
                    }
                    if (index >= manualAuthResponse.dnsInfo.newHostList.list.Count())
                    {
                        throw new Exception("重定向异常");
                    }
                    customerInfoCache.HostUrl = "http://" + manualAuthResponse.dnsInfo.newHostList.list[index].substitute;
                    index += 2;
                    return UserLogin(username, pass, Data62, proxyip, proxyusername, proxypassword, customerInfoCache, index);
                }
                else if (manualAuthResponse.baseResponse.ret == MMPro.MM.RetConst.MM_OK)
                {
                    if (customerInfoCache == null)
                    {
                        customerInfoCache = new CustomerInfoCache();
                    }
                    customerInfoCache.WxId = manualAuthResponse.accountInfo.wxid;
                    customerInfoCache.NickName = manualAuthResponse.accountInfo.nickName;
                    customerInfoCache.BindEmail = manualAuthResponse.accountInfo.bindMail;
                    customerInfoCache.BindMobile = manualAuthResponse.accountInfo.bindMobile;
                    customerInfoCache.Status = manualAuthResponse.accountInfo.status;
                    customerInfoCache.Alias = manualAuthResponse.accountInfo.Alias;
                    customerInfoCache.DeviceInfoXml = manualAuthResponse.accountInfo.deviceInfoXml;
                    customerInfoCache.State = 2;
                    customerInfoCache.Remark = Data62;
                    customerInfoCache.DeviceId = devicelId.ToByteArray(16, 2);
                    //customerInfoCache.Device =  
                    //customerInfoCache.HeadUrl = manualAuthResponse.accountInfo.head;
                    customerInfoCache.MUid = muid;
                    customerInfoCache.Cookie = cookie;

                    customerInfoCache.PriKeyBuf = pri_key_buf;
                    customerInfoCache.PubKeyHUb = pub_key_buf;

                    customerInfoCache.AuthKey = manualAuthResponse.authParam.authKey;
                    customerInfoCache.Ticket = manualAuthResponse.authParam.authTicket;

                    customerInfoCache.AuthTicket = manualAuthResponse.authParam.authTicket;
                    customerInfoCache.AutoAuthTicket = manualAuthResponse.authParam.autoAuthKey.buffer;


                    byte[] strECServrPubKey = manualAuthResponse.authParam.ecdh.ecdhkey.key;
                    byte[] aesKey1 = new byte[16];
                    ComputerECCKeyMD5(strECServrPubKey, 57, customerInfoCache.PriKeyBuf, 328, aesKey1);
                    //var aesKey = OpenSSLNativeClass.ECDH.DoEcdh(ManualAuth.authParam.ecdh.nid, strECServrPubKey, wechat.pri_key_buf);
                    //wechat.CheckEcdh = aesKey.ToString(16, 2);
                    customerInfoCache.AesKey = AES.AESDecrypt(manualAuthResponse.authParam.session.key, aesKey1).ToString(16, 2).ToByteArray(16, 2);

                    var baseRequest = GetBaseRequest(customerInfoCache.DeviceId, customerInfoCache.AesKey, (uint)customerInfoCache.MUid, phoneOsType, version);
                    customerInfoCache.BaseRequest = new CustomerInfoCache.BaseRequestCache()
                    {
                        sessionKey = baseRequest.sessionKey,
                        uin = baseRequest.uin,
                        devicelId = baseRequest.devicelId,
                        clientVersion = baseRequest.clientVersion,
                        osType = baseRequest.osType,
                        scene = baseRequest.scene
                    };

                    this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.WxId, customerInfoCache);
                }



                return manualAuthResponse;
            }
            else
                return null;

        }







        /// <summary>
        /// 设备信息和秘钥建议
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="sessionKey"></param>
        /// <param name="uIn"></param>
        /// <param name="osType"></param>
        /// <returns></returns>
        public BaseRequest GetBaseRequest(byte[] deviceID, byte[] sessionKey, uint uIn, string osType, int version)
        {
            var baseRequest_ = GoogleProto.CreateBaseRequestEntity(deviceID, Encoding.Default.GetString(sessionKey), uIn, osType, version);

            return Util.Deserialize<BaseRequest>(baseRequest_.ToByteArray());
        }

        /// <summary>
        /// 组包
        /// </summary>
        /// <param name="src"></param>
        /// <param name="cgi_"></param>
        /// <param name="nLenProtobuf"></param>
        /// <param name="encodetypr"></param>
        /// <param name="iscookie"></param>
        /// <param name="isuin"></param>
        /// <returns></returns>
        private byte[] pack(byte[] src, int cgi_, int nLenProtobuf, byte[] aesKey, byte[] pri_key_buf, int m_uid, string cookie, byte encodetypr = 7, bool iscookie = false, bool isuin = false)
        {
            //组包头
            var pbody = new byte[0];
            if (encodetypr == 7)
            {
                var head = MakeHead(src, cgi_, src.Length, m_uid, cookie, encodetypr, iscookie, isuin);
                pbody = head.Concat(Util.nocompress_rsa(src)).ToArray();
            }
            else if (encodetypr == 5)
            {
                //计算校验
                uint check_ = check((uint)m_uid, src, pri_key_buf);
                //压缩
                byte[] zipData = DeflateCompression.DeflateZip(src);
                int lenAfterZip = zipData.Length;

                //aes加密
                byte[] aesData = Util.AESEncryptorData(zipData, aesKey);

                pbody = CommonRequestPacket(src.Length, lenAfterZip, aesData, (uint)m_uid, 0xd, (short)cgi_, cookie?.ToByteArray(16, 2), 0);
            }
            else if (encodetypr == 1)
            {
                var head = MakeHead(src, cgi_, src.Length, m_uid, cookie, encodetypr, iscookie, isuin);
                pbody = head.Concat(Util.compress_rsa(src)).ToArray();
            }
            return pbody;
        }

        /// <summary>
        /// 计算校验MakeHead
        /// </summary>
        /// <param name="uin"></param>
        /// <param name="niqData"></param>
        /// <param name="eccKey"></param>
        /// <returns></returns>
        private uint check(uint uin, byte[] niqData, byte[] eccKey)
        {
            int lenBeforeZip = niqData.Length;
            byte[] byteInt = new byte[4];
            //byteInt[0] = (byte)(((uin & 0xff000000) >> 24) & 0xff);
            //byteInt[1] = (byte)(((uin & 0x00ff0000) >> 16) & 0xff);
            //byteInt[2] = (byte)(((uin & 0x0000ff00) >> 8) & 0xff);
            //byteInt[3] = (byte)((uin & 0x000000ff) & 0xff);

            byte[] md5 = Util.MD5(byteInt.Concat(eccKey).ToArray());

            byteInt[0] = (byte)(((lenBeforeZip & 0xff000000) >> 24) & 0xff);
            byteInt[1] = (byte)(((lenBeforeZip & 0x00ff0000) >> 16) & 0xff);
            byteInt[2] = (byte)(((lenBeforeZip & 0x0000ff00) >> 8) & 0xff);
            byteInt[3] = (byte)((lenBeforeZip & 0x000000ff) & 0xff);
            md5 = Util.MD5(byteInt.Concat(eccKey).Concat(md5).ToArray());

            uint check = Adler32(1, md5, md5.Length);
            check = Adler32(check, niqData, lenBeforeZip);
            return check;
        }
        /// <summary>
        /// 组吧
        /// </summary>
        /// <param name="lengthBeforeZip"></param>
        /// <param name="lengthAfterZip"></param>
        /// <param name="aesDataPacket"></param>
        /// <param name="uin"></param>
        /// <param name="deviceID"></param>
        /// <param name="_byteVar"></param>
        /// <returns></returns>
        private byte[] CommonRequestPacket(int lengthBeforeZip, int lengthAfterZip, byte[] aesDataPacket, uint uin,
            short cmd, short cmd2, byte[] cookie, uint check)
        {
            byte[] frontPacket = {
                                     0xBF, 0x62, 0x50, 0x16, 0x07, 0x03, 0x21
                                 };

            byte[] endTag = { 0x02 };
            byte[] byteUin = new byte[4];

            uint a = (uin & 0xff000000);
            byteUin[0] = (byte)(((uin & 0xff000000) >> 24) & 0xff);
            byteUin[1] = (byte)(((uin & 0x00ff0000) >> 16) & 0xff);
            byteUin[2] = (byte)(((uin & 0x0000ff00) >> 8) & 0xff);
            byteUin[3] = (byte)((uin & 0x000000ff) & 0xff);

            byte[] packet = frontPacket.Concat(byteUin).ToArray();

            packet = packet.Concat(cookie).ToArray();

            packet = packet.Concat(toVariant(cmd2)).ToArray();

            packet = packet.Concat(toVariant(lengthBeforeZip)).ToArray();

            packet = packet.Concat(toVariant(lengthAfterZip)).ToArray();

            packet = packet.Concat(toVariant(10000)).ToArray();

            packet = packet.Concat(endTag).ToArray();
            packet = packet.Concat(toVariant((int)check)).ToArray();

            packet = packet.Concat(toVariant(0x01004567)).ToArray();

            int HeadLen = packet.Length;

            packet[1] = (byte)((HeadLen * 4) + 1);
            packet[2] = (byte)(0x50 + cookie.Length);

            packet = packet.Concat(aesDataPacket).ToArray();

            return packet;
        }
        //组包体头
        private byte[] MakeHead_old(int cgi, int nLenProtobuf, int m_uid, string cookie, byte encodetypr = 7, bool iscookie = false, bool isuin = false)
        {

            List<byte> strHeader = new List<byte>();
            int nCur = 0;
            byte SecondByte = 0x2;
            strHeader.Add(SecondByte);
            nCur++;
            //加密算法(前4bits),RSA加密(7)AES(5)
            byte ThirdByte = (byte)(encodetypr << 4);
            if (iscookie)
                ThirdByte += 0xf;
            strHeader.Add((byte)ThirdByte);
            nCur++;
            int dwUin = 0;
            if (isuin)
                dwUin = m_uid;
            strHeader = strHeader.Concat(version.ToByteArray(Endian.Big).ToList()).ToList();
            nCur += 4;

            strHeader = strHeader.Concat(dwUin.ToByteArray(Endian.Big).ToList()).ToList();
            nCur += 4;

            if (iscookie)
            {
                //登录包不需要cookie 全0占位即可
                if (cookie == null || cookie == "" || cookie.Length < 0xf)
                {
                    strHeader = strHeader.Concat(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).ToList();
                    nCur += 15;
                }
                else
                {
                    strHeader = strHeader.Concat(cookie.ToByteArray(16, 2).ToList()).ToList();
                    nCur += 15;
                }
            }
            byte[] strcgi = Dword2String((UInt32)cgi);
            strHeader = strHeader.Concat(strcgi.ToList()).ToList();
            nCur += strcgi.Length;
            byte[] strLenProtobuf = Dword2String((UInt32)nLenProtobuf);
            strHeader = strHeader.Concat(strLenProtobuf.ToList()).ToList();
            nCur += strLenProtobuf.Length;
            byte[] strLenCompressed = Dword2String((UInt32)nLenProtobuf);
            strHeader = strHeader.Concat(strLenCompressed.ToList()).ToList();
            nCur += strLenCompressed.Length;
            var rsaVer = Dword2String((UInt32)LOGIN_RSA_VER);
            strHeader = strHeader.Concat(rsaVer).ToList();
            nCur += rsaVer.Length;
            strHeader = strHeader.Concat(new byte[] { 1, 2 }.ToList()).ToList();
            nCur += 2;

            //var unkwnow = (9).ToByteArray(Endian.Little).Copy(2);// "0100".ToByteArray(16, 2);
            //strHeader = strHeader.Concat(unkwnow.ToList()).ToList();
            //nCur += unkwnow.Length;
            nCur++;
            SecondByte += (byte)(nCur << 2);
            strHeader[0] = SecondByte;

            strHeader.Insert(0, 0xbf);
            return strHeader.ToArray();


        }

        private byte[] MakeHead(byte[] body, int cgi, int nLenProtobuf, int m_uid, string cookie, byte encodetypr = 7, bool iscookie = false, bool isuin = false)
        {
            List<byte> strHeader8 = new List<byte>();
            int nCur11 = 0;
            byte SecondByte2 = 2;
            strHeader8.Add(SecondByte2);
            nCur11++;
            byte ThirdByte = (byte)(encodetypr << 4);
            if (iscookie)
            {
                ThirdByte = (byte)(ThirdByte + 15);
            }
            strHeader8.Add(ThirdByte);
            nCur11++;
            int dwUin = 0;
            if (isuin)
            {
                dwUin = m_uid;
            }
            strHeader8 = strHeader8.Concat(version.ToByteArray(Endian.Big).ToList()).ToList();
            nCur11 += 4;
            strHeader8 = strHeader8.Concat(dwUin.ToByteArray(Endian.Big).ToList()).ToList();
            nCur11 += 4;
            if (iscookie)
            {
                if (cookie == null || cookie == "" || cookie.Length < 15)
                {
                    strHeader8 = strHeader8.Concat(new byte[15]).ToList();
                    nCur11 += 15;
                }
                else
                {
                    strHeader8 = strHeader8.Concat(cookie.ToByteArray(16, 2).ToList()).ToList();
                    nCur11 += 15;
                }
            }
            byte[] strcgi = Dword2String((uint)cgi);
            strHeader8 = strHeader8.Concat(strcgi.ToList()).ToList();
            nCur11 += strcgi.Length;
            byte[] strLenProtobuf = Dword2String((uint)nLenProtobuf);
            strHeader8 = strHeader8.Concat(strLenProtobuf.ToList()).ToList();
            nCur11 += strLenProtobuf.Length;
            byte[] strLenCompressed = Dword2String((uint)nLenProtobuf);
            strHeader8 = strHeader8.Concat(strLenCompressed.ToList()).ToList();
            nCur11 += strLenCompressed.Length;
            byte[] rsaVer = Dword2String(LOGIN_RSA_VER);
            strHeader8 = strHeader8.Concat(rsaVer).ToList();
            nCur11 += rsaVer.Length;
            strHeader8 = strHeader8.Concat(new byte[] { 13, 0, 9 }.ToList()).ToList();
            strHeader8 = strHeader8.Concat(Dword2String((uint)(body.SignRqt()))).ToList();
            strHeader8 = strHeader8.Concat(new byte[] { 0 }).ToList();
            nCur11 += 9;
            nCur11++;
            SecondByte2 = (strHeader8[0] = (byte)(SecondByte2 + (byte)(nCur11 << 2)));
            strHeader8.Insert(0, 191);
            return strHeader8.ToArray();
        }
        private byte[] Dword2String(UInt32 dw)
        {
            List<byte> apcBuffer = new List<byte>();

            while (dw >= 0x80)
            {

                apcBuffer.Add((byte)(0x80 + (dw & 0x7f)));
                dw = dw >> 7;
            }
            apcBuffer.Add((byte)dw);
            return apcBuffer.ToArray();
            //Int32 dwData = dw;
            //Int32 dwData2 = 0x80 * 0x80 * 0x80 * 0x80;
            //int nLen = 4;
            //byte[] hex = new byte[5];
            //Int32 dwOutLen = 0;
            //while (nLen > 0)
            //{
            //    if (dwData > dwData2)
            //    {
            //        hex[nLen] = (byte)(dwData / dwData2);
            //        dwData = dwData % dwData2;
            //        dwOutLen++;
            //    }

            //    dwData2 /= 0x80;
            //    nLen--;
            //}

            //hex[0] = (byte)dwData;

            //dwOutLen++;

            //for (int i = 0; i < (int)(dwOutLen - 1); i++)
            //{
            //    hex[i] += 0x80;
            //}

            //return hex;
        }

        private int DecodeVByte32(ref int apuValue, byte[] apcBuffer, int off)
        {
            int num3;
            int num = 0;
            int num2 = 0;
            int num4 = 0;
            byte num5 = apcBuffer[off + num++];
            while ((num5 & 0xff) >= 0x80)
            {
                num3 = num5 & 0x7f;
                num4 += num3 << num2;
                num2 += 7;
                num5 = apcBuffer[off + num++];
            }
            num3 = num5;
            num4 += num3 << num2;
            apuValue = num4;
            return num;
        }

        private byte[] toVariant(int toValue)
        {
            uint va = (uint)toValue;
            List<byte> result = new List<byte>();

            while (va >= 0x80)
            {
                result.Add((byte)(0x80 + va % 0x80));
                va /= 0x80;
            }
            result.Add((byte)(va % 0x80));

            return result.ToArray();
        }
        /// <summary>
        /// 获取当前时间时间戳
        /// </summary>
        /// <returns></returns>
        private long CurrentTime_()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public NewSyncResponse NewSyncEcode(CustomerInfoCache customerInfoCache, int scane)
        {
            var RespProtobuf = new byte[0];
            //0a020800108780101a8a02088402128402081f1208080110aaa092ba021208080210a9a092ba0212080803109aa092ba021208080410f28292ba021208080510f28292ba021208080710f28292ba02120408081000120808091099a092ba021204080a10001208080b10839f92ba021204080d10001208080e10f28292ba021208081010f28292ba021204086510001204086610001204086710001204086810001204086910001204086b10001204086d10001204086f1000120408701000120408721000120908c90110f5d7fbd705120908cb0110c6bcf3d705120508cc011000120508cd011000120908e80710fdd0fad705120908e90710ba92fad705120908ea07109bf1c9d705120908d10f10d1b9f0d70520032a0a616e64726f69642d31393001
            //MemoryStream memoryStream = new MemoryStream();
            NewSyncRequest request = new NewSyncRequest()
            {
                continueflag = new FLAG() { flag = 0 },
                device = customerInfoCache.Device,
                scene = scane,
                selector = 262151,//3
                syncmsgdigest = 3,
                tagmsgkey = new syncMsgKey()
                {
                    msgkey = new Synckey()
                    {
                        size = 32
                    }
                }

            };

            request.tagmsgkey = Util.Deserialize<syncMsgKey>(customerInfoCache.Sync);
            var src = Util.Serialize(request);
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, (int)CGI_TYPE.CGI_TYPE_NEWSYNC, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, URL.CGI_NEWSYNC, customerInfoCache.Proxy);
            int mUid = 0;
            string cookie = null;
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }
            if (RespProtobuf == null)
            {
                Wechat.Util.Log.Logger.GetLog<WechatHelper>().Warn($"{customerInfoCache.WxId}同步微信消息返回为空");
                return new NewSyncResponse();
            }
            var NewSync = Util.Deserialize<NewSyncResponse>(RespProtobuf);

            return NewSync;
        }

        /// <summary>
        /// 摇一摇提交bufkey
        /// </summary>
        /// <param name="sKBuiltinBuffer_T"></param>
        /// <returns></returns>
        private micromsg.ShakeGetResponse ShakeGet(CustomerInfoCache customerInfoCache, micromsg.SKBuiltinBuffer_t sKBuiltinBuffer_T)
        {

            byte[] RespProtobuf = new byte[0];
            micromsg.ShakeGetRequest shakeGet_ = new micromsg.ShakeGetRequest()
            {
                BaseRequest = new micromsg.BaseRequest()
                {
                    SessionKey = customerInfoCache.BaseRequest.sessionKey,
                    Uin = (uint)customerInfoCache.BaseRequest.uin,
                    DeviceID = customerInfoCache.BaseRequest.devicelId,
                    ClientVersion = customerInfoCache.BaseRequest.clientVersion,
                    DeviceType = Encoding.UTF8.GetBytes(customerInfoCache.BaseRequest.osType),
                    Scene = (uint)customerInfoCache.BaseRequest.scene
                },
                Buffer = sKBuiltinBuffer_T
            };

            var src = Util.Serialize(shakeGet_);
            int mUid = 0;
            string cookie = null;
            int bufferlen = src.Length;
            //组包
            byte[] SendDate = pack(src, 162, bufferlen, customerInfoCache.AesKey, customerInfoCache.PriKeyBuf, customerInfoCache.MUid, customerInfoCache.Cookie, 5, true, true);
            //发包
            byte[] RetDate = Util.HttpPost(customerInfoCache.HostUrl, SendDate, "/cgi-bin/micromsg-bin/shakeget", customerInfoCache.Proxy);
            if (RetDate.Length > 32)
            {
                var packinfo = UnPackHeader(RetDate, out mUid, out cookie);
                //Console.WriteLine("CGI {0} BodyLength {1} m_bCompressed {2}", packinfo.CGI, packinfo.body.Length, packinfo.m_bCompressed);
                RespProtobuf = packinfo.body;
                if (packinfo.m_bCompressed)
                {
                    RespProtobuf = Util.uncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }
                else
                {
                    RespProtobuf = Util.nouncompress_aes(packinfo.body, customerInfoCache.AesKey);
                }

            }
            else
            {
                throw new ExpiredException("用户可能退出,请重新登陆");
            }

            var ShakeGetResponse_ = Util.Deserialize<micromsg.ShakeGetResponse>(RespProtobuf);
            return ShakeGetResponse_;
        }

        /// <summary>
        /// 解包头 返回 包数据结构
        /// </summary>
        /// <param name="pack"></param>
        /// <returns></returns>
        private PACKINFO UnPackHeader(byte[] pack, out int m_uid, out string cookie)
        {
            m_uid = 0;
            cookie = null;
            //Console.WriteLine(pack.ToString(16, 2));
            PACKINFO pACKINFO = new PACKINFO();
            byte[] body = new byte[] { };
            pACKINFO.body = body;
            if (pack.Length < 0x20) return pACKINFO;
            int nCur = 0;
            if (0xbf == pack[nCur])
            {
                nCur++;
            }
            //解析包头长度(前6bits)
            int nHeadLen = pack[nCur] >> 2;

            //是否使用压缩(后2bits)
            pACKINFO.m_bCompressed = (1 == (pack[nCur] & 0x3)) ? true : false;

            nCur++;

            //解密算法(前4 bits)(05:aes / 07:rsa)(仅握手阶段的发包使用rsa公钥加密,由于没有私钥收包一律aes解密)
            pACKINFO.m_nDecryptType = pack[nCur] >> 4;

            //cookie长度(后4 bits)
            int nCookieLen = pack[nCur] & 0xF;

            nCur++;

            //服务器版本,无视(4字节)
            nCur += 4;

            //登录包 保存uin
            //int dwUin;
            m_uid = (int)pack.Copy(nCur, 4).GetUInt32(Endian.Big);
            //memcpy(&dwUin, &(pack[nCur]), 4);
            //s_dwUin = ntohl(dwUin);
            nCur += 4;
            //刷新cookie(超过15字节说明协议头已更新)
            if (nCookieLen > 0 && nCookieLen <= 0xf)
            {
                string s_cookie = pack.Copy(nCur, nCookieLen).ToString(16, 2);
                //pAuthInfo->m_cookie = s_cookie;
                cookie = s_cookie;
                nCur += nCookieLen;
            }
            else if (nCookieLen > 0xf)
            {
                return null;
            }

            //cgi type,变长整数,无视

            int dwLen = DecodeVByte32(ref pACKINFO.CGI, pack.Copy(nCur, 5), 0);
            //pACKINFO. CGI = String2Dword(pack.Copy(nCur, 5));
            nCur += dwLen;

            //解压后protobuf长度，变长整数
            int m_nLenRespProtobuf = 0;//String2Dword(pack.Copy(nCur, 5));
            dwLen = DecodeVByte32(ref m_nLenRespProtobuf, pack.Copy(nCur, 5), 0);
            nCur += dwLen;

            //压缩后(加密前)的protobuf长度，变长整数
            int m_nLenRespCompressed = 0;//String2Dword(pack.Copy(nCur, 5));
            dwLen = DecodeVByte32(ref m_nLenRespCompressed, pack.Copy(nCur, 5), 0);
            nCur += dwLen;

            //后面数据无视

            //解包完毕,取包体
            if (nHeadLen < pack.Length)
            {
                body = pack.Copy(nHeadLen, pack.Length - nHeadLen);
            }
            pACKINFO.body = body;
            //Console.WriteLine("body len{0}", pACKINFO.body.Length);
            // Console.WriteLine(body.ToString(16, 2));
            return pACKINFO;
        }

        public class PACKINFO
        {
            //是否压缩
            public bool m_bCompressed;
            //是否加密
            public int m_nDecryptType;
            // CGi
            public int CGI;
            //包体
            public byte[] body;
        }
    }


}
