using ProtoBuf;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MMPro
{
	public class MM
	{
		public class CMsgContext
		{
			public byte[] data;

			public string aesKey = "";

			public string bigUrlKey = "";

			public int encryVer;

			public int hdlength;

			public int length;

			public string md5 = "";

			public string midUrlKey = "";

			public string thumbaesKey = "";

			public int thumblength;

			public string thumbUrlKey = "";

			public string cdnthumbaeskey = "";

			public int cdnthumblength;

			public int cdnthumbheight;

			public int cdnthumbwidth;

			public int cdnmidheight;

			public int cdnmidwidth;

			public int cdnhdheight;

			public int cdnhdwidth;

			public string cdnvideourl = "";

			public string cdnthumburl = "";

			public string fromusername = "";

			public string newmd5 = "";

			public int isad;

			public int playlength;

			public static MM.CMsgContext parseImageContent(string xmlContent)
			{
				MM.CMsgContext cMsgContext = new MM.CMsgContext();
				bool flag = string.IsNullOrEmpty(xmlContent);
				MM.CMsgContext result;
				if (flag)
				{
					cMsgContext.length = 0;
					cMsgContext.hdlength = 0;
					result = cMsgContext;
				}
				else
				{
					try
					{
						XElement xElement = XDocument.Parse(xmlContent).Element("msg");
						string expandedName = "img";
						XElement xElement2 = xElement.Element("img");
						bool flag2 = xElement.Element("img") != null;
						if (flag2)
						{
							expandedName = "imgmsg";
						}
						else
						{
							bool flag3 = xElement.Element("videomsg") != null;
							if (flag3)
							{
								expandedName = "videomsg";
							}
						}
						XAttribute xAttribute = xElement.Element(expandedName).Attribute("length");
						bool flag4 = xAttribute != null;
						if (flag4)
						{
							cMsgContext.length = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("hdlength");
						bool flag5 = xAttribute != null;
						if (flag5)
						{
							cMsgContext.hdlength = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumblength");
						bool flag6 = xAttribute != null;
						if (flag6)
						{
							cMsgContext.cdnthumblength = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumbheight");
						bool flag7 = xAttribute != null;
						if (flag7)
						{
							cMsgContext.cdnthumbheight = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumbwidth");
						bool flag8 = xAttribute != null;
						if (flag8)
						{
							cMsgContext.cdnthumbwidth = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnmidheight");
						bool flag9 = xAttribute != null;
						if (flag9)
						{
							cMsgContext.cdnmidheight = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnmidwidth");
						bool flag10 = xAttribute != null;
						if (flag10)
						{
							cMsgContext.cdnmidwidth = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnhdheight");
						bool flag11 = xAttribute != null;
						if (flag11)
						{
							cMsgContext.cdnhdheight = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("md5");
						bool flag12 = xAttribute != null;
						if (flag12)
						{
							cMsgContext.md5 = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnhdwidth");
						bool flag13 = xAttribute != null;
						if (flag13)
						{
							cMsgContext.cdnhdwidth = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumbaeskey");
						bool flag14 = xAttribute != null;
						if (flag14)
						{
							cMsgContext.cdnthumbaeskey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumblength");
						bool flag15 = xAttribute != null;
						if (flag15)
						{
							cMsgContext.thumblength = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("encryver");
						bool flag16 = xAttribute != null;
						if (flag16)
						{
							cMsgContext.encryVer = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("aeskey");
						bool flag17 = xAttribute != null;
						if (flag17)
						{
							cMsgContext.aesKey = xAttribute.Value;
							cMsgContext.thumbaesKey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumbaeskey");
						bool flag18 = xAttribute != null;
						if (flag18)
						{
							cMsgContext.thumbaesKey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnmidimgurl");
						bool flag19 = xAttribute != null;
						if (flag19)
						{
							cMsgContext.midUrlKey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnbigimgurl");
						bool flag20 = xAttribute != null;
						if (flag20)
						{
							cMsgContext.bigUrlKey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumburl");
						bool flag21 = xAttribute != null;
						if (flag21)
						{
							cMsgContext.thumbUrlKey = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnvideourl");
						bool flag22 = xAttribute != null;
						if (flag22)
						{
							cMsgContext.cdnvideourl = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("cdnthumburl");
						bool flag23 = xAttribute != null;
						if (flag23)
						{
							cMsgContext.cdnthumburl = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("fromusername");
						bool flag24 = xAttribute != null;
						if (flag24)
						{
							cMsgContext.fromusername = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("newmd5");
						bool flag25 = xAttribute != null;
						if (flag25)
						{
							cMsgContext.newmd5 = xAttribute.Value;
						}
						xAttribute = xElement.Element(expandedName).Attribute("isad");
						bool flag26 = xAttribute != null;
						if (flag26)
						{
							cMsgContext.isad = int.Parse(xAttribute.Value);
						}
						xAttribute = xElement.Element(expandedName).Attribute("playlength");
						bool flag27 = xAttribute != null;
						if (flag27)
						{
							cMsgContext.playlength = int.Parse(xAttribute.Value);
						}
					}
					catch (Exception var_34_633)
					{
						cMsgContext.length = 0;
						cMsgContext.hdlength = 0;
						result = cMsgContext;
						return result;
					}
					result = cMsgContext;
				}
				return result;
			}

			public bool isCdnImgMsg()
			{
				bool flag = this.aesKey.Length < 16;
				return !flag;
			}

			public bool isCdnImgMsgWithThumb()
			{
				bool flag = !this.isCdnImgMsg();
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = string.IsNullOrWhiteSpace(this.thumbUrlKey);
					result = !flag2;
				}
				return result;
			}
		}

		public enum RetConst
		{
			ERR_SERVER_FILE_EXPIRED = -5103059,
			MM_BOTTLE_COUNT_ERR = 16,
			MM_BOTTLE_ERR_UNKNOWNTYPE = 15,
			MM_BOTTLE_NOTEXIT = 17,
			MM_BOTTLE_PICKCOUNTINVALID = 19,
			MM_BOTTLE_UINNOTMATCH = 18,
			MM_ERR_ACCESS_DENIED = -5,
			MM_ERR_ACCOUNT_BAN = -200,
			MM_ERR_ALPHA_FORBIDDEN = -75,
			MM_ERR_ANSWER_COUNT = -150,
			MM_ERR_ARG = -2,
			MM_ERR_AUTH_ANOTHERPLACE = -100,
			MM_ERR_BADEMAIL = -28,
			MM_ERR_BATCHGETCONTACTPROFILE_MODE = -45,
			MM_ERR_BIGBIZ_AUTH = -69,
			MM_ERR_BIND_EMAIL_SAME_AS_QMAIL = -86,
			MM_ERR_BINDED_BY_OTHER,
			MM_ERR_BINDUIN_BINDED = -50,
			MM_ERR_BIZ_FANS_LIMITED = -87,
			MM_ERR_BLACKLIST = -22,
			MM_ERR_BLOCK_BY_SPAM = -106,
			MM_ERR_BOTTLEBANBYEXPOSE = -2002,
			MM_ERR_CERT_EXPIRED = -102,
			MM_ERR_CHATROOM_NEED_INVITE = -2012,
			MM_ERR_CHATROOM_PARTIAL_INVITE = -2013,
			MM_ERR_CLIDB_ENCRYPT_KEYINFO_INVALID = -2010,
			MM_ERR_CLIENT = -800000,
			MM_ERR_CONNECT_INFO_URL_INVALID = -2011,
			MM_ERR_COOKIE_KICK = -2008,
			MM_ERR_CRITICALUPDATE = -16,
			MM_ERR_DOMAINDISABLE = -27,
			MM_ERR_DOMAINMAXLIMITED,
			MM_ERR_DOMAINVERIFIED,
			MM_ERR_EMAIL_FORMAT = -111,
			MM_ERR_EMAILEXIST = -8,
			MM_ERR_EMAILNOTVERIFY = -9,
			MM_ERR_FACING_CREATECHATROOM_RETRY = -432,
			MM_ERR_FAV_ALREADY = -400,
			MM_ERR_FILE_EXPIRED = -352,
			MM_ERR_FORCE_QUIT = -999999,
			MM_ERR_FORCE_REDIRECT = -2005,
			MM_ERR_FREQ_LIMITED = -34,
			MM_ERR_GETMFRIEND_NOT_READY = -70,
			MM_ERR_GMAIL_IMAP = -63,
			MM_ERR_GMAIL_ONLINELIMITE = -61,
			MM_ERR_GMAIL_PWD,
			MM_ERR_GMAIL_WEBLOGIN = -62,
			MM_ERR_HAS_BINDED = -84,
			MM_ERR_HAS_NO_HEADIMG = -53,
			MM_ERR_HAS_UNBINDED = -83,
			MM_ERR_HAVE_BIND_FACEBOOK = -67,
			MM_ERR_IDC_REDIRECT = -301,
			MM_ERR_IMG_READ = -1005,
			MM_ERR_INVALID_BIND_OPMODE = -37,
			MM_ERR_INVALID_GROUPCARD_CONTACT = -52,
			MM_ERR_INVALID_HDHEADIMG_REQ_TOTAL_LEN = -54,
			MM_ERR_INVALID_UPLOADMCONTACT_OPMODE = -38,
			MM_ERR_IS_NOT_OWNER = -66,
			MM_ERR_KEYBUF_INVALID = -2006,
			MM_ERR_LBSBANBYEXPOSE = -2001,
			MM_ERR_LBSDATANOTFOUND,
			MM_ERR_LOGIN_QRCODE_UUID_EXPIRED = -2007,
			MM_ERR_LOGIN_URL_DEVICE_UNSAFE = -2009,
			MM_ERR_MEMBER_TOOMUCH = -23,
			MM_ERR_MOBILE_BINDED = -35,
			MM_ERR_MOBILE_FORMAT = -41,
			MM_ERR_MOBILE_NEEDADJUST = -74,
			MM_ERR_MOBILE_NULL = -39,
			MM_ERR_MOBILE_UNBINDED = -36,
			MM_ERR_NEED_QQPWD = -49,
			MM_ERR_NEED_VERIFY = -6,
			MM_ERR_NEED_VERIFY_USER = -44,
			MM_ERR_NEEDREG = -30,
			MM_ERR_NEEDSECONDPWD = -31,
			MM_ERR_NEW_USER = -79,
			MM_ERR_NICEQQ_EXPIRED = -72,
			MM_ERR_NICKNAMEINVALID = -15,
			MM_ERR_NICKRESERVED = -11,
			MM_ERR_NO_BOTTLECOUNT = -56,
			MM_ERR_NO_HDHEADIMG,
			MM_ERR_NO_QUESTION = -152,
			MM_ERR_NO_RETRY = -101,
			MM_ERR_NODATA = -203,
			MM_ERR_NOTBINDQQ = -81,
			MM_ERR_NOTCHATROOMCONTACT = -21,
			MM_ERR_NOTMICROBLOGCONTACT,
			MM_ERR_NOTOPENPRIVATEMSG,
			MM_ERR_NOTQQCONTACT = -46,
			MM_ERR_NOUPDATEINFO = -18,
			MM_ERR_NOUSER = -4,
			MM_ERR_OIDBTIMEOUT = -29,
			MM_ERR_ONE_BINDTYPE_LEFT = -82,
			MM_ERR_OTHER_MAIN_ACCT = -204,
			MM_ERR_PARSE_MAIL = -64,
			MM_ERR_PASSWORD = -3,
			MM_ERR_PICKBOTTLE_NOBOTTLE = -58,
			MM_ERR_QA_RELATION = -153,
			MM_ERR_QQ_BAN = -201,
			MM_ERR_QQ_OK_NEED_MOBILE = -205,
			MM_ERR_QRCODEVERIFY_BANBYEXPOSE = -2004,
			MM_ERR_QUESTION_COUNT = -151,
			MM_ERR_RADAR_PASSWORD_SIMPLE = -431,
			MM_ERR_RECOMMENDEDUPDATE = -17,
			MM_ERR_REG_BUT_LOGIN = -212,
			MM_ERR_REVOKEMSG_TIMEOUT = -430,
			MM_ERR_SEND_VERIFYCODE = -57,
			MM_ERR_SESSIONTIMEOUT = -13,
			MM_ERR_SHAKE_TRAN_IMG_CANCEL = -90,
			MM_ERR_SHAKE_TRAN_IMG_CONTINUE = -92,
			MM_ERR_SHAKE_TRAN_IMG_NOTFOUND,
			MM_ERR_SHAKE_TRAN_IMG_OTHER = -93,
			MM_ERR_SHAKEBANBYEXPOSE = -2003,
			MM_ERR_SHORTVIDEO_CANCEL = 1000000,
			MM_ERR_SPAM = -24,
			MM_ERR_SVR_MOBILE_FORMAT = -78,
			MM_ERR_SYS = -1,
			MM_ERR_TICKET_NOTFOUND = -48,
			MM_ERR_TICKET_UNMATCH,
			MM_ERR_TOLIST_LIMITED = -71,
			MM_ERR_TRYQQPWD = -73,
			MM_ERR_UINEXIST = -12,
			MM_ERR_UNBIND_MAIN_ACCT = -206,
			MM_ERR_UNBIND_MOBILE_NEED_QQPWD = -202,
			MM_ERR_UNBIND_REGBYMOBILE = -65,
			MM_ERR_UNMATCH_MOBILE = -40,
			MM_ERR_UNSUPPORT_COUNTRY = -59,
			MM_ERR_USER_BIND_MOBILE = -43,
			MM_ERR_USER_MOBILE_UNMATCH,
			MM_ERR_USER_NOT_SUPPORT = -94,
			MM_ERR_USER_NOT_VERIFYUSER = -302,
			MM_ERR_USEREXIST = -7,
			MM_ERR_USERNAMEINVALID = -14,
			MM_ERR_USERRESERVED = -10,
			MM_ERR_UUID_BINDED = -76,
			MM_ERR_VERIFYCODE_NOTEXIST = -51,
			MM_ERR_VERIFYCODE_TIMEOUT = -33,
			MM_ERR_VERIFYCODE_UNMATCH,
			MM_ERR_WEIBO_PUSH_TRANS = -80,
			MM_ERR_WRONG_SESSION_KEY = -77,
			MM_FACEBOOK_ACCESSTOKEN_UNVALID = -68,
			MM_OK = 0,
			MMSNS_RET_BAN = 202,
			MMSNS_RET_CLIENTID_EXIST = 206,
			MMSNS_RET_COMMENT_HAVE_LIKE = 204,
			MMSNS_RET_COMMENT_NOT_ALLOW,
			MMSNS_RET_COMMENT_PRIVACY = 208,
			MMSNS_RET_ISALL = 207,
			MMSNS_RET_PRIVACY = 203,
			MMSNS_RET_SPAM = 201
		}

		public enum syncScene
		{
			MM_NEWSYNC_SCENE_AFTERINIT = 5,
			MM_NEWSYNC_SCENE_BG2FG = 3,
			MM_NEWSYNC_SCENE_CONTINUEFLAG = 6,
			MM_NEWSYNC_SCENE_NOTIFY = 1,
			MM_NEWSYNC_SCENE_OTHER = 7,
			MM_NEWSYNC_SCENE_PROCESSSTART = 4,
			MM_NEWSYNC_SCENE_TIMER = 2
		}

		public enum enMMTenPayCgiCmd
		{
			MMTENPAY_BIZ_CGICMD_PLATFORM_NOTIFY_CHECK_RESULT = 27,
			MMTENPAY_BIZ_CGICMD_PLATFORM_QUERY_BZJ_INFO = 34,
			MMTENPAY_BIZ_CGICMD_PLATFORM_QUERY_CHECK_RECORD = 23,
			MMTENPAY_BIZ_CGICMD_PLATFORM_QUERY_CHECK_RESULT = 25,
			MMTENPAY_BIZ_CGICMD_QUERY_BIZ_CHECK_RESULT = 56,
			MMTENPAY_BIZ_CGICMD_QUERY_NEW_PARTNER_ID = 55,
			MMTENPAY_BIZ_CGICMD_WEB_NOTIFY_CHECK_RESULT = 26,
			MMTENPAY_BIZ_CGICMD_WEB_QUERY_CHECK_RECORD = 22,
			MMTENPAY_BIZ_CGICMD_WEB_QUERY_CHECK_RESULT = 24,
			MMTENPAY_BIZ_CGICMD_WX_QRY_AUTH_INFO = 70,
			MMTENPAY_CGICMD_AUTHEN = 0,
			MMTENPAY_CGICMD_BANK_QUERY = 7,
			MMTENPAY_CGICMD_BANKCARDBIN_QUERY = 15,
			MMTENPAY_CGICMD_BIND_AUTHEN = 12,
			MMTENPAY_CGICMD_BIND_QUERY_NEW = 72,
			MMTENPAY_CGICMD_BIND_VERIFY = 13,
			MMTENPAY_CGICMD_BIND_VERIFY_REG = 17,
			MMTENPAY_CGICMD_CHANGE_PWD = 9,
			MMTENPAY_CGICMD_CHECK_PWD = 18,
			MMTENPAY_CGICMD_CHKPAYACC = 79,
			MMTENPAY_CGICMD_ELEM_QUERY_NEW = 73,
			MMTENPAY_CGICMD_GEN_PRE_FETCH = 75,
			MMTENPAY_CGICMD_GEN_PRE_SAVE = 74,
			MMTENPAY_CGICMD_GEN_PRE_TRANSFER = 83,
			MMTENPAY_CGICMD_GET_FIXED_AMOUNT_QRCODE = 94,
			MMTENPAY_CGICMD_IMPORT_BIND_QUERY = 37,
			MMTENPAY_CGICMD_IMPORT_ENCRYPT_QUERY,
			MMTENPAY_CGICMD_MCH_TRADE = 28,
			MMTENPAY_CGICMD_NONPAY = 92,
			MMTENPAY_CGICMD_OFFLINE_CHG_FEE = 50,
			MMTENPAY_CGICMD_OFFLINE_CLOSE = 47,
			MMTENPAY_CGICMD_OFFLINE_CREATE = 46,
			MMTENPAY_CGICMD_OFFLINE_FPAY = 48,
			MMTENPAY_CGICMD_OFFLINE_GET_TOKEN = 52,
			MMTENPAY_CGICMD_OFFLINE_QUERY_USER = 49,
			MMTENPAY_CGICMD_OFFLINE_UNFREEZE = 51,
			MMTENPAY_CGICMD_PAYRELAY = 87,
			MMTENPAY_CGICMD_PAYUNREG = 71,
			MMTENPAY_CGICMD_PUBLIC_API = 21,
			MMTENPAY_CGICMD_QRCODE_CREATE = 5,
			MMTENPAY_CGICMD_QRCODE_TO_BARCODE = 78,
			MMTENPAY_CGICMD_QRCODE_USE = 6,
			MMTENPAY_CGICMD_QUERY_REFUND = 80,
			MMTENPAY_CGICMD_QUERY_TRANSFER_STATUS = 84,
			MMTENPAY_CGICMD_QUERY_USER_TYPE = 30,
			MMTENPAY_CGICMD_RESET_PWD = 20,
			MMTENPAY_CGICMD_RESET_PWD_AUTHEN = 10,
			MMTENPAY_CGICMD_RESET_PWD_VERIFY,
			MMTENPAY_CGICMD_TIMESEED = 19,
			MMTENPAY_CGICMD_TRANSFEAR_SEND_CANCEL_MSG = 97,
			MMTENPAY_CGICMD_TRANSFER_CONFIRM = 85,
			MMTENPAY_CGICMD_TRANSFER_GET_USERNAME = 95,
			MMTENPAY_CGICMD_TRANSFER_RETRYSENDMESSAGE = 86,
			MMTENPAY_CGICMD_UNBIND = 14,
			MMTENPAY_CGICMD_USER_ROLL = 3,
			MMTENPAY_CGICMD_USER_ROLL_BATCH,
			MMTENPAY_CGICMD_USER_ROLL_SAVE_AND_FETCH = 77,
			MMTENPAY_CGICMD_VERIFY = 1,
			MMTENPAY_CGICMD_VERIFY_BIND = 76,
			MMTENPAY_CGICMD_VERIFY_REG = 16,
			MMTENPAY_CGICMD_WX_FUND_ACCOUNT_QUERY = 43,
			MMTENPAY_CGICMD_WX_FUND_BINDSP_QUERY = 42,
			MMTENPAY_CGICMD_WX_FUND_BUY = 39,
			MMTENPAY_CGICMD_WX_FUND_CHANGE = 41,
			MMTENPAY_CGICMD_WX_FUND_PROFIT_QUERY = 44,
			MMTENPAY_CGICMD_WX_FUND_REDEM = 40,
			MMTENPAY_CGICMD_WX_FUND_SUPPORT_BANK = 45,
			MMTENPAY_CGICMD_WX_GET_MERSIGN_ORDER = 88,
			MMTENPAY_CGICMD_WX_GET_MERSIGN_SIMPLE = 90,
			MMTENPAY_CGICMD_WX_HB_REDPACKETNOTIFY = 53,
			MMTENPAY_CGICMD_WX_HBAA_TRANSFER = 81,
			MMTENPAY_CGICMD_WX_OFFLINE_AUTHEN = 35,
			MMTENPAY_CGICMD_WX_OFFLINE_PAY,
			MMTENPAY_CGICMD_WX_PAY_CONFIRM = 82,
			MMTENPAY_CGICMD_WX_QUERY_BANK_ROLL_LIST_BATCH = 93,
			MMTENPAY_CGICMD_WX_QUERY_ORDER = 96,
			MMTENPAY_CGICMD_WX_QUERY_SP_BANK = 91,
			MMTENPAY_CGICMD_WX_SP_CLOSE_ORDER = 54,
			MMTENPAY_CGICMD_WX_VERIFY_MERSIGN = 89,
			MMTENPAY_CGICMD_WXCREDIT_AUTHEN = 64,
			MMTENPAY_CGICMD_WXCREDIT_COMMIT_QUESTION = 60,
			MMTENPAY_CGICMD_WXCREDIT_QUERY = 57,
			MMTENPAY_CGICMD_WXCREDIT_QUERY_BILL_DETAIL = 67,
			MMTENPAY_CGICMD_WXCREDIT_QUERY_CARD_DETAIL = 58,
			MMTENPAY_CGICMD_WXCREDIT_QUERY_PRIVILEGE = 68,
			MMTENPAY_CGICMD_WXCREDIT_QUERY_QUESTION = 59,
			MMTENPAY_CGICMD_WXCREDIT_RENEW_IDENTIFY = 69,
			MMTENPAY_CGICMD_WXCREDIT_REPAY = 61,
			MMTENPAY_CGICMD_WXCREDIT_SIMPLE_VERIFY = 66,
			MMTENPAY_CGICMD_WXCREDIT_UNBIND = 62,
			MMTENPAY_CGICMD_WXCREDIT_VERIFY = 65,
			MMTENPAY_CGICMD_WXCREDIT_VERIFY_PASSWD = 63,
			MMTENPAY_GW_CGICMD_NORMAL_ORDER_QUERY = 29,
			MMTENPAY_GW_CGICMD_NORMAL_REFUND_QUERY = 33,
			MMTENPAY_GW_CGICMD_VERIFY_NOTIFY_ID = 31
		}

		public enum LongLinkCmdId
		{
			SEND_DOWNLOADVOICE = 20,
			RECV_DOWNLOADVOICE = 1000000020,
			SEND_GETPROFILE = 118,
			RECV_GETPROFILE = 1000000118,
			SEND_GETLOGINQRCODE = 232,
			RECV_GETLOGINQRCODE = 1000000232,
			SEND_CHECKLOGINQRCODE_CMDID = 233,
			RECV_CHECKLOGINQRCODE_CMDID = 1000000233,
			RECV_PUSH_CMDID = 24,
			SEND_NOOP_CMDID = 6,
			SEND_MSGIMG_CMDID = 9,
			RECV_MSGIMG_CMDID = 1000000009,
			RECV_NOOP_CMDID = 1000000006,
			SEND_NEWSYNC_CMDID = 121,
			RECV_NEWSYNC_CMDID = 1000000121,
			LONGLINK_IDENTIFY_REQ = 205,
			LONGLINK_IDENTIFY_RESP = 1000000205,
			PUSH_DATA_CMDID = 122,
			SEND_SYNC_SUCCESS = 1000000190,
			SIGNALKEEP_CMDID = 243,
			NEWSENDMSG = 237,
			SEND_MANUALAUTH_CMDID = 253
		}

		public enum CGI_TYPE
		{
			CGI_TYPE_INITCONTACT = 851,
			CGI_TYPE_EXTDEVICELOGINCONFIRMGET = 971,
			CGI_TYPE_SNSOBJECTOP = 218,
			CGI_TYPE_MMSNSTAGLIST = 292,
			CGI_TYPE_MMSNSPORT = 209,
			CGI_TYPE_MMSNSOBJECTDETAIL,
			CGI_TYPE_MMSNSTIMELINE,
			CGI_TYPE_MMSNSSYNC = 214,
			CGI_TYPE_OPLOG = 681,
			CGI_TYPE_DEFAULT = 0,
			CGI_TYPE_GETOPENIMRESOURCE = 453,
			CGI_TYPE_GETLOGINQRCODE = 502,
			CGI_TYPE_CHECKLOGINQRCODE,
			CGI_TYPE_NEWSENDMSG = 522,
			CGI_TYPE_GETEMOTIONDESC = 521,
			CGI_TYPE_SENDEMOJI = 175,
			CGI_TYPE_NEWSYNC = 138,
			CGI_TYPE_MANUALAUTH = 701,
			CGI_TYPE_UPLOADIMAGE = 625,
			CGI_TYPE_UPLOADMCONTACT = 133,
			CGI_TYPE_FAVSYNC = 400,
			CGI_TYPE_ADDFAVITEM,
			CGI_TYPE_BATCHGETFAVITEM,
			CGI_TYPE_GETPROFILE = 302,
			CGI_TYPE_GETFAVINFO = 438,
			CGI_TYPE_GETCONTACTLABELLIST = 639,
			CGI_TYPE_UPLOADVOICE = 127,
			CGI_TYPE_SENDAPPMSG = 222,
			CGI_TYPE_UPLOADVIDEO = 149,
			CGI_TYPE_MMSNSUSERPAGE = 212,
			CGI_TYPE_MMSNSUPLOAD = 207,
			CGI_TYPE_MMSNSCOMMENT = 213,
			CGI_TYPE_GETCONTACT = 182,
			CGI_TYPE_GETCDNDNS = 379,
			CGI_TYPE_GETMSGIMG = 109,
			CGI_TYPE_STATUSNOTIFY = 251,
			CGI_TYPE_GETCHATROOMMEMBERDETAIL = 551,
			CGI_TYPE_GETCHATROOMINFODETAIL = 223,
			CGI_TYPE_DOWNLOADVOICE = 128,
			CGI_TYPE_HEARTBEAT = 518,
			CGI_TYPE_GETONLINEINFO = 526,
			CGI_TYPE_PUSHLOGINURL = 654,
			CGI_TYPE_TENPAY = 385,
			CGI_TYPE_F2FQRCODE = 1588,
			CGI_TYPE_TRANSFERSETF2FFEE = 1623,
			CGI_TYPE_GETPAYFUNCTIONLIST = 495,
			CGI_TYPE_GETBANNERINFO = 1679,
			CGI_TYPE_TIMESEED = 477,
			CGI_TYPE_TRANSFERQUERY = 1628,
			CGI_TYPE_GETTRANSFERWORDINH = 1992,
			CGI_TYPE_TRANSFEROPERATION = 1691,
			CGI_TYPE_BINDQUERYNEW = 1501,
			CGI_TYPE_VERIFYUSER = 137,
			CGI_TYPE_CREATECHATROOM = 119,
			CGI_TYPE_BATCHGETHEADIMG = 123,
			CGI_TYPE_ADDCHATROOMMEMBER = 120,
			CGI_TYPE_DELCHATROOMMEMBER = 179,
			CGI_TYPE_GETA8KEY = 233,
			CGI_TYPE_ADEXPOSURE = 1231,
			CGI_TYPE_ADCLICK,
			CGI_TYPE_MASSSEND = 193,
			CGI_TYPE_RECEIVEWXHB = 1581,
			CGI_TYPE_OPENWXHB = 1685,
			CGI_TYPE_QRYDETAILWXHB = 1585,
			CGI_TYPE_QRYLISTWXHB = 1514,
			CGI_TYPE_WISHWXHB = 1682,
			CGI_TYPE_NEWGETINVITEFRIEND = 135,
			CGI_TYPE_LBSFIND = 148,
			CGI_TYPE_SETCHATROOMANNOUNCEMENT = 993,
			CGI_TYPE_GETQRCODE = 168,
			CGI_TYPE_SEARCHCONTACT = 106
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct URL
		{
			public static string CGI_EXTDEVICELOGINCONFIRMGET = "/cgi-bin/micromsg-bin/extdeviceloginconfirmget";

			public static string CGI_MMSNSTIMELINE = "/cgi-bin/micromsg-bin/mmsnstimeline";

			public static string CGI_MMSNSTAGLIST = "/cgi-bin/micromsg-bin/mmsnstaglist";

			public static string CGI_MMSNSPORT = "/cgi-bin/micromsg-bin/mmsnspost";

			public static string CGI_MMSNSOBJECTDETAIL = "/cgi-bin/micromsg-bin/mmsnsobjectdetail";

			public static string CGI_MMSNSOBJECTOP = "/cgi-bin/micromsg-bin/mmsnsobjectop";

			public static string CGI_OPLOG = "/cgi-bin/micromsg-bin/oplog";

			public static string CGI_MANUALAUTH = "/cgi-bin/micromsg-bin/manualauth";

			public static string CGI_NEWSYNC = "/cgi-bin/micromsg-bin/newsync";

			public static string CGI_NEWSENDMSG = "/cgi-bin/micromsg-bin/newsendmsg";

			public static string CGI_STATUSNOTIFY = "/cgi-bin/micromsg-bin/statusnotify";

			public static string CGI_UPLOADIMAGE = "/cgi-bin/micromsg-bin/uploadmsgimg";

			public static string CGI_ADDFAVITEM = "/cgi-bin/micromsg-bin/addfavitem";

			public static string CGI_FAVSYNC = "/cgi-bin/micromsg-bin/favsync";

			public static string CGI_GETFAVINFO = "/cgi-bin/micromsg-bin/getfavinfo";

			public static string CGI_BATCHGETFAVITEM = "/cgi-bin/micromsg-bin/batchgetfavitem";

			public static string CGI_GETEMOTIONDESC = "/cgi-bin/micromsg-bin/getemotiondesc";

			public static string CGI_SENDEMOJI = "/cgi-bin/micromsg-bin/sendemoji";

			public static string CGI_GETCONTACTLABELLIST = "/cgi-bin/micromsg-bin/getcontactlabellist";

			public static string CGI_UPLOADVOICE = "/cgi-bin/micromsg-bin/uploadvoice";

			public static string CGI_SENDAPPMSG = "/cgi-bin/micromsg-bin/sendappmsg";

			public static string CGI_UPLOADVIDEO = "/cgi-bin/micromsg-bin/uploadvideo";

			public static string CGI_MMSNSUSERPAGE = "/cgi-bin/micromsg-bin/mmsnsuserpage";

			public static string CGI_MMSNSCOMMENT = "/cgi-bin/micromsg-bin/mmsnscomment";

			public static string CGI_GETCONTACT = "/cgi-bin/micromsg-bin/getcontact";

			public static string CGI_GETCDNDNS = "/cgi-bin/micromsg-bin/getcdndns";

			public static string CGI_GETPROFILE = "/cgi-bin/micromsg-bin/getprofile";

			public static string CGI_GETMSGIMG = "/cgi-bin/micromsg-bin/getmsgimg";

			public static string CGI_CHECKLOGINQRCODE = "/cgi-bin/micromsg-bin/checkloginqrcode";

			public static string CGI_GETLOGINQRCODE = "/cgi-bin/micromsg-bin/getloginqrcode";

			public static string CGI_GETOPENIMRESOURCE = "/cgi-bin/micromsg-bin/getopenimresource";

			public static string CGI_GETCHATROOMMEMBERDETAIL = "/cgi-bin/micromsg-bin/getchatroommemberdetail";

			public static string CGI_GETCHATROOMINFODETAIL = "/cgi-bin/micromsg-bin/getchatroominfodetail";

			public static string CGI_DOWNLOADVOICE = "/cgi-bin/micromsg-bin/downloadvoice";

			public static string CGI_HEARTBEAT = "/cgi-bin/micromsg-bin/heartbeat";

			public static string CGI_GETONLINEINFO = "/cgi-bin/micromsg-bin/getonlineinfo";

			public static string CGI_PUSHLOGINURL = "/cgi-bin/micromsg-bin/pushloginurl";

			public static string CGI_TIMESEED = "/cgi-bin/mmpay-bin/tenpay/timeseed";

			public static string CGI_TENPAY = "/cgi-bin/micromsg-bin/tenpay";

			public static string CGI_F2FQRCODE = "/cgi-bin/mmpay-bin/f2fqrcode";

			public static string CGI_TRANSFERSETF2FFEE = "/cgi-bin/mmpay-bin/transfersetf2ffee";

			public static string CGI_BINDQUERYNEW = "/cgi-bin/mmpay-bin/tenpay/bindquerynew";

			public static string CGI_GETBANNERINFO = "/cgi-bin/mmpay-bin/tenpay/getbannerinfo";

			public static string CGI_GETPAYFUNCTIONLIST = "/cgi-bin/micromsg-bin/getpayfunctionlist";

			public static string CGI_TRANSFERQUERY = "/cgi-bin/mmpay-bin/transferquery";

			public static string CGI_GETTRANSFERWORDINH = "/cgi-bin/mmpay-bin/gettransferwording";

			public static string CGI_TRANSFEROPERATION = "/cgi-bin/mmpay-bin/transferoperation";

			public static string CGI_VERIFYUSER = "/cgi-bin/micromsg-bin/verifyuser";

			public static string CGI_CREATECHATROOM = "/cgi-bin/micromsg-bin/createchatroom";

			public static string CGI_BATCHGETHEADIMG = "/cgi-bin/micromsg-bin/batchgetheadimg";

			public static string CGI_ADDCHATROOMMEMBER = "/cgi-bin/micromsg-bin/addchatroommember";

			public static string CGI_DELCHATROOMMEMBER = "/cgi-bin/micromsg-bin/delchatroommember";

			public static string CGI_GETA8KEY = "/cgi-bin/micromsg-bin/geta8key";

			public static string CGI_ADCLICK = "/cgi-bin/mmoc-bin/ad/click";

			public static string CGI_ADEXPOSURE = "/cgi-bin/mmoc-bin/ad/exposure";

			public static string CGI_MMSNSSYNC = "/cgi-bin/micromsg-bin/mmsnssync";

			public static string CGI_MASSSEND = "/cgi-bin/micromsg-bin/masssend";

			public static string CGI_MMSNSUPLOAD = "/cgi-bin/micromsg-bin/mmsnsupload";

			public static string CGI_INITCONTACT = "/cgi-bin/micromsg-bin/initcontact";

			public static string CGI_RECEIVEWXHB = "/cgi-bin/mmpay-bin/receivewxhb";

			public static string CGI_OPENWXHB = "/cgi-bin/mmpay-bin/openwxhb";

			public static string CGI_QRYDETAILWXHB = "/cgi-bin/mmpay-bin/qrydetailwxhb";

			public static string CGI_QRYLISTWXHB = "/cgi-bin/mmpay-bin/qrylistwxhb";

			public static string CGI_WISHWXHB = "/cgi-bin/mmpay-bin/wishwxhb";

			public static string CGI_NEWGETINVITEFRIEND = "/cgi-bin/micromsg-bin/newgetinvitefriend";

			public static string CGI_UPLOADMCONTACT = "/cgi-bin/micromsg-bin/uploadmcontact";

			public static string CGI_LBSFIND = "/cgi-bin/micromsg-bin/lbsfind";

			public static string CGI_SETCHATROOMANNOUNCEMENT = "/cgi-bin/micromsg-bin/setchatroomannouncement";

			public static string CGI_GETQRCODE = "/cgi-bin/micromsg-bin/getqrcode";

			public static string CGI_SEARCHCONTACT = "/cgi-bin/micromsg-bin/searchcontact";
		}

		public enum CmdConst
		{
			MM_CMDID_CancelQRPay = 198,
			MM_CMDID_GenPrepay = 189,
			MM_CMDID_GetBizIapDetail = 234,
			MM_CMDID_GetBizIapPayResult,
			MM_CMDID_GetLatestPayProductInfo = 229,
			MM_CMDID_GetOrderList = 236,
			MM_CMDID_GetPayFunctionList = 227,
			MM_CMDID_GetPayFunctionProductList,
			MM_CMDID_GetProductInfo = 219,
			MM_CMDID_NEW_YEAR_SHAKE_REQ = 309,
			MM_CMDID_NEW_YEAR_SHAKE_RESP = 1000000309,
			MM_CMDID_PayAuthApp = 188,
			MM_CMDID_PayDelUserRoll = 187,
			MM_CMDID_PayQueryUserRoll = 186,
			MM_CMDID_PaySubscribe = 206,
			MM_CMDID_PreparePurchase = 214,
			MM_CMDID_RcptInfoAdd = 200,
			MM_CMDID_RcptInfoQuery = 202,
			MM_CMDID_RcptInfoRemove = 201,
			MM_CMDID_RcptInfoTouch = 204,
			MM_CMDID_RcptInfoUpdate = 203,
			MM_CMDID_SubmitPayProductBuyInfo = 230,
			MM_CMDID_TenPay = 185,
			MM_CMDID_VerifyPurchase = 215,
			MM_PKT_ADD_FAV_ITEM_REQ = 193,
			MM_PKT_ADD_FAV_ITEM_RESP = 1000000193,
			MM_PKT_ADDCHATROOMMEMBER_REQ = 36,
			MM_PKT_ASYNCDOWNLOADVOICE_REQ = 22,
			MM_PKT_ASYNCDOWNLOADVOICE_RESP = 1000000022,
			MM_PKT_AUTH_RESP = 1000000001,
			MM_PKT_BAKCHAT_RECOVER_DATA_REQ = 140,
			MM_PKT_BAKCHAT_RECOVER_DATA_RESP = 1000000140,
			MM_PKT_BAKCHAT_RECOVER_DELETE_REQ = 141,
			MM_PKT_BAKCHAT_RECOVER_DELETE_RESP = 1000000141,
			MM_PKT_BAKCHAT_RECOVER_GETLIST_REQ = 138,
			MM_PKT_BAKCHAT_RECOVER_GETLIST_RESP = 1000000138,
			MM_PKT_BAKCHAT_RECOVER_HEAD_REQ = 139,
			MM_PKT_BAKCHAT_RECOVER_HEAD_RESP = 1000000139,
			MM_PKT_BAKCHAT_UPLOAD_END_REQ = 135,
			MM_PKT_BAKCHAT_UPLOAD_END_RESP = 1000000135,
			MM_PKT_BAKCHAT_UPLOAD_HEAD_REQ = 134,
			MM_PKT_BAKCHAT_UPLOAD_HEAD_RESP = 1000000134,
			MM_PKT_BAKCHAT_UPLOAD_MEDIA_REQ = 137,
			MM_PKT_BAKCHAT_UPLOAD_MEDIA_RESP = 1000000137,
			MM_PKT_BAKCHAT_UPLOAD_MSG_REQ = 136,
			MM_PKT_BAKCHAT_UPLOAD_MSG_RESP = 1000000136,
			MM_PKT_BATCH_DEL_FAV_ITEM_REQ = 194,
			MM_PKT_BATCH_DEL_FAV_ITEM_RESP = 1000000194,
			MM_PKT_BATCH_GET_SHAKE_TRAN_IMG_REQ = 129,
			MM_PKT_BATCH_GET_SHAKE_TRAN_IMG_RESP = 1000000129,
			MM_PKT_BATCHGETCONTACTPROFILE_REQ = 28,
			MM_PKT_BATCHGETCONTACTPROFILE_RESP = 1000000028,
			MM_PKT_BULLETIN_REQ = 72,
			MM_PKT_CHECKUNBIND_REQ = 131,
			MM_PKT_CHECKUNBIND_RESP = 1000000131,
			MM_PKT_CLICK_COMMAND_REQ = 176,
			MM_PKT_CLICK_COMMAND_RESP = 1000000176,
			MM_PKT_CONNCONTROL_REQ = 11,
			MM_PKT_CREATECHATROOM_REQ = 37,
			MM_PKT_DEL_SAFEDEVICE_REQ = 172,
			MM_PKT_DEL_SAFEDEVICE_RESP = 1000000172,
			MM_PKT_DIRECTSEND_REQ = 8,
			MM_PKT_DOWNLOAD_APP_ATTACH_REQ = 106,
			MM_PKT_DOWNLOAD_APP_ATTACH_RESP = 1000000106,
			MM_PKT_DOWNLOADVIDEO_REQ = 40,
			MM_PKT_DOWNLOADVOICE_REQ = 20,
			MM_PKT_DOWNLOADVOICE_RESP = 1000000020,
			MM_PKT_EXCHANGE_EMOTION_PACK_REQ = 213,
			MM_PKT_EXCHANGE_EMOTION_PACK_RESP = 1000000213,
			MM_PKT_EXPOSE_REQ = 59,
			MM_PKT_EXPOSE_RESP = 1000000059,
			MM_PKT_FAV_CHECKCDN_REQ = 197,
			MM_PKT_FAV_CHECKCDN_RESP = 1000000197,
			MM_PKT_FAV_SYNC_REQ = 195,
			MM_PKT_FAV_SYNC_RESP = 1000000195,
			MM_PKT_FAVNOTIFY_REQ = 192,
			MM_PKT_FIXSYNCCHECK_REQ = 30,
			MM_PKT_FIXSYNCCHECK_RESP = 1000000030,
			MM_PKT_GENERALSET_REQ = 70,
			MM_PKT_GENERALSET_RESP = 1000000070,
			MM_PKT_GET_APP_INFO__RESP = 1000000108,
			MM_PKT_GET_APP_INFO_REQ = 108,
			MM_PKT_GET_CERT_REQ = 179,
			MM_PKT_GET_CERT_RESP = 1000000179,
			MM_PKT_GET_EMOTION_DETAIL_REQ = 211,
			MM_PKT_GET_EMOTION_DETAIL_RESP = 1000000211,
			MM_PKT_GET_EMOTION_LIST_REQ = 210,
			MM_PKT_GET_EMOTION_LIST_RESP = 1000000210,
			MM_PKT_GET_FAV_INFO_REQ = 217,
			MM_PKT_GET_FAV_INFO_RESP = 1000000217,
			MM_PKT_GET_PROFILE_REQ = 118,
			MM_PKT_GET_PROFILE_RESP = 1000000118,
			MM_PKT_GET_QRCODE_REQ = 67,
			MM_PKT_GET_QRCODE_RESP = 1000000067,
			MM_PKT_GET_RECOMMEND_APP_LIST_REQ = 109,
			MM_PKT_GET_RECOMMEND_APP_LIST_RESP = 1000000109,
			MM_PKT_GETA8KEY_REQ = 155,
			MM_PKT_GETA8KEY_RESP = 1000000155,
			MM_PKT_GETCONTACT_REQ = 71,
			MM_PKT_GETCONTACT_RESP = 1000000071,
			MM_PKT_GETINVITEFRIEND_REQ = 18,
			MM_PKT_GETINVITEFRIEND_RESP = 1000000018,
			MM_PKT_GETMSGIMG_REQ = 10,
			MM_PKT_GETMSGIMG_RESP = 1000000010,
			MM_PKT_GETPSMIMG_REQ = 29,
			MM_PKT_GETPSMIMG_RESP = 1000000029,
			MM_PKT_GETQQGROUP_REQ = 38,
			MM_PKT_GETQQGROUP_RESP = 1000000038,
			MM_PKT_GETUPDATEINFO_REQ = 35,
			MM_PKT_GETUPDATEPACK_REQ = 16,
			MM_PKT_GETUPDATEPACK_RESP = 1000000016,
			MM_PKT_GETUSERIMG_REQ = 15,
			MM_PKT_GETUSERIMG_RESP = 1000000015,
			MM_PKT_GETUSERNAME_REQ = 33,
			MM_PKT_GETUSERNAME_RESP = 1000000033,
			MM_PKT_GETVERIFYIMG_REQ = 48,
			MM_PKT_GETVUSERINFO_REQ = 60,
			MM_PKT_GETVUSERINFO_RESP = 1000000060,
			MM_PKT_INIT_REQ = 14,
			MM_PKT_INIT_RESP = 1000000014,
			MM_PKT_INVALID_REQ = 0,
			MM_PKT_KvReportRsa_REQ = 218,
			MM_PKT_KvReportRsa_RESP = 1000000218,
			MM_PKT_LBS_ROOM_MEMBER_REQ = 184,
			MM_PKT_LBS_ROOM_MEMBER_RESP = 1000000184,
			MM_PKT_LBS_ROOM_REQ = 183,
			MM_PKT_LBS_ROOM_RESP = 1000000183,
			MM_PKT_MASS_SEND_REQ = 84,
			MM_PKT_MASS_SEND_RESP = 1000000084,
			MM_PKT_MOD_EMOTION_PACK_REQ = 212,
			MM_PKT_MOD_EMOTION_PACK_RESP = 1000000212,
			MM_PKT_MOD_FAV_ITEM_REQ = 216,
			MM_PKT_MOD_FAV_ITEM_RESP = 1000000216,
			MM_PKT_NEW_AUTH_REQ = 178,
			MM_PKT_NEW_AUTH_RESP = 1000000178,
			MM_PKT_NEWGETINVITEFRIEND_REQ = 23,
			MM_PKT_NEWGETINVITEFRIEND_RESP = 1000000023,
			MM_PKT_NEWINIT_REQ = 27,
			MM_PKT_NEWINIT_RESP = 1000000027,
			MM_PKT_NEWNOTIFY_REQ = 24,
			MM_PKT_NEWNOTIFY_RESP = 1000000024,
			MM_PKT_NEWREG_REQ = 32,
			MM_PKT_NEWREG_RESP = 1000000032,
			MM_PKT_NEWSENDMSG_REQ = 237,
			MM_PKT_NEWSENDMSG_RESP = 1000000237,
			MM_PKT_NEWSYNC_REQ = 26,
			MM_PKT_NEWSYNC_RESP = 1000000026,
			MM_PKT_NEWSYNCCHECK_REQ = 25,
			MM_PKT_NEWSYNCCHECK_RESP = 1000000025,
			MM_PKT_NOOP_REQ = 6,
			MM_PKT_NOOP_RESP = 1000000006,
			MM_PKT_NOTIFY_REQ = 5,
			MM_PKT_PREPARE_PURCHASE_REQ = 214,
			MM_PKT_PREPARE_PURCHASE_RESP = 1000000214,
			MM_PKT_QUERY_HAS_PASSWD_REQ = 132,
			MM_PKT_QUERY_HAS_PASSWD_RESP = 1000000132,
			MM_PKT_QUIT_REQ = 7,
			MM_PKT_REDIRECT_REQ = 12,
			MM_PKT_REG_REQ = 31,
			MM_PKT_REG_RESP = 1000000031,
			MM_PKT_SEARCHCONTACT_REQ = 34,
			MM_PKT_SEARCHFRIEND_REQ = 17,
			MM_PKT_SEARCHFRIEND_RESP = 1000000017,
			MM_PKT_SEND_APP_MSG__RESP = 1000000107,
			MM_PKT_SEND_APP_MSG_REQ = 107,
			MM_PKT_SENDCARD_REQ = 42,
			MM_PKT_SENDCARD_RESP = 1000000042,
			MM_PKT_SENDINVITEMAIL_REQ = 41,
			MM_PKT_SENDMSG_RESP = 1000000002,
			MM_PKT_SENDVERIFYMAIL_REQ = 43,
			MM_PKT_SET_PWD_REQ = 180,
			MM_PKT_SET_PWD_RESP = 1000000180,
			MM_PKT_SHAKE_MUSIC_REQ = 177,
			MM_PKT_SHAKE_MUSIC_RESP = 1000000177,
			MM_PKT_SHAKE_TRAN_IMG_GET_REQ = 128,
			MM_PKT_SHAKE_TRAN_IMG_GET_RESP = 1000000128,
			MM_PKT_SHAKE_TRAN_IMG_REPORT_REQ = 127,
			MM_PKT_SHAKE_TRAN_IMG_REPORT_RESP = 1000000127,
			MM_PKT_SHAKE_TRAN_IMG_UNBIND_REQ = 130,
			MM_PKT_SHAKE_TRAN_IMG_UNBIND_RESP = 1000000130,
			MM_PKT_SHAKEGET_REQ = 57,
			MM_PKT_SHAKEGET_RESP = 1000000057,
			MM_PKT_SHAKEREPORT_REQ = 56,
			MM_PKT_SHAKEREPORT_RESP = 1000000056,
			MM_PKT_SNS_OBJECT_OP_REQ = 104,
			MM_PKT_SNS_OBJECT_OP_RESP = 1000000104,
			MM_PKT_SNS_POST_REQ = 97,
			MM_PKT_SNS_POST_RESP = 1000000097,
			MM_PKT_SNS_SYNC_REQ = 102,
			MM_PKT_SNS_SYNC_RESP = 1000000102,
			MM_PKT_SNS_TAG_LIST_REQ = 116,
			MM_PKT_SNS_TAG_LIST_RESP = 1000000116,
			MM_PKT_SNS_TAG_MEMBER_MUTIL_SET_REQ = 117,
			MM_PKT_SNS_TAG_MEMBER_MUTIL_SET_RESP = 1000000117,
			MM_PKT_SNS_TAG_MEMBER_OP_REQ = 115,
			MM_PKT_SNS_TAG_MEMBER_OP_RESP = 1000000115,
			MM_PKT_SNS_TAG_OP_REQ = 114,
			MM_PKT_SNS_TAG_OP_RESP = 1000000114,
			MM_PKT_SNS_TIME_LINE_REQ = 98,
			MM_PKT_SNS_TIME_LINE_RESP = 1000000098,
			MM_PKT_SNS_UPLOAD_REQ = 95,
			MM_PKT_SNS_UPLOAD_RESP = 1000000095,
			MM_PKT_SNS_USER_PAGE_REQ = 99,
			MM_PKT_SNS_USER_PAGE_RESP = 1000000099,
			MM_PKT_SNSCOMMENT_REQ = 100,
			MM_PKT_SNSOBJECTDETAIL_REQ,
			MM_PKT_SYNC_REQ = 3,
			MM_PKT_SYNC_RESP = 1000000003,
			MM_PKT_SYNCHECK_REQ = 13,
			MM_PKT_SYNCHECK_RESP = 1000000013,
			MM_PKT_TALKROOMADDMEMBER_REQ = 169,
			MM_PKT_TALKROOMADDMEMBER_RESP = 1000000169,
			MM_PKT_TALKROOMCREATE_REQ = 168,
			MM_PKT_TALKROOMCREATE_RESP = 1000000168,
			MM_PKT_TALKROOMDELMEMBER_REQ = 170,
			MM_PKT_TALKROOMDELMEMBER_RESP = 1000000170,
			MM_PKT_TALKROOMENTER_REQ = 147,
			MM_PKT_TALKROOMENTER_RESP = 1000000147,
			MM_PKT_TALKROOMEXIT_REQ = 148,
			MM_PKT_TALKROOMEXIT_RESP = 1000000148,
			MM_PKT_TALKROOMINVITE_REQ = 174,
			MM_PKT_TALKROOMINVITE_RESP = 1000000174,
			MM_PKT_TALKROOMMICACTION_REQ = 146,
			MM_PKT_TALKROOMMICACTION_RESP = 1000000146,
			MM_PKT_TALKROOMNOOP_REQ = 149,
			MM_PKT_TALKROOMNOOP_RESP = 1000000149,
			MM_PKT_TOKEN_REQ = 4,
			MM_PKT_TOKEN_RESP = 1000000004,
			MM_PKT_UPDATE_SAFEDEVICE_REQ = 171,
			MM_PKT_UPDATE_SAFEDEVICE_RESP = 1000000171,
			MM_PKT_UPLOAD_APP_ATTACH_REQ = 105,
			MM_PKT_UPLOAD_APP_ATTACH_RESP = 1000000105,
			MM_PKT_UPLOADMSGIMG_REQ = 9,
			MM_PKT_UPLOADMSGIMG_RESP = 1000000009,
			MM_PKT_UPLOADVIDEO_REQ = 39,
			MM_PKT_UPLOADVOICE_REQ = 19,
			MM_PKT_UPLOADVOICE_RESP = 1000000019,
			MM_PKT_UPLOADWEIBOIMG_REQ = 21,
			MM_PKT_UPLOADWEIBOIMG_RESP = 1000000021,
			MM_PKT_VERIFY_PURCHASE_REQ = 215,
			MM_PKT_VERIFY_PURCHASE_RESP = 1000000215,
			MM_PKT_VERIFY_PWD_REQ = 182,
			MM_PKT_VERIFY_PWD_RESP = 1000000182,
			MM_PKT_VERIFYUSER = 44,
			MM_PKT_VOICETRANS_NOTIFY = 241,
			MM_PKT_VOIP_REQ = 120,
			MM_PKT_VOIPANSWER_REQ = 65,
			MM_PKT_VOIPANSWER_RESP = 1000000065,
			MM_PKT_VOIPCANCELINVITE_REQ = 64,
			MM_PKT_VOIPCANCELINVITE_RESP = 1000000064,
			MM_PKT_VOIPHEARTBEAT_REQ = 81,
			MM_PKT_VOIPHEARTBEAT_RESP = 1000000081,
			MM_PKT_VOIPINVITE_REQ = 63,
			MM_PKT_VOIPINVITE_RESP = 1000000063,
			MM_PKT_VOIPINVITEREMIND_REQ = 125,
			MM_PKT_VOIPINVITEREMIND_RESP = 1000000125,
			MM_PKT_VOIPNOTIFY_REQ = 61,
			MM_PKT_VOIPNOTIFY_RESP = 1000000061,
			MM_PKT_VOIPSHUTDOWN_REQ = 66,
			MM_PKT_VOIPSHUTDOWN_RESP = 1000000066,
			MM_PKT_VOIPSYNC_REQ = 62,
			MM_PKT_VOIPSYNC_RESP = 1000000062
		}

		[DesignerCategory("code"), XmlRoot(Namespace = "", IsNullable = false), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsg
		{
			private string titleField;

			private string desField;

			private object usernameField;

			private string actionField;

			private byte typeField;

			private byte showtypeField;

			private object contentField;

			private string urlField;

			private object lowurlField;

			private object dataurlField;

			private object lowdataurlField;

			private byte contentattrField;

			private MM.appmsgStreamvideo streamvideoField;

			private MM.appmsgCanvasPageItem canvasPageItemField;

			private MM.appmsgAppattach appattachField;

			private object extinfoField;

			private byte androidsourceField;

			private string sourceusernameField;

			private string sourcedisplaynameField;

			private object commenturlField;

			private object thumburlField;

			private object mediatagnameField;

			private string messageactionField;

			private string messageextField;

			private MM.appmsgEmoticongift emoticongiftField;

			private MM.appmsgEmoticonshared emoticonsharedField;

			private MM.appmsgDesignershared designersharedField;

			private MM.appmsgEmotionpageshared emotionpagesharedField;

			private MM.appmsgWebviewshared webviewsharedField;

			private object template_idField;

			private object md5Field;

			private MM.appmsgWeappinfo weappinfoField;

			private object statextstrField;

			private object websearchField;

			private string appidField;

			private byte sdkverField;

			public string title
			{
				get
				{
					return this.titleField;
				}
				set
				{
					this.titleField = value;
				}
			}

			public string des
			{
				get
				{
					return this.desField;
				}
				set
				{
					this.desField = value;
				}
			}

			public object username
			{
				get
				{
					return this.usernameField;
				}
				set
				{
					this.usernameField = value;
				}
			}

			public string action
			{
				get
				{
					return this.actionField;
				}
				set
				{
					this.actionField = value;
				}
			}

			public byte type
			{
				get
				{
					return this.typeField;
				}
				set
				{
					this.typeField = value;
				}
			}

			public byte showtype
			{
				get
				{
					return this.showtypeField;
				}
				set
				{
					this.showtypeField = value;
				}
			}

			public object content
			{
				get
				{
					return this.contentField;
				}
				set
				{
					this.contentField = value;
				}
			}

			public string url
			{
				get
				{
					return this.urlField;
				}
				set
				{
					this.urlField = value;
				}
			}

			public object lowurl
			{
				get
				{
					return this.lowurlField;
				}
				set
				{
					this.lowurlField = value;
				}
			}

			public object dataurl
			{
				get
				{
					return this.dataurlField;
				}
				set
				{
					this.dataurlField = value;
				}
			}

			public object lowdataurl
			{
				get
				{
					return this.lowdataurlField;
				}
				set
				{
					this.lowdataurlField = value;
				}
			}

			public byte contentattr
			{
				get
				{
					return this.contentattrField;
				}
				set
				{
					this.contentattrField = value;
				}
			}

			public MM.appmsgStreamvideo streamvideo
			{
				get
				{
					return this.streamvideoField;
				}
				set
				{
					this.streamvideoField = value;
				}
			}

			public MM.appmsgCanvasPageItem canvasPageItem
			{
				get
				{
					return this.canvasPageItemField;
				}
				set
				{
					this.canvasPageItemField = value;
				}
			}

			public MM.appmsgAppattach appattach
			{
				get
				{
					return this.appattachField;
				}
				set
				{
					this.appattachField = value;
				}
			}

			public object extinfo
			{
				get
				{
					return this.extinfoField;
				}
				set
				{
					this.extinfoField = value;
				}
			}

			public byte androidsource
			{
				get
				{
					return this.androidsourceField;
				}
				set
				{
					this.androidsourceField = value;
				}
			}

			public string sourceusername
			{
				get
				{
					return this.sourceusernameField;
				}
				set
				{
					this.sourceusernameField = value;
				}
			}

			public string sourcedisplayname
			{
				get
				{
					return this.sourcedisplaynameField;
				}
				set
				{
					this.sourcedisplaynameField = value;
				}
			}

			public object commenturl
			{
				get
				{
					return this.commenturlField;
				}
				set
				{
					this.commenturlField = value;
				}
			}

			public object thumburl
			{
				get
				{
					return this.thumburlField;
				}
				set
				{
					this.thumburlField = value;
				}
			}

			public object mediatagname
			{
				get
				{
					return this.mediatagnameField;
				}
				set
				{
					this.mediatagnameField = value;
				}
			}

			public string messageaction
			{
				get
				{
					return this.messageactionField;
				}
				set
				{
					this.messageactionField = value;
				}
			}

			public string messageext
			{
				get
				{
					return this.messageextField;
				}
				set
				{
					this.messageextField = value;
				}
			}

			public MM.appmsgEmoticongift emoticongift
			{
				get
				{
					return this.emoticongiftField;
				}
				set
				{
					this.emoticongiftField = value;
				}
			}

			public MM.appmsgEmoticonshared emoticonshared
			{
				get
				{
					return this.emoticonsharedField;
				}
				set
				{
					this.emoticonsharedField = value;
				}
			}

			public MM.appmsgDesignershared designershared
			{
				get
				{
					return this.designersharedField;
				}
				set
				{
					this.designersharedField = value;
				}
			}

			public MM.appmsgEmotionpageshared emotionpageshared
			{
				get
				{
					return this.emotionpagesharedField;
				}
				set
				{
					this.emotionpagesharedField = value;
				}
			}

			public MM.appmsgWebviewshared webviewshared
			{
				get
				{
					return this.webviewsharedField;
				}
				set
				{
					this.webviewsharedField = value;
				}
			}

			public object template_id
			{
				get
				{
					return this.template_idField;
				}
				set
				{
					this.template_idField = value;
				}
			}

			public object md5
			{
				get
				{
					return this.md5Field;
				}
				set
				{
					this.md5Field = value;
				}
			}

			public MM.appmsgWeappinfo weappinfo
			{
				get
				{
					return this.weappinfoField;
				}
				set
				{
					this.weappinfoField = value;
				}
			}

			public object statextstr
			{
				get
				{
					return this.statextstrField;
				}
				set
				{
					this.statextstrField = value;
				}
			}

			public object websearch
			{
				get
				{
					return this.websearchField;
				}
				set
				{
					this.websearchField = value;
				}
			}

			[XmlAttribute]
			public string appid
			{
				get
				{
					return this.appidField;
				}
				set
				{
					this.appidField = value;
				}
			}

			[XmlAttribute]
			public byte sdkver
			{
				get
				{
					return this.sdkverField;
				}
				set
				{
					this.sdkverField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgStreamvideo
		{
			private object streamvideourlField;

			private byte streamvideototaltimeField;

			private object streamvideotitleField;

			private object streamvideowordingField;

			private object streamvideoweburlField;

			private object streamvideothumburlField;

			private object streamvideoaduxinfoField;

			private object streamvideopublishidField;

			public object streamvideourl
			{
				get
				{
					return this.streamvideourlField;
				}
				set
				{
					this.streamvideourlField = value;
				}
			}

			public byte streamvideototaltime
			{
				get
				{
					return this.streamvideototaltimeField;
				}
				set
				{
					this.streamvideototaltimeField = value;
				}
			}

			public object streamvideotitle
			{
				get
				{
					return this.streamvideotitleField;
				}
				set
				{
					this.streamvideotitleField = value;
				}
			}

			public object streamvideowording
			{
				get
				{
					return this.streamvideowordingField;
				}
				set
				{
					this.streamvideowordingField = value;
				}
			}

			public object streamvideoweburl
			{
				get
				{
					return this.streamvideoweburlField;
				}
				set
				{
					this.streamvideoweburlField = value;
				}
			}

			public object streamvideothumburl
			{
				get
				{
					return this.streamvideothumburlField;
				}
				set
				{
					this.streamvideothumburlField = value;
				}
			}

			public object streamvideoaduxinfo
			{
				get
				{
					return this.streamvideoaduxinfoField;
				}
				set
				{
					this.streamvideoaduxinfoField = value;
				}
			}

			public object streamvideopublishid
			{
				get
				{
					return this.streamvideopublishidField;
				}
				set
				{
					this.streamvideopublishidField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgCanvasPageItem
		{
			private string canvasPageXmlField;

			public string canvasPageXml
			{
				get
				{
					return this.canvasPageXmlField;
				}
				set
				{
					this.canvasPageXmlField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgAppattach
		{
			private object attachidField;

			private string cdnthumburlField;

			private string cdnthumbmd5Field;

			private uint cdnthumblengthField;

			private ushort cdnthumbheightField;

			private ushort cdnthumbwidthField;

			private string cdnthumbaeskeyField;

			private string aeskeyField;

			private byte encryverField;

			private object fileextField;

			private byte islargefilemsgField;

			public object attachid
			{
				get
				{
					return this.attachidField;
				}
				set
				{
					this.attachidField = value;
				}
			}

			public string cdnthumburl
			{
				get
				{
					return this.cdnthumburlField;
				}
				set
				{
					this.cdnthumburlField = value;
				}
			}

			public string cdnthumbmd5
			{
				get
				{
					return this.cdnthumbmd5Field;
				}
				set
				{
					this.cdnthumbmd5Field = value;
				}
			}

			public uint cdnthumblength
			{
				get
				{
					return this.cdnthumblengthField;
				}
				set
				{
					this.cdnthumblengthField = value;
				}
			}

			public ushort cdnthumbheight
			{
				get
				{
					return this.cdnthumbheightField;
				}
				set
				{
					this.cdnthumbheightField = value;
				}
			}

			public ushort cdnthumbwidth
			{
				get
				{
					return this.cdnthumbwidthField;
				}
				set
				{
					this.cdnthumbwidthField = value;
				}
			}

			public string cdnthumbaeskey
			{
				get
				{
					return this.cdnthumbaeskeyField;
				}
				set
				{
					this.cdnthumbaeskeyField = value;
				}
			}

			public string aeskey
			{
				get
				{
					return this.aeskeyField;
				}
				set
				{
					this.aeskeyField = value;
				}
			}

			public byte encryver
			{
				get
				{
					return this.encryverField;
				}
				set
				{
					this.encryverField = value;
				}
			}

			public object fileext
			{
				get
				{
					return this.fileextField;
				}
				set
				{
					this.fileextField = value;
				}
			}

			public byte islargefilemsg
			{
				get
				{
					return this.islargefilemsgField;
				}
				set
				{
					this.islargefilemsgField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgEmoticongift
		{
			private byte packageflagField;

			private object packageidField;

			public byte packageflag
			{
				get
				{
					return this.packageflagField;
				}
				set
				{
					this.packageflagField = value;
				}
			}

			public object packageid
			{
				get
				{
					return this.packageidField;
				}
				set
				{
					this.packageidField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgEmoticonshared
		{
			private byte packageflagField;

			private object packageidField;

			public byte packageflag
			{
				get
				{
					return this.packageflagField;
				}
				set
				{
					this.packageflagField = value;
				}
			}

			public object packageid
			{
				get
				{
					return this.packageidField;
				}
				set
				{
					this.packageidField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgDesignershared
		{
			private byte designeruinField;

			private string designernameField;

			private string designerrediretcturlField;

			public byte designeruin
			{
				get
				{
					return this.designeruinField;
				}
				set
				{
					this.designeruinField = value;
				}
			}

			public string designername
			{
				get
				{
					return this.designernameField;
				}
				set
				{
					this.designernameField = value;
				}
			}

			public string designerrediretcturl
			{
				get
				{
					return this.designerrediretcturlField;
				}
				set
				{
					this.designerrediretcturlField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgEmotionpageshared
		{
			private byte tidField;

			private string titleField;

			private string descField;

			private string iconUrlField;

			private object secondUrlField;

			private byte pageTypeField;

			public byte tid
			{
				get
				{
					return this.tidField;
				}
				set
				{
					this.tidField = value;
				}
			}

			public string title
			{
				get
				{
					return this.titleField;
				}
				set
				{
					this.titleField = value;
				}
			}

			public string desc
			{
				get
				{
					return this.descField;
				}
				set
				{
					this.descField = value;
				}
			}

			public string iconUrl
			{
				get
				{
					return this.iconUrlField;
				}
				set
				{
					this.iconUrlField = value;
				}
			}

			public object secondUrl
			{
				get
				{
					return this.secondUrlField;
				}
				set
				{
					this.secondUrlField = value;
				}
			}

			public byte pageType
			{
				get
				{
					return this.pageTypeField;
				}
				set
				{
					this.pageTypeField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgWebviewshared
		{
			private object shareUrlOriginalField;

			private object shareUrlOpenField;

			private object jsAppIdField;

			private object publisherIdField;

			public object shareUrlOriginal
			{
				get
				{
					return this.shareUrlOriginalField;
				}
				set
				{
					this.shareUrlOriginalField = value;
				}
			}

			public object shareUrlOpen
			{
				get
				{
					return this.shareUrlOpenField;
				}
				set
				{
					this.shareUrlOpenField = value;
				}
			}

			public object jsAppId
			{
				get
				{
					return this.jsAppIdField;
				}
				set
				{
					this.jsAppIdField = value;
				}
			}

			public object publisherId
			{
				get
				{
					return this.publisherIdField;
				}
				set
				{
					this.publisherIdField = value;
				}
			}
		}

		[DesignerCategory("code"), XmlType(AnonymousType = true)]
		[Serializable]
		public class appmsgWeappinfo
		{
			private string pagepathField;

			private string usernameField;

			private string appidField;

			private byte versionField;

			private byte typeField;

			private string weappiconurlField;

			private string shareIdField;

			private byte appservicetypeField;

			public string pagepath
			{
				get
				{
					return this.pagepathField;
				}
				set
				{
					this.pagepathField = value;
				}
			}

			public string username
			{
				get
				{
					return this.usernameField;
				}
				set
				{
					this.usernameField = value;
				}
			}

			public string appid
			{
				get
				{
					return this.appidField;
				}
				set
				{
					this.appidField = value;
				}
			}

			public byte version
			{
				get
				{
					return this.versionField;
				}
				set
				{
					this.versionField = value;
				}
			}

			public byte type
			{
				get
				{
					return this.typeField;
				}
				set
				{
					this.typeField = value;
				}
			}

			public string weappiconurl
			{
				get
				{
					return this.weappiconurlField;
				}
				set
				{
					this.weappiconurlField = value;
				}
			}

			public string shareId
			{
				get
				{
					return this.shareIdField;
				}
				set
				{
					this.shareIdField = value;
				}
			}

			public byte appservicetype
			{
				get
				{
					return this.appservicetypeField;
				}
				set
				{
					this.appservicetypeField = value;
				}
			}
		}

		[ProtoContract]
		public class GetProfileRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string userName;
		}

		[ProtoContract]
		public class GetProfileResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.ModUserInfo userInfo;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.UserInfoExt userInfoExt;
		}

		[ProtoContract]
		public class UserInfoExt
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string msgPushSound;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string voipPushSound;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomSize;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomQuota;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomInvite;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string safeMobile;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint mainAcctType;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString extXml;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public MM.SafeDeviceList safeDeviceList;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint safeDevice;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public uint grayscaleFlag;
		}

		[ProtoContract]
		public class SafeDeviceList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SafeDevice[] list;
		}

		[ProtoContract]
		public class SafeDevice
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string name;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string uuid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string deviceType;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint createTime;
		}

		[ProtoContract]
		public class SnsUserInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint snsFlag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string snsBGImgID;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public ulong snsBGObjectID;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint snsFlagEx;
		}

		[ProtoContract]
		public class ModUserInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint bitFlag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint bindUin;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString bindEmail;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString bindMobile;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint status;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint imgLen;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public byte[] imgBuf;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint personalCard;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public MM.DisturbSetting disturbSetting;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public uint pluginFlag;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public uint verifyFlag;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public int point;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public int experience;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public int level;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int levelLowExp;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public int levelHighExp;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public uint pluginSwitch;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public MM.GmailList gmailList;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string alias;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public uint weiboFlag;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public uint faceBookFlag;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public ulong fBUserID;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public string fBUserName;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public int albumStyle;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public int albumFlag;

			[ProtoMember(35, Options = MemberSerializationOptions.Required)]
			public string albumBGImgID;

			[ProtoMember(36, Options = MemberSerializationOptions.Required)]
			public uint tXNewsCategory;

			[ProtoMember(37, Options = MemberSerializationOptions.Required)]
			public string fBToken;

			[ProtoMember(38, Options = MemberSerializationOptions.Required)]
			public string country;

			[ProtoMember(39, Options = MemberSerializationOptions.Required)]
			public uint grayscaleFlag;
		}

		[ProtoContract]
		public class GmailInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string gmailAcct;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint gmailSwitch;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint gmailErrCode;
		}

		[ProtoContract]
		public class GetMsgImgRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString from;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint dataLen;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint compressType;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public ulong newMsgId;
		}

		[ProtoContract]
		public class GmailList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.GmailInfo[] list;
		}

		[ProtoContract]
		public class DisturbSetting
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint nightSetting;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.DisturbTimeSpan nightTime;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint allDaySetting;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.DisturbTimeSpan alldayTime;
		}

		[ProtoContract]
		public class DisturbTimeSpan
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint beginTime;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint endTime;
		}

		[XmlRoot("msg")]
		public class CDNMSG_VIDEO
		{
			public MM.msgVideomsg videomsg
			{
				get;
				set;
			}
		}

		public class msgVideomsg
		{
			[XmlAttribute]
			public string aeskey
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnthumbaeskey
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnvideourl
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnthumburl
			{
				get;
				set;
			}

			[XmlAttribute]
			public uint length
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte playlength
			{
				get;
				set;
			}

			[XmlAttribute]
			public ushort cdnthumblength
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnthumbwidth
			{
				get;
				set;
			}

			[XmlAttribute]
			public ushort cdnthumbheight
			{
				get;
				set;
			}

			[XmlAttribute]
			public string fromusername
			{
				get;
				set;
			}

			[XmlAttribute]
			public string md5
			{
				get;
				set;
			}

			[XmlAttribute]
			public string newmd5
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte isad
			{
				get;
				set;
			}
		}

		[XmlRoot("msg")]
		public class CDNMSG
		{
			[XmlElement("img")]
			public MM.msgImg img
			{
				get;
				set;
			}
		}

		public class msgImg
		{
			[XmlAttribute]
			public string aeskey
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte encryver
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnthumbaeskey
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnthumburl
			{
				get;
				set;
			}

			[XmlAttribute]
			public ushort cdnthumblength
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnthumbheight
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnthumbwidth
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnmidheight
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnmidwidth
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnhdheight
			{
				get;
				set;
			}

			[XmlAttribute]
			public byte cdnhdwidth
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnmidimgurl
			{
				get;
				set;
			}

			[XmlAttribute]
			public uint length
			{
				get;
				set;
			}

			[XmlAttribute]
			public string cdnbigimgurl
			{
				get;
				set;
			}

			[XmlAttribute]
			public uint hdlength
			{
				get;
				set;
			}

			[XmlAttribute]
			public string md5
			{
				get;
				set;
			}
		}

		[Serializable]
		public class softtype
		{
			[XmlElement("k1")]
			public string k1;

			[XmlElement("k2")]
			public string k2;

			[XmlElement("k3")]
			public string k3;

			[XmlElement("k4")]
			public string k4;

			[XmlElement("k5")]
			public string k5;

			[XmlElement("k14")]
			public string k14;

			[XmlElement("k43")]
			public string k43;
		}

		[Serializable]
		public class media
		{
			[XmlIgnore]
			public string CDataContent
			{
				get;
				set;
			}

			[XmlElement("id")]
			public XmlNode id
			{
				get
				{
					XmlDocument xmlDocument = new XmlDocument();
					return xmlDocument.CreateCDataSection(this.CDataContent);
				}
				set
				{
					bool flag = value == null;
					if (flag)
					{
						this.CDataContent = null;
					}
					else
					{
						bool flag2 = value == null;
						if (flag2)
						{
							throw new InvalidOperationException("Node is null.");
						}
						this.CDataContent = value.Value;
					}
				}
			}

			[XmlElement("type")]
			public XmlNode type
			{
				get
				{
					XmlDocument xmlDocument = new XmlDocument();
					return xmlDocument.CreateCDataSection(this.CDataContent);
				}
				set
				{
					bool flag = value == null;
					if (flag)
					{
						this.CDataContent = null;
					}
					else
					{
						bool flag2 = value == null;
						if (flag2)
						{
							throw new InvalidOperationException("Node is null.");
						}
						this.CDataContent = value.Value;
					}
				}
			}

			[XmlElement("title")]
			public XmlNode title
			{
				get
				{
					XmlDocument xmlDocument = new XmlDocument();
					return xmlDocument.CreateCDataSection(this.CDataContent);
				}
				set
				{
					bool flag = value == null;
					if (!flag)
					{
						bool flag2 = value == null;
						if (flag2)
						{
							throw new InvalidOperationException("Node is null.");
						}
						this.CDataContent = value.Value;
					}
				}
			}
		}

		[Serializable]
		public class msgsource
		{
			[XmlIgnore]
			public string CDataContent
			{
				get;
				set;
			}

			[XmlElement("atuserlist")]
			public XmlNode[] Nodes
			{
				get
				{
					XmlDocument xmlDocument = new XmlDocument();
					return new XmlNode[]
					{
						xmlDocument.CreateCDataSection(this.CDataContent)
					};
				}
				set
				{
					bool flag = value == null;
					if (flag)
					{
						this.CDataContent = null;
					}
					else
					{
						bool flag2 = value.Length != 1;
						if (flag2)
						{
							throw new InvalidOperationException("Invalid array.");
						}
						XmlNode xmlNode = value[0];
						bool flag3 = xmlNode == null;
						if (flag3)
						{
							throw new InvalidOperationException("Node is null.");
						}
						this.CDataContent = xmlNode.Value;
					}
				}
			}
		}

		[ProtoContract]
		public class CDNAUTHINFO
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public byte[] aesKey;
		}

		[ProtoContract]
		public class UploadVideoResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint thumbStartPos;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint videoStartPos;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong newMsgId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string cdnthumbaeskey;
		}

		[ProtoContract]
		public sealed class UploadVideoRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest BaseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int thumbTotalLen;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint thumbStartPos;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ thumbData;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int videoTotalLen;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint videoStartPos;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ videoData;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint playLength;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public uint networkEnv;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint cameraType;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint funcFlag;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string msgSource;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string cDNVideoUrl;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public string aESKey;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public int encryVer;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string cDNThumbUrl;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgSize;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgHeight;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgWidth;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public string cDNThumbAESKey;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public int videoFrom;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public uint reqTime;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public string videoMd5;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string streamVideoUrl;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public uint streamVideoTotalTime;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public string streamVideoTitle;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public string streamVideoWording;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public string streamVideoWebUrl;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public string streamVideoThumbUrl;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public string streamVideoPublishId;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public string streamVideoAdUxInfo;

			[ProtoMember(35, Options = MemberSerializationOptions.Required)]
			public uint staExtStr;

			[ProtoMember(36, Options = MemberSerializationOptions.Required)]
			public uint hitMd5;

			[ProtoMember(37, Options = MemberSerializationOptions.Required)]
			public string VideoNewMd5;

			[ProtoMember(38, Options = MemberSerializationOptions.Required)]
			public ulong crc32;

			[ProtoMember(39, Options = MemberSerializationOptions.Required)]
			public uint msgForwardType;

			[ProtoMember(40, Options = MemberSerializationOptions.Required)]
			public uint Source;
		}

		[ProtoContract]
		public class UploadImageRequest_CDN
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string mediaId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int t4;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int t5;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public byte[] t6;
		}

		[ProtoContract]
		public class BaseResponse
		{
			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString errMsg;

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.RetConst ret;
		}

		[ProtoContract]
		public class BaseRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public byte[] sessionKey;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int uin;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] devicelId;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int clientVersion;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string osType;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int scene;
		}

		[ProtoContract]
		public class AddFavItemRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baserequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string clientId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int type;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int sourceType;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string sourceId;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string @object;
		}

		[ProtoContract]
		public sealed class BatchGetFavItemRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baserequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int[] favIdList;
		}

		[ProtoContract]
		public class FavObject
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint favId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int status;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string @object;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint flag;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint updateTime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int updateSeq;
		}

		[ProtoContract]
		public class BatchGetFavItemResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.FavObject[] objectList;
		}

		[ProtoContract]
		public class GetFavInfoResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public ulong usedSize;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public ulong totalSize;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint mxFavFileSize;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint mxAutoUploadSize;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint mxAutoDownloadSize;
		}

		[ProtoContract]
		public sealed class GetFavInfoRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baserequest;
		}

		[ProtoContract]
		public sealed class FavSyncRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int selector;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey keyBuf;
		}

		[ProtoContract]
		public sealed class FavSyncResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int ret;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CmdList cmdList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey key_buf;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint continueFlag;
		}

		[ProtoContract]
		public sealed class AddFavItemResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baserequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int favId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int updateSeq;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int usedSize;
		}

		[ProtoContract]
		public class UploadMsgImgResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint Msgid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString clientImgId;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString from;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString to;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint dataLen;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public ulong Newmsgid;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string Aeskey;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string Fileid;
		}

		[ProtoContract]
		public class UploadMsgImgRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest BaseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString clientImgId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString from;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint dataLen;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ data;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint msgType;

			[ProtoMember(10)]
			public string msgSource;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint compressType;

			[ProtoMember(12)]
			public uint netType;

			[ProtoMember(13)]
			public int photoFrom;

			[ProtoMember(14)]
			public uint uICreateTime;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string cDNBigImgUrl;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string cDNMidImgUrl;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public string aESKey;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public int encryVer;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public int cDNBigImgSize;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public int cDNMidImgSize;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string cDNThumbImgUrl;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgSize;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgHeight;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public int cDNThumbImgWidth;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public string cDNThumbAESKey;

			[ProtoMember(26)]
			public uint reqTime;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string md5;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public uint Crc32;

			[ProtoMember(29)]
			public uint Msgforwardtype;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public uint hitMd5;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public string appid;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public string messageAction;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public string messageExt;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public string mediaTagName;
		}

		[ProtoContract]
		public class LoginInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public byte[] aesKey;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int uin;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string guid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int clientVer;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string androidVer;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int unknown;
		}

		[ProtoContract]
		public class AesKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] key;
		}

		[ProtoContract]
		public class EcdhKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] key;
		}

		[ProtoContract]
		public class Ecdh
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int nid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.EcdhKey ecdhkey;
		}

		[ProtoContract]
		public class ManualAuthAccountRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.AesKey aes;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.Ecdh ecdh;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string password1;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string password2;
		}

		[ProtoContract]
		public class BaseAuthReqInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Wtloginreqbuff;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.WTLoginImgReqInfo Wtloginimgreqi;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.WxVerifyCodeReqInfo Wxverifycodere;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Clidbencryptke;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ cliDbencryptInfo;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint Authreqflag;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string Authticket;
		}

		[ProtoContract]
		public class WTLoginImgReqInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string Imgsid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string Imgcode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string Imgencrtptkey;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Ksid;
		}

		[ProtoContract]
		public class WxVerifyCodeReqInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string Verifysignatur;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string Verifycontent;
		}

		[ProtoContract]
		public class AutoAuthRsaReqData
		{
			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AesKey aesEncryptKey;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.EcdhKey cliPubEcdhKey;
		}

		[ProtoContract]
		public class AutoAuthKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.AesKey encryptKey;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ key;
		}

		[ProtoContract]
		public class ThrowBottleRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int bottletype;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string clientID;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ content;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int msgtype;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int startPos;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int totalLen;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint voiceLength;
		}

		[ProtoContract]
		public class AutoAuthAesReqData
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.BaseAuthReqInfo BaseAuthReqInfo;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ autoAuthKey;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string imei;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string softType;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int builtinIpseq;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string clientSeqId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string deviceName;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string deviceType;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string language;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string timeZone;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public int channel;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientCheckData;
		}

		[ProtoContract]
		public class AutoAuthRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.AutoAuthRsaReqData rsaReqData;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AutoAuthAesReqData aesReqData;
		}

		[ProtoContract]
		public class ManualAuthDeviceRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.BaseAuthReqInfo baseReqInfo;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] imei;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string softInfoXml;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int Builtinipseq;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string clientSeqID;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string Signature;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string loginDeviceName;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string deviceInfoXml;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string language;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string timeZone;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public int Channel;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public int Timestamp;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string deviceBrand;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string deviceModel;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public string osType;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public string realCountry;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string Bundleid;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string Adsource;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string Iphonever;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int Inputtype;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Clientcheckdat;
		}

		[ProtoContract]
		public class ErrMsg
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string msg;
		}

		[ProtoContract]
		public class AuthResult
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int code;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.ErrMsg err_msg;
		}

		[ProtoContract]
		public class SessionKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] key;
		}

		[ProtoContract]
		public class AuthParam
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public long uin;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.Ecdh ecdh;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SessionKey session;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ autoAuthKey;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint wtloginRspBuffFlag;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ wtloginRspBuff;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.WTLoginImgReqInfo wtloginImgRespInfo;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.WxVerifyCodeReqInfo wxVerifyCodeRespInfo;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ cliDbencryptKey;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ cliDbencryptInfo;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string authKey;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ a2Key;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public MM.ShowStyleKey showStyleKey;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string authTicket;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public int newVersion;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public int updateFlag;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public int authResultFlag;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string fsurl;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public int mmtlsControlBitFlag;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int serverTime;
		}

		[ProtoContract]
		public class ShowStyleKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint keycount;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public byte[] key;
		}

		[ProtoContract]
		public class AccountInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string wxid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int bindUin;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string bindMail;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string bindMobile;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string Alias;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int status;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public int pluginFlag;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int registerType;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string deviceInfoXml;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public int safeDevice;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string officialNamePinyin;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string officialNameZh;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public int pushMailStatus;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string fsUrl;
		}

		[ProtoContract]
		public class ManualAuthResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int unifyFlag;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.AuthParam authParam;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.AccountInfo accountInfo;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.NetworkSectResp dnsInfo;
		}

		[ProtoContract]
		public class HostList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.Host[] list;
		}

		[ProtoContract]
		public class Host
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string origin;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string substitute;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int priority;
		}

		[ProtoContract]
		public class NetworkControl
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string portList;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string timeoutList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint mimNoopInterval;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint maxNoopInterval;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int typingInterval;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int noopIntervalTime;
		}

		[ProtoContract]
		public class BuiltinIPList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint longConnectIpcount;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint shortconnectIpcount;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint seq;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.BuiltinIP[] longConnectIplist;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.BuiltinIP[] shortConnectIplist;
		}

		[ProtoContract]
		public class BuiltinIP
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint port;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string ip;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string domain;
		}

		[ProtoContract]
		public class NetworkSectResp
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.HostList newHostList;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.NetworkControl networkControl;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.BuiltinIPList builtinIplist;
		}

		[ProtoContract]
		public class FLAG
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int flag;
		}

		[ProtoContract]
		public class ChatInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString toid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string content;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int type;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public long utc;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public ulong clientMsgId;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string msgSource;
		}

		[ProtoContract]
		public class NewSendMsgRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int cnt;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.ChatInfo info;
		}

		[ProtoContract]
		public class SKBuiltinString_
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint iLen;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] buffer;

			public SKBuiltinString_()
			{
				this.iLen = 0u;
				this.buffer = null;
			}
		}

		[ProtoContract]
		public class GetReportStrategyRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string baseRdeviceModel;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string deviceBrand;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string osName;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string osVersion;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string languageVer;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int logid;
		}

		[ProtoContract]
		public class SKBuiltinString_S
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint iLen;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string buffer;
		}

		[ProtoContract]
		public class SKBuiltinString_Int
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint @int;
		}

		[ProtoContract]
		public class SKBuiltinString
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string @string;

			public SKBuiltinString()
			{
				this.@string = "";
			}
		}

		[ProtoContract]
		public class NewSendMsgRespone
		{
			[ProtoContract]
			public class BASERESPONSE
			{
				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public int ret;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public MM.SKBuiltinString errMsg;
			}

			[ProtoContract]
			public class NewMsgResponeNew
			{
				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public uint Ret;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public MM.SKBuiltinString toUsetName;

				[ProtoMember(3, Options = MemberSerializationOptions.Required)]
				public ulong MsgId;

				[ProtoMember(4, Options = MemberSerializationOptions.Required)]
				public ulong ClientMsgid;

				[ProtoMember(5, Options = MemberSerializationOptions.Required)]
				public uint Createtime;

				[ProtoMember(6, Options = MemberSerializationOptions.Required)]
				public uint servertime;

				[ProtoMember(7, Options = MemberSerializationOptions.Required)]
				public uint Type;

				[ProtoMember(8, Options = MemberSerializationOptions.Required)]
				public ulong newMsgId;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.NewSendMsgRespone.BASERESPONSE baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.NewSendMsgRespone.NewMsgResponeNew[] List;
		}

		[ProtoContract]
		public class syncMsgKey
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.Synckey msgkey;
		}

		[ProtoContract]
		public class Synckey
		{
			[ProtoContract]
			public class Synckey_
			{
				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public long synckey;

				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public int type;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int size;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.Synckey.Synckey_[] type;
		}

		[ProtoContract]
		public class NewSyncRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.FLAG continueflag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int selector;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey tagmsgkey;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int scene;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string device;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int syncmsgdigest;
		}

		public enum SyncCmdID
		{
			CmdIdAddMsg = 5,
			CmdIdCloseMicroBlog = 12,
			CmdIdDelChatContact = 7,
			CmdIdDelContact = 4,
			CmdIdDelContactMsg = 8,
			CmdIdDelMsg,
			CmdIdDelUserDomainEmail = 19,
			CmdIdFunctionSwitch = 23,
			CmdIdInviteFriendOpen = 22,
			CmdIdMax = 201,
			CmdIdModChatRoomMember = 15,
			CmdIdModChatRoomNotify = 20,
			CmdIdModChatRoomTopic = 27,
			CmdIdModContact = 2,
			CmdIdModContactDomainEmail = 17,
			CmdIdModMicroBlog = 13,
			CmdIdModMsgStatus = 6,
			CmdIdModNotifyStatus = 14,
			CmdIdModQContact = 24,
			CmdIdModTContact,
			CmdIdModUserDomainEmail = 18,
			CmdIdModUserInfo = 1,
			CmdIdOpenQQMicroBlog = 11,
			CmdIdPossibleFriend = 21,
			CmdIdPsmStat = 26,
			CmdIdQuitChatRoom = 16,
			CmdIdReport = 10,
			CmdInvalid = 0,
			MM_FAV_SYNCCMD_ADDITEM = 200,
			MM_GAME_SYNCCMD_ADDMSG,
			MM_SNS_SYNCCMD_ACTION = 46,
			MM_SNS_SYNCCMD_OBJECT = 45,
			MM_SYNCCMD_BRAND_SETTING = 47,
			MM_SYNCCMD_DELBOTTLECONTACT = 34,
			MM_SYNCCMD_DELETE_SNS_OLDGROUP = 56,
			MM_SYNCCMD_DELETEBOTTLE = 32,
			MM_SYNCCMD_KVCMD = 55,
			MM_SYNCCMD_KVSTAT = 36,
			MM_SYNCCMD_MODBOTTLECONTACT = 33,
			MM_SYNCCMD_MODCHATROOMMEMBERDISPLAYNAME = 48,
			MM_SYNCCMD_MODCHATROOMMEMBERFLAG,
			MM_SYNCCMD_MODDESCRIPTION = 54,
			MM_SYNCCMD_MODDISTURBSETTING = 31,
			MM_SYNCCMD_MODSNSBLACKLIST = 52,
			MM_SYNCCMD_MODSNSUSERINFO = 51,
			MM_SYNCCMD_MODUSERIMG = 35,
			MM_SYNCCMD_NEWDELMSG = 53,
			MM_SYNCCMD_UPDATESTAT = 30,
			MM_SYNCCMD_USERINFOEXT = 44,
			MM_SYNCCMD_WEBWXFUNCTIONSWITCH = 50,
			NN_SYNCCMD_THEMESTAT = 37
		}

		[ProtoContract]
		public class CmdItem
		{
			[ProtoContract]
			public class DATA
			{
				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public int len;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public byte[] data;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SyncCmdID cmdid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CmdItem.DATA cmdBuf;
		}

		[ProtoContract]
		public class MODUSERIMG
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint imgType;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint imgLen;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] imgBuf;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string imgMd5;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;
		}

		[ProtoContract]
		public class PatternLockInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint patternVersion;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ sign;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint lockStatus;
		}

		[ProtoContract]
		public class USERINFOEXT
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string msgPushSound;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string voipPushSound;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomSize;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomQuota;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint bigChatRoomInvite;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string safeMobile;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint mainAcctType;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString extXml;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public MM.SafeDeviceList safeDeviceList;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint safeDevice;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public uint grayscaleFlag;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string googleContactName;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public string idcardNum;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public string realName;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string regCountry;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string bbppid;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string bbpin;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public string bbmnickName;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public MM.LinkedinContactItem linkedinContackItem;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public string kfinfo;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public MM.PatternLockInfo patternLockInfo;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public string securityDeviceId;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public uint payWalletType;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public string weiDianInfo;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public uint walletRegion;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public ulong extStatus;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public string f2FpushSound;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public int userStatus;
		}

		[ProtoContract]
		public class _NEWMSG
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong serverid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString wxid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nick;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public ulong t4;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public byte[] t5;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public byte[] t6;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public ulong t7;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong t8;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public ulong t9;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string t13;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public ulong t14;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public byte[] t15;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public ulong t16;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public ulong t17;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public ulong t19;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public ulong t20;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public ulong t21;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public ulong t22;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public ulong t23;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public ulong t25;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public byte[] t26;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string Alias;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public ulong t29;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public ulong t30;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public ulong t31;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public ulong t33;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public ulong t34;

			[ProtoMember(36, Options = MemberSerializationOptions.Required)]
			public ulong t36;

			[ProtoMember(38, Options = MemberSerializationOptions.Required)]
			public byte[] t38;
		}

		[ProtoContract]
		public class AddMsg
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong msgid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString from;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString to;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int type;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString content;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int status;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int imgStatus;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ img;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public ulong createtime;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string msgSource;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string pushcontent;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public ulong newMsgId;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint msgSeq;
		}

		[ProtoContract]
		public class CmdList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CmdItem[] list;
		}

		[ProtoContract]
		public sealed class GetEmotionDescRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string productID;
		}

		[ProtoContract]
		public class SendEmojiResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int emojiItemCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] tag3;
		}

		[ProtoContract]
		public class AppMsg
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string appId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint sdkVersion;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string content;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString thumb;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int source;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int remindId;

			[ProtoMember(12)]
			public string msgSource;

			[ProtoMember(13)]
			public string shareUrlOriginal;

			[ProtoMember(14)]
			public string shareUrlOpen;

			[ProtoMember(15)]
			public string jsAppId;
		}

		[ProtoContract]
		public class SendAppMsgResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string appId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public ulong t9;
		}

		[ProtoContract]
		public class SendAppMsgRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AppMsg msg;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string commentUrl;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int reqTime;

			[ProtoMember(5)]
			public string md5;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int fileType;

			[ProtoMember(7)]
			public string signature;

			[ProtoMember(8)]
			public string fromSence;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint hitMd5;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public long crc;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public ulong msgForwardType;
		}

		[ProtoContract]
		public class UploadVoiceRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int offset;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int length;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int msgId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int voiceLen;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ data;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public int endFlag;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int cancelFlag;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string msgsource;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public MM.VoiceFormat voiceFormat;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public int uicreateTime;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public int forwardFlag;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public ulong newMsgId;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public int reqTime;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ voiceId;
		}

		[ProtoContract]
		public class UploadVoiceResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string fromUserName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string toUserName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint offset;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint length;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint voiceLength;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint endFlag;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint cancelFlag;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public ulong newMsgId;
		}

		public enum VoiceFormat
		{
			MM_VOICE_FORMAT_AMR,
			MM_VOICE_FORMAT_MP3 = 2,
			MM_VOICE_FORMAT_SILK = 4,
			MM_VOICE_FORMAT_SPEEX = 1,
			MM_VOICE_FORMAT_UNKNOWN = -1,
			MM_VOICE_FORMAT_WAVE = 3
		}

		[ProtoContract]
		public class EmojiUploadInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string MD5;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int startPos;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int totalLen;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ emojiBuffer;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int type;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string externXml;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string report;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string msgSource;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int t11;
		}

		[ProtoContract]
		public class UploadEmojiRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int emojiItemCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.EmojiUploadInfo emojiItem;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int tag4;
		}

		[ProtoContract]
		public sealed class EmotionDesc
		{
			[ProtoContract]
			public sealed class LangDesc
			{
				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public string lang;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public string desc;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string md5;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.EmotionDesc.LangDesc[] list;
		}

		[ProtoContract]
		public sealed class GetEmotionDescResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.EmotionDesc[] list;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint clickFlag;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string buttonDesc;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint downLoadFlag;
		}

		[ProtoContract]
		public class NewSyncResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int ret;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CmdList cmdList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int Continueflag;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public byte[] sync_key;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint Status;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint Onlineversion;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint Svrtime;
		}

		[ProtoContract]
		public class RoomInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;
		}

		[ProtoContract]
		public class CustomizedInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint brandFlag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string externalInfo;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string brandInfo;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string brandIconURL;
		}

		[ProtoContract]
		public class ChatRoomMemberInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string displayName;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint chatroomMemberFlag;
		}

		[ProtoContract]
		public class ChatRoomMemberData
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.ChatRoomMemberInfo[] chatRoomMember;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint infoMask;
		}

		[ProtoContract]
		public class LinkedinContactItem
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string linkedinName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string linkedinMemberID;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string linkedinPublicUrl;
		}

		[ProtoContract]
		public class AdditionalContactList
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.LinkedinContactItem linkedinContactItem;
		}

		[ProtoContract]
		public class PhoneNumListInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint Count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint[] phoneNumList;
		}

		[ProtoContract]
		public class DelChatContact
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString UserName;
		}

		[ProtoContract]
		public class CloseMicroBlog
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString microBlogUserName;
		}

		[ProtoContract]
		public class ModContact
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString pyInitial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint bitMask;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint bitVal;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint imgFlag;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remark;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remarkPYInitial;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remarkQuanPin;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint contactType;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint roomInfoCount;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public MM.RoomInfo[] RoomInfoList;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] domainList_;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public uint chatRoomNotify;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public uint addContactScene;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public uint personalCard;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public uint hasWeiXinHdHeadImg;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public uint verifyFlag;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public int level;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public string alias;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public string chatRoomOwner;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public uint weiboFlag;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public int albumStyle;

			[ProtoMember(35, Options = MemberSerializationOptions.Required)]
			public int albumFlag;

			[ProtoMember(36, Options = MemberSerializationOptions.Required)]
			public string albumBGImgID;

			[ProtoMember(37, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(38, Options = MemberSerializationOptions.Required)]
			public string country;

			[ProtoMember(39, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(40, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(41, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(42, Options = MemberSerializationOptions.Required)]
			public MM.CustomizedInfo customizedInfo;

			[ProtoMember(43, Options = MemberSerializationOptions.Required)]
			public string chatRoomData;

			[ProtoMember(44, Options = MemberSerializationOptions.Required)]
			public string headImgMd5;

			[ProtoMember(45, Options = MemberSerializationOptions.Required)]
			public string encryptUserName;

			[ProtoMember(46, Options = MemberSerializationOptions.Required)]
			public string iDCardNum;

			[ProtoMember(47, Options = MemberSerializationOptions.Required)]
			public string realName;

			[ProtoMember(48, Options = MemberSerializationOptions.Required)]
			public string mobileHash;

			[ProtoMember(49, Options = MemberSerializationOptions.Required)]
			public string mobileFullHash;

			[ProtoMember(50, Options = MemberSerializationOptions.Required)]
			public MM.AdditionalContactList additionalContactList;

			[ProtoMember(53, Options = MemberSerializationOptions.Required)]
			public uint chatroomVersion;

			[ProtoMember(54, Options = MemberSerializationOptions.Required)]
			public string extInfo;

			[ProtoMember(55, Options = MemberSerializationOptions.Required)]
			public uint chatroomMaxCount;

			[ProtoMember(56, Options = MemberSerializationOptions.Required)]
			public uint chatroomType;

			[ProtoMember(57, Options = MemberSerializationOptions.Required)]
			public MM.ChatRoomMemberData newChatroomData;

			[ProtoMember(58, Options = MemberSerializationOptions.Required)]
			public int deleteFlag;

			[ProtoMember(59, Options = MemberSerializationOptions.Required)]
			public string description;

			[ProtoMember(60, Options = MemberSerializationOptions.Required)]
			public string cardImgUrl;

			[ProtoMember(61, Options = MemberSerializationOptions.Required)]
			public string labelIDList;

			[ProtoMember(62, Options = MemberSerializationOptions.Required)]
			public MM.PhoneNumListInfo Phonenumlistinfo;

			[ProtoMember(63, Options = MemberSerializationOptions.Required)]
			public string Weidianinfo;

			[ProtoMember(64, Options = MemberSerializationOptions.Required)]
			public int ChatroomInfoVersion;

			[ProtoMember(65, Options = MemberSerializationOptions.Required)]
			public int DeletecontactScene;

			[ProtoMember(66, Options = MemberSerializationOptions.Required)]
			public int ChatroomstatuStatus;

			[ProtoMember(67, Options = MemberSerializationOptions.Required)]
			public int Extflag;
		}

		[ProtoContract]
		public class ModChatRoomMember
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString pyInitial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint imgFlag;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remark;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remarkPYInitial;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString remarkQuanPin;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint contactType;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public int personalCard;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public int verifyFlag;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public int weiboFlag;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public int albumStyle;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public int albumFlag;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public string albumBgimgId;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public string alias;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string country;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public string smallheadImgUrl;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public MM.CustomizedInfo customizedInfo;
		}

		[ProtoContract]
		public class GetContactResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint contactCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.ModContact[] contactList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int[] ret;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.VerifyUserValidTicket[] ticket;
		}

		[ProtoContract]
		public class VerifyUserValidTicket
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string antispamticket;
		}

		[ProtoContract]
		public class GetContactRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint userCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] userNameList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint antispamTicketCount;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] antispamTicket;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint fromChatRoomCount;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString fromChatRoom;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint getContactScene;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ chatRoomAccessVerifyTicket;
		}

		[ProtoContract]
		public class MMSnsUserPageRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string t2;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string wxid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint t4;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint t5;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong t6;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public ulong createtime;
		}

		[ProtoContract]
		public class GetCDNDnsRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string clientIP;
		}

		[ProtoContract]
		public class GetCDNDnsResponse
		{
			[ProtoContract]
			public class tag7
			{
				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public uint t1;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public ulong t2;

				[ProtoMember(3, Options = MemberSerializationOptions.Required)]
				public uint t3;

				[ProtoMember(4, Options = MemberSerializationOptions.Required)]
				public uint t4;

				[ProtoMember(5, Options = MemberSerializationOptions.Required)]
				public uint t5;

				[ProtoMember(6, Options = MemberSerializationOptions.Required)]
				public uint t6;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsInfo dnsinfo;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsInfo snsDnsInfo;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsInfo appDnsInfo;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public byte[] cdndnsRuleBuf;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public byte[] fakeCdndnsRulebuf;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsInfo fakeDnsInfo;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int getCdnDnsIntervalMs;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.CDNClientConfig defaultConfig;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.CDNClientConfig disasterConfig;
		}

		[ProtoContract]
		public class CDNClientConfig
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int c2CshowErrorDelayMs;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int snsshowErrorDelayMs;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int c2CretryInterval;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int snsretryInterval;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int c2Crwtimeout;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int snsrwtimeout;
		}

		[ProtoContract]
		public class CDNDnsInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint ver;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint uin;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint expireTime;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public int frontID;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int frontIPCount;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] fontIPList;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string zoneDomain;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ authKey;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public int zoneID;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int zoneIPCount;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] zoneIPList;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsPortInfo[] frontIPPortList;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public MM.CDNDnsPortInfo[] zoneIPPortList;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public int frontIPPortCount;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public int zoneIPPortCount;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public uint fakeUin;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ newAuthkey;
		}

		[ProtoContract]
		public class CDNDnsPortInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint portCount;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint[] portList;
		}

		[ProtoContract]
		public class GetLoginQRCodeRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AesKey aes;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint opcode;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string deviceName;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint extDevLoginType;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string hadrwareExtra;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string softType;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.RSAPem rsa;
		}

		[ProtoContract]
		public class RSAPem
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string pem;
		}

		[ProtoContract]
		public class GetLoginQRCodeResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.QRCode qRCode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string uuid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint checkTime;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.AesKey AESKey;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint expiredTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string blueToothBroadCastUuid;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ blueToothBroadCastContent;
		}

		[ProtoContract]
		public class QRCode
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint len;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] src;
		}

		[ProtoContract]
		public class CheckLoginQRCodeRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AesKey aes;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string uuid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint timeStamp;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint opcode;
		}

		[ProtoContract]
		public class LoginQRCodeNotify
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string uuid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int state;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string wxid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string wxnewpass;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string headImgUrl;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int pushLoginUrlexpiredTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int EffectiveTime;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int t10;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string device;
		}

		[ProtoContract]
		public class LoginQRCodeNotifyPkg
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ notifyData;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opcode;
		}

		[ProtoContract]
		public class CheckLoginQRCodeResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.LoginQRCodeNotifyPkg data;
		}

		[ProtoContract]
		public class GetMsgImgResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString from;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString to;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint dataLen;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ data;
		}

		[ProtoContract]
		public class GetOpenIMResourceRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string Language;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string Appid;

			[ProtoMember(3)]
			public uint Wordingid;
		}

		[ProtoContract]
		public class GetOpenIMResourceResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AppIdResource appidResource;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.AcctTypeResource acctTypeResource;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint wordingIdResource;
		}

		[ProtoContract]
		public class AppIdResource
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint Functionflag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] Wordings;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] Urls;
		}

		[ProtoContract]
		public class AcctTypeResource
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string Accttypeid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] aWordings;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] Urls;
		}

		[ProtoContract]
		public class GetConnectInfoRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string Url;
		}

		[ProtoContract]
		public class GetConnectInfoResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string Id;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.AesKey Key;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string Hello;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string Ok;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint Type;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint Addrcount;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public byte[] AddrList;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string Resource;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string Pcname;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string Pcacctname;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public uint EncryFlag;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint Scene;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public ulong Datasize;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string Wifiname;
		}

		[ProtoContract]
		public class GetChatroomMemberDetailRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string chatroomUserName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint clientVersion;
		}

		[ProtoContract]
		public class GetChatroomMemberDetailResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string chatroomUserName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint clientVersion;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.ChatRoomMemberData newChatroomData;
		}

		[ProtoContract]
		public class ReportKvRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint Genstgver;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint Specstgver;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint Uinstgver;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public byte[] datapkg;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public byte[] encryptkey;
		}

		[ProtoContract]
		public class DownloadVoiceRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint offset;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint length;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string clientMsgId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong Newmsgid;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string Chatroomname;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong MasterbufId;
		}

		[ProtoContract]
		public class DownloadVoiceResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint msgId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint offset;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint length;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint Voicelength;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string Clientmsgid;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Data;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint Endflag;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint Cancelflag;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public ulong Newmsgid;
		}

		[ProtoContract]
		public class HeartBeatRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public long Timestamp;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey Keybuf;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ blueToothBroadCastContent;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint scene;
		}

		[ProtoContract]
		public class HeartBeatResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint Nexttime;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint Selector;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Bluetoothbroad;
		}

		[ProtoContract]
		public class GetOnlineInfoRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string language;
		}

		[ProtoContract]
		public class GetOnlineInfoResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint onlineCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.OnlineInfo[] onlineList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string summaryXML;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint flag;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint iConType;
		}

		[ProtoContract]
		public class OnlineInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint deviceType;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string deviceID;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string wordingXML;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientKey;
		}

		[ProtoContract]
		public class PushLoginURLRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string Autoauthticket;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string ClientId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.AesKey randomEncryKey;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint opcode;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string Devicename;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ Autoauthkey;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.RSAPem rsa;
		}

		[ProtoContract]
		public class AccountStorage
		{
			[ProtoContract]
			public class LocalInfo
			{
				[ProtoContract]
				public class T1
				{
					[ProtoMember(1, Options = MemberSerializationOptions.Required)]
					public uint len;

					[ProtoMember(2, Options = MemberSerializationOptions.Required)]
					public byte[] data;

					[ProtoMember(3, Options = MemberSerializationOptions.Required)]
					public uint createtime;
				}

				[ProtoMember(1, Options = MemberSerializationOptions.Required)]
				public uint len;

				[ProtoMember(2, Options = MemberSerializationOptions.Required)]
				public MM.AccountStorage.LocalInfo.T1 data;
			}

			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.AesKey Key;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.AccountStorage.LocalInfo local;
		}

		[ProtoContract]
		public class PushLoginURLResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string uuid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.AesKey Notifykey;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint Checktime;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint Expiredtime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string blueToothBroadCastUuid;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ blueToothBroadCastContent;
		}

		public enum VerifyUserOpCode
		{
			MM_VERIFYUSER_ADDCONTACT = 1,
			MM_VERIFYUSER_RECVERREPLY = 6,
			MM_VERIFYUSER_SENDERREPLY = 5,
			MM_VERIFYUSER_SENDREQUEST = 2,
			MM_VERIFYUSER_VERIFYOK,
			MM_VERIFYUSER_VERIFYREJECT
		}

		public enum AddContactScene
		{
			MM_ADDSCENE_APPMSG = 57,
			MM_ADDSCENE_BBM = 50,
			MM_ADDSCENE_BIZ_CONFERENCE = 40,
			MM_ADDSCENE_BIZ_PAY = 51,
			MM_ADDSCENE_BOTTLE = 25,
			MM_ADDSCENE_BRAND_QA = 34,
			MM_ADDSCENE_CHATROOM = 14,
			MM_ADDSCENE_CORP_EMAIL = 16,
			MM_ADDSCENE_FACEBOOK = 31,
			MM_ADDSCENE_FUZZY_SEARCH = 35,
			MM_ADDSCENE_INTERESTED_BRAND = 56,
			MM_ADDSCENE_LBS = 18,
			MM_ADDSCENE_LBSROOM = 44,
			MM_ADDSCENE_LOGO_WALL = 36,
			MM_ADDSCENE_PF_CONTACT = 6,
			MM_ADDSCENE_PF_EMAIL = 5,
			MM_ADDSCENE_PF_GROUP = 8,
			MM_ADDSCENE_PF_MOBILE = 10,
			MM_ADDSCENE_PF_MOBILE_EMAIL,
			MM_ADDSCENE_PF_MOBILE_REVERSE = 21,
			MM_ADDSCENE_PF_QQ = 4,
			MM_ADDSCENE_PF_SHAKE_PHONE_GROUP = 23,
			MM_ADDSCENE_PF_SHAKE_PHONE_OPPSEX,
			MM_ADDSCENE_PF_SHAKE_PHONE_PAIR = 22,
			MM_ADDSCENE_PF_UNKNOWN = 9,
			MM_ADDSCENE_PF_WEIXIN = 7,
			MM_ADDSCENE_PROMOTE_BIZCARD = 41,
			MM_ADDSCENE_PROMOTE_MSG = 38,
			MM_ADDSCENE_QRCode = 30,
			MM_ADDSCENE_RADARSEARCH = 48,
			MM_ADDSCENE_RECOMMEND_BRAND = 55,
			MM_ADDSCENE_REG_ADD_MFRIEND = 52,
			MM_ADDSCENE_SCANBARCODE = 49,
			MM_ADDSCENE_SCANIMAGE = 45,
			MM_ADDSCENE_SCANIMAGE_BOOK = 47,
			MM_ADDSCENE_SEARCH_BRAND = 39,
			MM_ADDSCENE_SEARCH_BRAND_SERICE = 53,
			MM_ADDSCENE_SEARCH_BRAND_SUBSCR,
			MM_ADDSCENE_SEARCH_EMAIL = 2,
			MM_ADDSCENE_SEARCH_PHONE = 15,
			MM_ADDSCENE_SEARCH_QQ = 1,
			MM_ADDSCENE_SEARCH_WEIXIN = 3,
			MM_ADDSCENE_SEND_CARD = 17,
			MM_ADDSCENE_SHAKE_SCENE1 = 26,
			MM_ADDSCENE_SHAKE_SCENE2,
			MM_ADDSCENE_SHAKE_SCENE3,
			MM_ADDSCENE_SHAKE_SCENE4,
			MM_ADDSCENE_SHAKETV = 46,
			MM_ADDSCENE_SNS = 32,
			MM_ADDSCENE_TIMELINE_BIZ = 37,
			MM_ADDSCENE_UNKNOW = 0,
			MM_ADDSCENE_VIEW_MOBILE = 13,
			MM_ADDSCENE_VIEW_QQ = 12,
			MM_ADDSCENE_WEB = 33,
			MM_ADDSCENE_WEB_OP_MENU = 43,
			MM_ADDSCENE_WEB_PROFILE_URL = 42
		}

		[ProtoContract]
		public class TenPayRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.enMMTenPayCgiCmd cgiCmd;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint outPutType;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S reqText;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S reqTextWx;
		}

		[ProtoContract]
		public class TenPayResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S reqText;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int platRet;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string platMsg;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.enMMTenPayCgiCmd cgiCmdid;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int tenpayErrType;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string tenpayErrMsg;
		}

		[ProtoContract]
		public class GetPayFunctionListRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string telephonyNetIso;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint ticketCount;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public byte[] ticketList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string exInfo;
		}

		[ProtoContract]
		public class GetPayFunctionListResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string payFunctionList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint notShowTutorial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint cacheTime;
		}

		[ProtoContract]
		public class F2FQrcodeRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;
		}

		[ProtoContract]
		public class F2FQrcodeResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string url;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] upperRightItems;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.MenuItem bottomItem;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string trueName;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string bottomleftIconUrl;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public bool bottomRightArrowFlag;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint busiType;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string upperWording;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string mchName;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string mchPhoto;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public uint guideMaterialFlag;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public MM.MiniProgramInfo buyMaterialInfo;
		}

		[ProtoContract]
		public class MenuItem
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string wording;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string url;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string waappUsername;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string waappPath;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string subwording;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint isShowRed;
		}

		[ProtoContract]
		public class MiniProgramInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string pagePath;
		}

		[ProtoContract]
		public class VerifyUser
		{
			[ProtoMember(1)]
			public string value;

			[ProtoMember(2)]
			public string verifyUserTicket;

			[ProtoMember(3)]
			public string antispamTicket;

			[ProtoMember(4)]
			public uint friendFlag;

			[ProtoMember(5)]
			public string chatRoomUserName;

			[ProtoMember(6)]
			public string sourceUserName;

			[ProtoMember(7)]
			public string sourceNickName;

			[ProtoMember(8)]
			public uint scanQrcodeFromScene;

			[ProtoMember(9)]
			public string reportInfo;
		}

		[ProtoContract]
		public class VerifyUserRequest1
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.VerifyUserOpCode opcode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint verifyUserListSize;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.VerifyUser[] verifyUserList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint SceneListNumFieldNumber;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public byte[] sceneList;

			[ProtoMember(8)]
			public int verifyInfoListCount;

			[ProtoMember(9)]
			public byte[] verifyInfoList;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientCheckData;
		}

		[ProtoContract]
		public class VerifyUserRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.VerifyUserOpCode opcode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint verifyUserListSize;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.VerifyUser[] verifyUserList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint sceneListCount;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_[] sceneList;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint verifyInfoListCount;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_[] verifyInfoList;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientCheckData;
		}

		[ProtoContract]
		public class VerifyUserResponese
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string userName;
		}

		[ProtoContract]
		public class CreateChatRoomRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString topic;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.MemberReq[] memberList;

			[ProtoMember(5)]
			public uint scene;

			[ProtoMember(6)]
			public MM.SKBuiltinString_ extBuffer;
		}

		[ProtoContract]
		public class MemberReq
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString member;
		}

		[ProtoContract]
		public class CreateChatRoomResponese
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString topic;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString pYInitial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(5)]
			public uint memberCount;

			[ProtoMember(6)]
			public MM.MemberResp[] memberList;

			[ProtoMember(7)]
			public MM.SKBuiltinString chatRoomName;

			[ProtoMember(8)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(9)]
			public string bigHeadImgUrl;

			[ProtoMember(10)]
			public string smallHeadImgUrl;
		}

		[ProtoContract]
		public class MemberResp
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString member;

			[ProtoMember(2)]
			public uint memberStatus;

			[ProtoMember(3)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(4)]
			public MM.SKBuiltinString pYInitial;

			[ProtoMember(5)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(6)]
			public int sex;

			[ProtoMember(9)]
			public MM.SKBuiltinString remark;

			[ProtoMember(10)]
			public MM.SKBuiltinString remarkPYInitial;

			[ProtoMember(11)]
			public MM.SKBuiltinString remarkQuanPin;

			[ProtoMember(12)]
			public uint contactType;

			[ProtoMember(13)]
			public string province;

			[ProtoMember(14)]
			public string City;

			[ProtoMember(15)]
			public string signature;

			[ProtoMember(16)]
			public uint personalCard;

			[ProtoMember(17)]
			public uint verifyFlag;

			[ProtoMember(18)]
			public string verifyInfo;

			[ProtoMember(19)]
			public string country;
		}

		[ProtoContract]
		public class StatusNotifyRequest
		{
			[ProtoMember(1)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint code;

			[ProtoMember(3)]
			public string fromUserName_;

			[ProtoMember(4)]
			public string toUserName_;

			[ProtoMember(5)]
			public string clientMsgId;

			[ProtoMember(6)]
			public uint unreadChatListCount;

			[ProtoMember(7)]
			public byte[] unreadChatList;

			[ProtoMember(8)]
			public byte[] function;

			[ProtoMember(9)]
			public uint unreadFunctionCount;

			[ProtoMember(10)]
			public byte[] unreadFunction;
		}

		[ProtoContract]
		public class StatusNotifyResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint msgid;
		}

		[ProtoContract]
		public class BatchGetHeadImgRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] userNameList;
		}

		[ProtoContract]
		public class BatchGetHeadImgResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.ImgPair[] imgPairList;
		}

		[ProtoContract]
		public class ImgPair
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString username;
		}

		[ProtoContract]
		public class GetChatRoomInfoDetailRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string chatRoomName;
		}

		[ProtoContract]
		public class GetChatRoomInfoDetailResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string announcement;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint chatRoomInfoVersion;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string announcementEditor;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint announcementPublishTime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint chatRoomStatus;
		}

		[ProtoContract]
		public class AddChatRoomMemberRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.MemberReq[] memberList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString chatRoomName;
		}

		[ProtoContract]
		public class AddChatRoomMemberResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.MemberResp[] memberList;
		}

		[ProtoContract]
		public class DelChatRoomMemberRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.DelMemberReq[] memberList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string chatRoomName;
		}

		[ProtoContract]
		public class DelMemberReq
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString memberName;
		}

		[ProtoContract]
		public class DelChatRoomMemberResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint memberCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.DelMemberResp memberList;
		}

		[ProtoContract]
		public class DelMemberResp
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString memberName;
		}

		[ProtoContract]
		public class OpLogRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.CmdList cmd;
		}

		[ProtoContract]
		public class OpLogRet
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] ret;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] errMsg;
		}

		[ProtoContract]
		public class OpLogResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int ret;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.OpLogRet oplogRet;
		}

		[ProtoContract]
		public class OpLog
		{
			[ProtoMember(1)]
			public uint cmdid;

			[ProtoMember(2)]
			public MM.SKBuiltinString_ buffer;
		}

		[ProtoContract]
		public class GetA8KeyRequest
		{
			[ProtoMember(1)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2)]
			public uint opCode;

			[ProtoMember(3)]
			public MM.SKBuiltinString_ a2key;

			[ProtoMember(4)]
			public MM.SKBuiltinString appID;

			[ProtoMember(5)]
			public MM.SKBuiltinString scope;

			[ProtoMember(6)]
			public MM.SKBuiltinString state;

			[ProtoMember(7)]
			public MM.SKBuiltinString reqUrl;

			[ProtoMember(8)]
			public string friendUserName;

			[ProtoMember(9)]
			public uint friendQQ;

			[ProtoMember(10)]
			public uint scene;

			[ProtoMember(11)]
			public string userName;

			[ProtoMember(12)]
			public string bundleID;

			[ProtoMember(13)]
			public MM.SKBuiltinString_ a2KeyNew;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint reason;

			[ProtoMember(15)]
			public uint fontScale;

			[ProtoMember(16)]
			public uint flag;

			[ProtoMember(17)]
			public string netType;

			[ProtoMember(18)]
			public uint codeType;

			[ProtoMember(19)]
			public uint codeVersion;

			[ProtoMember(20)]
			public ulong requestId;

			[ProtoMember(21)]
			public string functionId;

			[ProtoMember(22)]
			public uint walletRegion;

			[ProtoMember(23)]
			public MM.SKBuiltinString_ cookie;
		}

		[ProtoContract]
		public class JSAPIPermissionBitSet
		{
			[ProtoMember(1)]
			public uint Bitvalue1;

			[ProtoMember(2)]
			public uint Bitvalue2;

			[ProtoMember(3)]
			public uint Bitvalue3;

			[ProtoMember(4)]
			public uint Bitvalue4;
		}

		[ProtoContract]
		public class GeneralControlBitSet
		{
			[ProtoMember(1)]
			public uint Bitvalue;
		}

		[ProtoContract]
		public class BizApiInfo
		{
			[ProtoMember(1)]
			public string apiName;
		}

		[ProtoContract]
		public class BizScopeInfo
		{
			[ProtoMember(1)]
			public string scope;

			[ProtoMember(2)]
			public uint scopeStatus;

			[ProtoMember(3)]
			public string scopeDesc;

			[ProtoMember(4)]
			public uint apiCount;

			[ProtoMember(5)]
			public MM.BizApiInfo[] apiList;
		}

		[ProtoContract]
		public class DeepLinkBitSet
		{
			[ProtoMember(1)]
			public ulong bitValue;
		}

		public enum enMMScanQrcodeActionCode
		{
			MMSCAN_QRCODE_A8KEY,
			MMSCAN_QRCODE_APP = 3,
			MMSCAN_QRCODE_EMOTICON = 20,
			MMSCAN_QRCODE_JUMP = 9,
			MMSCAN_QRCODE_MMPAY,
			MMSCAN_QRCODE_MMPAY_NATIVE,
			MMSCAN_QRCODE_PLUGIN = 5,
			MMSCAN_QRCODE_PROFILE = 4,
			MMSCAN_QRCODE_SPECIAL_WEBVIEW = 6,
			MMSCAN_QRCODE_TEXT = 1,
			MMSCAN_QRCODE_VCARD = 8,
			MMSCAN_QRCODE_WEBVIEW = 2,
			MMSCAN_QRCODE_WEBVIEW_NO_NOTICE = 7
		}

		[ProtoContract]
		public class GetA8KeyResponse
		{
			[ProtoMember(1)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2)]
			public string fullURL;

			[ProtoMember(3)]
			public string a8key;

			[ProtoMember(4)]
			public MM.enMMScanQrcodeActionCode actionCode;

			[ProtoMember(5)]
			public string title;

			[ProtoMember(6)]
			public string content;

			[ProtoMember(7)]
			public MM.JSAPIPermissionBitSet jSAPIPermission;

			[ProtoMember(8)]
			public MM.GeneralControlBitSet generalControlBitSet;

			[ProtoMember(9)]
			public string userName;

			[ProtoMember(15)]
			public string shareURL;

			[ProtoMember(16)]
			public uint scopeCount;

			[ProtoMember(17)]
			public MM.BizScopeInfo[] ScopeList;

			[ProtoMember(18)]
			public string antispamTicket;

			[ProtoMember(20)]
			public string ssid;

			[ProtoMember(21)]
			public string mID;

			[ProtoMember(22)]
			public MM.DeepLinkBitSet deepLinkBitSet;

			[ProtoMember(23)]
			public MM.SKBuiltinString_ jSAPIControlBytes;

			[ProtoMember(24)]
			public uint httpHeaderCount;

			[ProtoMember(25)]
			public MM.SKBuiltinString_ httpHeader;

			[ProtoMember(26)]
			public string wording;

			[ProtoMember(27)]
			public string headimg;

			[ProtoMember(28)]
			public MM.SKBuiltinString_ cookie;

			[ProtoMember(29)]
			public string menuWording;
		}

		[ProtoContract]
		public class ModMsgStatus
		{
			[ProtoMember(1)]
			public int msgId;

			[ProtoMember(2)]
			public MM.SKBuiltinString fromUserName;

			[ProtoMember(3)]
			public MM.SKBuiltinString toUserName;

			[ProtoMember(4)]
			public uint status;
		}

		[ProtoContract]
		public class ModChatRoomTopic
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString chatRoomName;

			[ProtoMember(2)]
			public MM.SKBuiltinString chatRoomTopic;
		}

		[ProtoContract]
		public class DelContact
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2)]
			public uint deleteContactScene;
		}

		[ProtoContract]
		public class DelMsg
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2)]
			public uint count;

			[ProtoMember(3)]
			public int[] msgIdList;
		}

		[ProtoContract]
		public class InviteFriendOpen
		{
			[ProtoMember(1)]
			public string userName;

			[ProtoMember(2)]
			public uint friendType;
		}

		[ProtoContract]
		public class FunctionSwitch
		{
			[ProtoMember(1)]
			public uint functionId;

			[ProtoMember(2)]
			public int switchValue;
		}

		[ProtoContract]
		public class DelUserDomainEmail
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2)]
			public MM.SKBuiltinString email;
		}

		[ProtoContract]
		public class TContact
		{
			[ProtoMember(1)]
			public string userName;

			[ProtoMember(2)]
			public string displayName;

			[ProtoMember(3)]
			public uint extInfoSeq;

			[ProtoMember(4)]
			public uint imgUpdateSeq;
		}

		[ProtoContract]
		public class ModUserDomainEmail
		{
			[ProtoMember(1)]
			public uint status;

			[ProtoMember(2)]
			public MM.SKBuiltinString email;
		}

		[ProtoContract]
		public class OpenQQMicroBlog
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString microBlogUserName;
		}

		[ProtoContract]
		public class QContact
		{
			[ProtoMember(1)]
			public string userName;

			[ProtoMember(2)]
			public string displayName;

			[ProtoMember(3)]
			public uint extInfoSeq;

			[ProtoMember(4)]
			public uint imgUpdateSeq;
		}

		[ProtoContract]
		public class ModNotifyStatus
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2)]
			public uint status;
		}

		[ProtoContract]
		public class DelContactMsg
		{
			[ProtoMember(1)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2)]
			public int maxMsgId;
		}

		[ProtoContract]
		public sealed class SnsAction
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string from;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string to;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string fromnickname;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string tonickname;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SnsObjectType type;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint createtime;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string content;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public int replyCommentId;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int commentId;
		}

		[ProtoContract]
		public sealed class SnsActionGroup
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong id;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public ulong parentId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SnsAction currentAction;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SnsAction referAction;
		}

		[ProtoContract]
		public sealed class SnsCommentRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsActionGroup action;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string clientid;
		}

		[ProtoContract]
		public sealed class SnsCommentResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsObject snsObject;
		}

		[ProtoContract]
		public sealed class SnsObject : IComparable
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong id;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string nickname;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S objectDesc;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint likeFlag;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint likeCount;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint likeUserListNum;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SnsCommentInfo[] likeUserList;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint commentCount;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint commentUserListCount;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SnsCommentInfo[] commentUserList;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint withUserCount;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint withUserListNum;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public MM.SnsCommentInfo[] withUserList;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public uint extFlag;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public uint noChange;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public uint groupCount;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public MM.SnsGroup[] groupList;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public uint isNotRichText;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string referUsername;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public ulong referId;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public uint blackListCount;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_[] blackList;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public uint deleteFlag;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public uint groupUserCount;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_[] groupUser;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ objectOperations;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public MM.SnsRedEnvelops snsRedEnvelops;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public MM.PreDownloadInfo preDownloadInfo;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public MM.SnsWeAppInfo weAppInfo;

			int IComparable.CompareTo(object obj)
			{
				return ((MM.SnsObject)obj).id.CompareTo(this.id);
			}
		}

		[ProtoContract]
		public class PossibleFriend
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string pYInitial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string quanPin;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint imgFlag;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint contactType;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string domainList;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string source;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint friendScene;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string mobile;
		}

		[ProtoContract]
		public class PreDownloadInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint preDownloadPercent;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint preDownloadNetType;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string noPreDownloadRange;
		}

		[ProtoContract]
		public class PSMStat
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint mType;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string aType;
		}

		[ProtoContract]
		public class QuitChatRoom
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString chatRoomName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;
		}

		[ProtoContract]
		public class KVSTAT
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string value;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string kid;
		}

		[ProtoContract]
		public class SnsCommentInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickname;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string content;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint createTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int commentId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int replyCommentId;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string replyUsername;
		}

		[ProtoContract]
		public class SnsTagListRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string tagListMd5;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opCode;
		}

		[ProtoContract]
		public class SnsTagListResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opCode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string tagListMd5;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SnsTag[] list;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint t6;
		}

		[ProtoContract]
		public class SnsTag
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong tagId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string tagName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint count;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] list;
		}

		[ProtoContract]
		public class SnsAdExpInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong hateFeedid;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint hateTimestamp;
		}

		[ProtoContract]
		public class SnsTimeLineRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string firstPageMd5;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public ulong maxId;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public ulong minFilterId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint lastRequestTime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong clientLastestId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ seesion;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint networkType;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SnsAdExpInfo adexpinfo;
		}

		[ProtoContract]
		public class ModChatRoomNotify
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString chatRoomName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint status;
		}

		[ProtoContract]
		public class SnsTimeLineResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string fristPageMd5;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint objectCount;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SnsObject[] objectList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint newRequestTime;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint objectCountForSameMd5;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint controlFlag;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.SnsServerConfig serverConfig;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint advertiseCount;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public byte[] advertiseList;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ session;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public uint recCount;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public byte[] recList;
		}

		[ProtoContract]
		public sealed class SnsObjectDetailRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public ulong id;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint groupDetail;
		}

		[ProtoContract]
		public sealed class SnsObjectDetailResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsObject @object;
		}

		[ProtoContract]
		public class SnsGroup
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong GroupId;
		}

		[ProtoContract]
		public class TwitterInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string oauthToken;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string oauthTokenSecret;
		}

		[ProtoContract]
		public class SnsPostRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S objectDesc;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint withUserListNum;

			[ProtoMember(4)]
			public MM.SKBuiltinString[] withUserList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint privacy;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint syncFlag;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string clientId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint postBGImgType;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint groupNum;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.SnsGroup[] groupIds;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint objectSource;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public ulong referId;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint blackListNum;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] blackList;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public MM.TwitterInfo twitterInfo;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public uint groupUserNum;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] groupUser;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public MM.SnsPostCtocUploadInfo ctocUploadInfo;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public MM.SnsPostOperationFields snsPostOperationFields;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public MM.SnsRedEnvelops snsRedEnvelops;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ poiInfo;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public string fromScene;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public MM.CanvasInfo canvasInfo;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public uint mediaInfoCount;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public MM.MediaInfo[] mediaInfo;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public MM.SnsWeAppInfo[] weAppInfo;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientCheckData;
		}

		[ProtoContract]
		public class SnsPostResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsObject snsObject;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string spamTips;
		}

		[ProtoContract]
		public class SnsWeAppInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string mapPoiId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint appId;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string redirectUrl;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint showType;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint score;
		}

		[ProtoContract]
		public class CanvasInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string dataBuffer;
		}

		[ProtoContract]
		public class SnsRedEnvelops
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint rewardCount;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] rewardUserList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint resourceId;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint reportId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint reportKey;
		}

		[ProtoContract]
		public class SnsPostOperationFields
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string shareUrlOriginal;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string shareUrlOpen;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string jsAppid;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint contactTagCount;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint tempUserCount;
		}

		[ProtoContract]
		public class SnsPostCtocUploadInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint flag;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint photoCount;
		}

		[ProtoContract]
		public class SnsUserPageRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string fristPageMd5;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public ulong maxid;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong minFilterId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint lastRequestTime;
		}

		[ProtoContract]
		public class SnsUserPageResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string fristPageMd5;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint objectCount;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SnsObject[] objectList;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint objectTotalCount;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint newRequestTime;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint objectCountForSameMd5;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SnsServerConfig serverConfig;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public ulong limitedId;
		}

		[ProtoContract]
		public class SnsServerConfig
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public int postMentionLimit;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int copyAndPasteWordLimit;
		}

		[ProtoContract]
		public class SnsObjectOpRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SnsObjectOp opList;
		}

		[ProtoContract]
		public class Ext_CommentId
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint commentId;
		}

		[ProtoContract]
		public class SnsObjectOp
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public ulong id;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsObjectOpType opType;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ ext;
		}

		[ProtoContract]
		public class SnsObjectOpResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int[] opRetList;
		}

		[ProtoContract]
		public class SnsSyncRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint selector;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey keyBuf;
		}

		[ProtoContract]
		public class SnsSyncResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.CmdList cmdList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint continueFlag;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.syncMsgKey keyBuf;
		}

		[ProtoContract]
		public class AdShareInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint memberCount;
		}

		[ProtoContract]
		public class AdClickRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string viewid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int clickpos;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string descxml;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint scene;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string ssid;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string bssid;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong timestampMs;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.AdShareInfo shareInfo;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint adType;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint clickAction;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string snsStatext;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint flipStatus;
		}

		[ProtoContract]
		public class AdClickResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int ret;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string msg;
		}

		[ProtoContract]
		public class AdExposureInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint startPositionType;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint endPositionType;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public float readHeight;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public float unReadTopHeight;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint unReadBottomHeight;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public ulong startTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public ulong endTime;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong halfStartTime;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public ulong halfEndTime;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint allStartTime;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint allEndTime;
		}

		[ProtoContract]
		public class AdExposureSocialInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint likeCount;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint commentCount;
		}

		[ProtoContract]
		public class AdExposureRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string viewid;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint scene;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint exposureDuration;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string ssid;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string bssid;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong timestampMs;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.AdExposureInfo exposureInfo;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public MM.AdExposureSocialInfo socialInfo;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint adType;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string descxml;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string snsStatext;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public uint exposureCnt;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public ulong feedDuration;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public ulong feedFullDuration;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public uint flipStatus;
		}

		[ProtoContract]
		public class AdExposureResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int ret;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string msg;
		}

		public enum SnsObjectOpType
		{
			MMSNS_OBJECTOP_CANCEL_LIKE = 5,
			MMSNS_OBJECTOP_DEL = 1,
			MMSNS_OBJECTOP_DELETE_COMMENT = 4,
			MMSNS_OBJECTOP_SET_OPEN = 3,
			MMSNS_OBJECTOP_SET_PRIVACY = 2
		}

		[ProtoContract]
		public class ExtDeviceLoginConfirmGetRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string loginUrl;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string deviceName;
		}

		[ProtoContract]
		public class ExtDeviceLoginConfirmOKRet
		{
			[ProtoMember(1)]
			public uint icoType;

			[ProtoMember(2)]
			public string contentStr;

			[ProtoMember(3)]
			public string buttonOkstr;

			[ProtoMember(4)]
			public string buttonCancelStr;

			[ProtoMember(5)]
			public uint reqSessionLimit;

			[ProtoMember(6)]
			public uint confirmTimeOut;

			[ProtoMember(7)]
			public string loginedDevTip;

			[ProtoMember(8)]
			public string titleStr;

			[ProtoMember(9)]
			public string warningStr;
		}

		public class ExtDeviceLoginConfirmErrorRet
		{
			[ProtoMember(1)]
			public uint iconType;

			[ProtoMember(2)]
			public string contentStr;
		}

		public class ExtDeviceLoginConfirmExpiredRet
		{
			[ProtoMember(1)]
			public uint iconType;

			[ProtoMember(2)]
			public string contentStr;

			[ProtoMember(3)]
			public string buttonStr;
		}

		[ProtoContract]
		public class ExtDeviceLoginConfirmGetResponse
		{
			[ProtoMember(1)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2)]
			public MM.ExtDeviceLoginConfirmOKRet okret;

			[ProtoMember(3, Options = MemberSerializationOptions.DynamicType)]
			public MM.ExtDeviceLoginConfirmErrorRet errorRet;

			[ProtoMember(4, Options = MemberSerializationOptions.DynamicType)]
			public MM.ExtDeviceLoginConfirmExpiredRet expiredRet;

			[ProtoMember(5)]
			public string deviceNameStr;

			[ProtoMember(6)]
			public uint loginClientVersion;

			[ProtoMember(7)]
			public uint funcCtrl;
		}

		[ProtoContract]
		public class ExtDeviceLoginConfirmOKRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string loginUrl;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string sessionList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public byte[] unReadChatContaceList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public bool syncMsg;
		}

		[ProtoContract]
		public class ExtDeviceLoginConfirmOKResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public byte[] msgContextPubKey;
		}

		public enum SnsObjectType
		{
			MMSNS_OBJECT_UNKNOWN,
			MMSNS_OBJECT_PHOTO,
			MMSNS_OBJECT_TEXT,
			MMSNS_OBJECT_FEED,
			MMSNS_OBJECT_MUSIC,
			MMSNS_OBJECT_VIDEO,
			MMSNS_OBJECT_LOCATION,
			MMSNS_OBJECT_BACKGROUND,
			MMSNS_OBJECT_WXSIGN,
			MMSNS_OBJECT_PRODUCT,
			MMSNS_OBJECT_EMOTION,
			MMSNS_OBJECT_OLD_TV,
			MMSNS_OBJECT_GENERAL_PRODUCT,
			MMSNS_OBJECT_GENERAL_CARD,
			MMSNS_OBJECT_TV,
			MMSNS_OBJECT_SIGHT
		}

		public enum SnsMediaType
		{
			MMSNS_DATA_MUSIC = 5,
			MMSNS_DATA_PHOTO = 2,
			MMSNS_DATA_SIGHT = 6,
			MMSNS_DATA_TEXT = 1,
			MMSNS_DATA_VIDEO = 4,
			MMSNS_DATA_VOICE = 3
		}

		public enum SnsTagDefaultId : ulong
		{
			MM_SNS_TAG_ID_BLACKLIST = 5uL,
			MM_SNS_TAG_ID_CLASSMATE = 3uL,
			MM_SNS_TAG_ID_COLLEAGUE = 2uL,
			MM_SNS_TAG_ID_FRIEND = 1uL,
			MM_SNS_TAG_ID_OTHERS = 6uL,
			MM_SNS_TAG_ID_OUTSIDERS = 4uL,
			MM_SNS_TAG_ID_PRIVATE = 0uL
		}

		[ProtoContract]
		public class SnsUploadRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint type;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ buffer;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string clientId;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint filterStype;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint syncFlag;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string descript;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int photoFrom;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int netType;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.TwitterInfo twitterInfo;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string appId;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint extFlag;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string md5;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public MM.SnsObjectType objectType;
		}

		[ProtoContract]
		public class SnsUploadResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint startPos;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint totalLen;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string clientId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SnsBufferUrl bufferUrl;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint thumbUrlCount;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SnsBufferUrl[] thumbUrls;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public ulong id;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint type;
		}

		[ProtoContract]
		public class SnsBufferUrl
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string url;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint type;
		}

		[ProtoContract]
		public class MassSendRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string toList;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string toListMd5;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string clientId;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint msgType;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint mediaTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S dataBuffer;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint dataStartPos;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint dataTotalLen;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public uint thumbTotalLen;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public uint thumbStartPos;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ thumbData;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public uint cameraType;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public uint videoSource;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public uint toListCount;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public uint isSendAgain;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public uint compressType;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public uint voiceFormat;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string videoUrl;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string thumbUrl;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public uint thumbWith;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public uint thumbHeight;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public string thumbAeskey;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public string videoAeskey;
		}

		[ProtoContract]
		public class MassSendResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint dataStartPos;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint thumbStartPos;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint maxSupport;
		}

		[ProtoContract]
		public class MediaInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint source;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SnsMediaType mediaType;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint videoPlayLength;

			[ProtoMember(4)]
			public string sessionId;

			[ProtoMember(5)]
			public uint startTime;
		}

        [ProtoContract]
        public class ImgInfo
        {
            [ProtoMember(2, Options = MemberSerializationOptions.Required)]
            byte[] buffer;
            [ProtoMember(1, Options = MemberSerializationOptions.Required)]
            int iLen;
        }

        [ProtoContract]
        public class HongBaoListReqMsg
        {
            [ProtoMember(1, Options = MemberSerializationOptions.Required)]
            public MMPro.MM.BaseRequest baseRequest;
            [ProtoMember(2, Options = MemberSerializationOptions.Required)]
            public string content;
            [ProtoMember(3, Options = MemberSerializationOptions.Required)]
            public UInt64 createtime;
            [ProtoMember(4, Options = MemberSerializationOptions.Required)]
            public string from;
            [ProtoMember(5, Options = MemberSerializationOptions.Required)]
            public ImgInfo img;
            [ProtoMember(6, Options = MemberSerializationOptions.Required)]
            public int imgStatus;
            [ProtoMember(7, Options = MemberSerializationOptions.Required)]
            public UInt64 msgid;
            [ProtoMember(8, Options = MemberSerializationOptions.Required)]
            public UInt64 msgSeq;
            [ProtoMember(9, Options = MemberSerializationOptions.Required)]
            public string msgSource;
            [ProtoMember(10, Options = MemberSerializationOptions.Required)]
            public UInt64 newMsgId;
            [ProtoMember(11, Options = MemberSerializationOptions.Required)]
            public string pushcontent;
            [ProtoMember(12, Options = MemberSerializationOptions.Required)]
            public int status;
            [ProtoMember(13, Options = MemberSerializationOptions.Required)]
            public string to;
            [ProtoMember(14, Options = MemberSerializationOptions.Required)]
            public int type;
        }

        [ProtoContract]
        public class HongBaoListResMsg
        {
            [ProtoMember(1)]
            public MMPro.MM.BaseResponse baseResponse;
            [ProtoMember(2)]
            public int errorType;
            [ProtoMember(3)]
            public string errorMsg;
        }

        [ProtoContract]
		public class HongBaoRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int cgiCmd;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint outPutType;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_S reqText;
		}

		[ProtoContract]
		public class HongBaoResponse
		{
			[ProtoMember(1)]
			public MM.BaseResponse BaseResponse;

			[ProtoMember(2)]
			public MM.SKBuiltinString_S retText;

			[ProtoMember(3)]
			public int platRet;

			[ProtoMember(4)]
			public string platMsg;

			[ProtoMember(5)]
			public int cgiCmdid;

			[ProtoMember(6)]
			public int errorType;

			[ProtoMember(7)]
			public string errorMsg;
		}

		[ProtoContract]
		public class InitContactRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string username;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int currentWxcontactSeq;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int currentChatRoomContactSeq;
		}

		[ProtoContract]
		public class InitContactResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int currentWxcontactSeq;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int currentChatRoomContactSeq;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint countinueFlag;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string[] contactUsernameList;
		}

		public class HongBaoRetText
		{
			public int retcode
			{
				get;
				set;
			}

			public string retmsg
			{
				get;
				set;
			}

			public string sendId
			{
				get;
				set;
			}

			public string wishing
			{
				get;
				set;
			}

			public int isSender
			{
				get;
				set;
			}

			public int receiveStatus
			{
				get;
				set;
			}

			public int hbStatus
			{
				get;
				set;
			}

			public string statusMess
			{
				get;
				set;
			}

			public int hbType
			{
				get;
				set;
			}

			public string watermark
			{
				get;
				set;
			}

			public MM.Agree_Duty agree_duty
			{
				get;
				set;
			}

			public string sendUserName
			{
				get;
				set;
			}

			public string timingIdentifier
			{
				get;
				set;
			}
		}

		public class Agree_Duty
		{
			public string title
			{
				get;
				set;
			}

			public string service_protocol_wording
			{
				get;
				set;
			}

			public string service_protocol_url
			{
				get;
				set;
			}

			public string button_wording
			{
				get;
				set;
			}

			public int delay_expired_time
			{
				get;
				set;
			}

			public int agreed_flag
			{
				get;
				set;
			}
		}

		[ProtoContract]
		public class NewGetInviteFriendRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint friendType;
		}

		[ProtoContract]
		public class NewInviteFriend
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint uin;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string email;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string remark;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint friendType;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint groupId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string imgIdx;
		}

		[ProtoContract]
		public class FriendGroup
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public uint groupId;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string groupName;
		}

		[ProtoContract]
		public class NewGetInviteFriendResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint friendCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.NewInviteFriend[] friendList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint groupCount;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.FriendGroup[] groupList;
		}

		[ProtoContract]
		public class Mobile
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string v;
		}

		[ProtoContract]
		public class MEmail
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string v;
		}

		[ProtoContract]
		public class UploadMContactResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;
		}

		[ProtoContract]
		public class UploadMContactRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public int opcode;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string mobile;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int mobileListSize;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.Mobile[] mobileList;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int emailListSize;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public MM.MEmail[] emailList;
		}

		[ProtoContract]
		public class LBsContactInfo
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string distance;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public uint imgStatus;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public uint verifyFlag;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string alias;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public uint weiboFlag;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public int headImgVersion;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public string country;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public MM.CustomizedInfo customizedInfo;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public string antispamTocklet;
		}

		[ProtoContract]
		public class LbsResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint contactCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.LBsContactInfo[] contactList;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint state;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint flushTime;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public uint roomMemberCount;
		}

		[ProtoContract]
		public class LbsRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opCode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public float logitude;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public float latitude;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int precision;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string macAddr;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string cellId;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public int gPSSource;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ clientCheckData;
		}

		[ProtoContract]
		public class GetContactLabelListRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;
		}

		[ProtoContract]
		public class GetContactLabelListResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint labelCount;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.LabelPair[] labelPairList;
		}

		[ProtoContract]
		public class LabelPair
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string labelName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint labelID;
		}

		[ProtoContract]
		public class SetChatRoomAnnouncementRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public string chatRoomName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string announcement;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint setAnnouncementFlag;
		}

		[ProtoContract]
		public class SetChatRoomAnnouncementResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;
		}

		[ProtoContract]
		public class GetQRCodeRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString[] userName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint style;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint opcode;
		}

		[ProtoContract]
		public class GetQRCodeResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ qrcode;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint style;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string footerWording;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public string revokeQrcodeId;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public string revokeQrcodeWording;
		}

		[ProtoContract]
		public class SearchContactRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public uint opCode;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public uint fromScene;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint searchScene;
		}

		[ProtoContract]
		public class SearchContactItem
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString pYInitial;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public int personalCard;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int verifyFlag;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string alias;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public int weiboFlag;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public int albumStyle;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public int albumFlag;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public string albumBigimgId;
		}

		[ProtoContract]
		public class SearchContactResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString userName;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString nickName;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString pYInitial;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString quanPin;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public int sex;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ imgBuf;

			[ProtoMember(8, Options = MemberSerializationOptions.Required)]
			public string province;

			[ProtoMember(9, Options = MemberSerializationOptions.Required)]
			public string city;

			[ProtoMember(10, Options = MemberSerializationOptions.Required)]
			public string signature;

			[ProtoMember(11, Options = MemberSerializationOptions.Required)]
			public int personalCard;

			[ProtoMember(12, Options = MemberSerializationOptions.Required)]
			public int verifyFlag;

			[ProtoMember(13, Options = MemberSerializationOptions.Required)]
			public string verifyInfo;

			[ProtoMember(14, Options = MemberSerializationOptions.Required)]
			public string weibo;

			[ProtoMember(15, Options = MemberSerializationOptions.Required)]
			public string verifyContent;

			[ProtoMember(16, Options = MemberSerializationOptions.Required)]
			public string weiboNickname;

			[ProtoMember(17, Options = MemberSerializationOptions.Required)]
			public int weiboFlag;

			[ProtoMember(18, Options = MemberSerializationOptions.Required)]
			public int albumStyle;

			[ProtoMember(19, Options = MemberSerializationOptions.Required)]
			public int albumFlag;

			[ProtoMember(20, Options = MemberSerializationOptions.Required)]
			public string albumBgimgId;

			[ProtoMember(21, Options = MemberSerializationOptions.Required)]
			public MM.SnsUserInfo snsUserInfo;

			[ProtoMember(22, Options = MemberSerializationOptions.Required)]
			public string country;

			[ProtoMember(23, Options = MemberSerializationOptions.Required)]
			public string myBrandList;

			[ProtoMember(24, Options = MemberSerializationOptions.Required)]
			public MM.CustomizedInfo customizedInfo;

			[ProtoMember(25, Options = MemberSerializationOptions.Required)]
			public uint contactCount;

			[ProtoMember(26, Options = MemberSerializationOptions.Required)]
			public MM.SearchContactItem[] contactlist;

			[ProtoMember(27, Options = MemberSerializationOptions.Required)]
			public string bigHeadImgUrl;

			[ProtoMember(28, Options = MemberSerializationOptions.Required)]
			public string smallHeadImgUrl;

			[ProtoMember(29, Options = MemberSerializationOptions.Required)]
			public MM.SKBuiltinString_ resBuf;

			[ProtoMember(30, Options = MemberSerializationOptions.Required)]
			public string antispamTicket;

			[ProtoMember(31, Options = MemberSerializationOptions.Required)]
			public string kfworkerId;

			[ProtoMember(32, Options = MemberSerializationOptions.Required)]
			public uint matchType;

			[ProtoMember(33, Options = MemberSerializationOptions.Required)]
			public string popupInfoMsg;

			[ProtoMember(34, Options = MemberSerializationOptions.Required)]
			public uint openImcontactCount;

			[ProtoMember(35, Options = MemberSerializationOptions.Required)]
			public MM.Openimcontact[] openImcontactList;
		}

		[ProtoContract]
		public class Openimcontact
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public string userName;
		}

		[ProtoContract]
		public class GetMFriendRequest
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseRequest baseRequest;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public string mD5;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public uint opType;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public uint updateMobileListSize;

			[ProtoMember(5, Options = MemberSerializationOptions.Required)]
			public MM.Mobile[] updateMobileList;

			[ProtoMember(6, Options = MemberSerializationOptions.Required)]
			public uint updateEmailListSize;

			[ProtoMember(7, Options = MemberSerializationOptions.Required)]
			public MM.MEmail[] updateEmailList;
		}

		[ProtoContract]
		public class GetMFriendResponse
		{
			[ProtoMember(1, Options = MemberSerializationOptions.Required)]
			public MM.BaseResponse baseResponse;

			[ProtoMember(3, Options = MemberSerializationOptions.Required)]
			public MM.Mobile friendList;

			[ProtoMember(2, Options = MemberSerializationOptions.Required)]
			public int count;

			[ProtoMember(4, Options = MemberSerializationOptions.Required)]
			public string md5;
		}
	}
}
