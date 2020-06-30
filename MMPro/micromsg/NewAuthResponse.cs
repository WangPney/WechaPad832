using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "NewAuthResponse")]
	[Serializable]
	public class NewAuthResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Uin;

		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _NickName;

		private uint _BindUin;

		private SKBuiltinString_t _BindEmail;

		private SKBuiltinString_t _BindMobile;

		private uint _Status;

		private byte[] _SessionKey = null;

		private SKBuiltinString_t _ImgSid;

		private SKBuiltinBuffer_t _ImgBuf;

		private SKBuiltinString_t _OfficialUserName;

		private SKBuiltinString_t _OfficialNickName;

		private SKBuiltinString_t _QQMicroBlogUserName = null;

		private uint _QQMicroBlogStatus = 0u;

		private uint _NewVersion = 0u;

		private string _Ticket = "";

		private uint _PushMailStatus = 0u;

		private uint _SendCardBitFlag = 0u;

		private string _PushMailSettingTicket = "";

		private BuiltinIPList _BuiltinIPList = null;

		private string _FSURL = "";

		private NetworkControl _NetworkControl = null;

		private uint _PluginFlag = 0u;

		private string _Alias = "";

		private uint _RegType = 0u;

		private string _AuthKey = "";

		private string _Sid = "";

		private PluginKeyList _PluginKeyList = null;

		private SKBuiltinString_t _ImgEncryptKey = null;

		private SKBuiltinBuffer_t _A2Key = null;

		private SKBuiltinBuffer_t _KSid = null;

		private uint _ProfileFlag = 0u;

		private string _Password = "";

		private uint _TimeStamp = 0u;

		private uint _IsAutoReg = 0u;

		private string _KickResponse = "";

		private string _ApplyBetaUrl = "";

		private string _DeviceInfoXml = "";

		private string _SoftConfigXml = "";

		private HostList _NewHostList = null;

		private string _AuthTicket = "";

		private uint _SafeDevice = 0u;

		private uint _ObsoleteItem1 = 0u;

		private uint _NeedSetEmailPwd = 0u;

		private string _HintMsg = "";

		private string _AutoAuthTicket = "";

		private CDNDnsInfo _DnsInfo = null;

		private uint _NextAuthType = 0u;

		private SKBuiltinBuffer_t _WTLoginRspBuff = null;

		private ShowStyleKey _ShowStyle = null;

		private SKBuiltinBuffer_t _CliDBEncryptKey = null;

		private SKBuiltinBuffer_t _CliDBEncryptInfo = null;

		private uint _Flag = 0u;

		private CDNDnsInfo _SnsDnsInfo = null;

		private CDNDnsInfo _AppDnsInfo = null;

		private string _VerifySignature = "";

		private SKBuiltinBuffer_t _VerifyBuff = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Uin", DataFormat = DataFormat.TwosComplement)]
		public uint Uin
		{
			get
			{
				return this._Uin;
			}
			set
			{
				this._Uin = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "NickName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "BindUin", DataFormat = DataFormat.TwosComplement)]
		public uint BindUin
		{
			get
			{
				return this._BindUin;
			}
			set
			{
				this._BindUin = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "BindEmail", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t BindEmail
		{
			get
			{
				return this._BindEmail;
			}
			set
			{
				this._BindEmail = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "BindMobile", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t BindMobile
		{
			get
			{
				return this._BindMobile;
			}
			set
			{
				this._BindMobile = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public uint Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "SessionKey", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] SessionKey
		{
			get
			{
				return this._SessionKey;
			}
			set
			{
				this._SessionKey = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "ImgSid", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ImgSid
		{
			get
			{
				return this._ImgSid;
			}
			set
			{
				this._ImgSid = value;
			}
		}

		[ProtoMember(11, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ImgBuf
		{
			get
			{
				return this._ImgBuf;
			}
			set
			{
				this._ImgBuf = value;
			}
		}

		[ProtoMember(12, IsRequired = true, Name = "OfficialUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t OfficialUserName
		{
			get
			{
				return this._OfficialUserName;
			}
			set
			{
				this._OfficialUserName = value;
			}
		}

		[ProtoMember(13, IsRequired = true, Name = "OfficialNickName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t OfficialNickName
		{
			get
			{
				return this._OfficialNickName;
			}
			set
			{
				this._OfficialNickName = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "QQMicroBlogUserName", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t QQMicroBlogUserName
		{
			get
			{
				return this._QQMicroBlogUserName;
			}
			set
			{
				this._QQMicroBlogUserName = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "QQMicroBlogStatus", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint QQMicroBlogStatus
		{
			get
			{
				return this._QQMicroBlogStatus;
			}
			set
			{
				this._QQMicroBlogStatus = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "NewVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewVersion
		{
			get
			{
				return this._NewVersion;
			}
			set
			{
				this._NewVersion = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "Ticket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Ticket
		{
			get
			{
				return this._Ticket;
			}
			set
			{
				this._Ticket = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "PushMailStatus", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PushMailStatus
		{
			get
			{
				return this._PushMailStatus;
			}
			set
			{
				this._PushMailStatus = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "SendCardBitFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SendCardBitFlag
		{
			get
			{
				return this._SendCardBitFlag;
			}
			set
			{
				this._SendCardBitFlag = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "PushMailSettingTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PushMailSettingTicket
		{
			get
			{
				return this._PushMailSettingTicket;
			}
			set
			{
				this._PushMailSettingTicket = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "BuiltinIPList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BuiltinIPList BuiltinIPList
		{
			get
			{
				return this._BuiltinIPList;
			}
			set
			{
				this._BuiltinIPList = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "FSURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FSURL
		{
			get
			{
				return this._FSURL;
			}
			set
			{
				this._FSURL = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "NetworkControl", DataFormat = DataFormat.Default), DefaultValue(null)]
		public NetworkControl NetworkControl
		{
			get
			{
				return this._NetworkControl;
			}
			set
			{
				this._NetworkControl = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "PluginFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PluginFlag
		{
			get
			{
				return this._PluginFlag;
			}
			set
			{
				this._PluginFlag = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Alias
		{
			get
			{
				return this._Alias;
			}
			set
			{
				this._Alias = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "RegType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint RegType
		{
			get
			{
				return this._RegType;
			}
			set
			{
				this._RegType = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "AuthKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AuthKey
		{
			get
			{
				return this._AuthKey;
			}
			set
			{
				this._AuthKey = value;
			}
		}

		[ProtoMember(28, IsRequired = false, Name = "Sid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Sid
		{
			get
			{
				return this._Sid;
			}
			set
			{
				this._Sid = value;
			}
		}

		[ProtoMember(29, IsRequired = false, Name = "PluginKeyList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public PluginKeyList PluginKeyList
		{
			get
			{
				return this._PluginKeyList;
			}
			set
			{
				this._PluginKeyList = value;
			}
		}

		[ProtoMember(30, IsRequired = false, Name = "ImgEncryptKey", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t ImgEncryptKey
		{
			get
			{
				return this._ImgEncryptKey;
			}
			set
			{
				this._ImgEncryptKey = value;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "A2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t A2Key
		{
			get
			{
				return this._A2Key;
			}
			set
			{
				this._A2Key = value;
			}
		}

		[ProtoMember(32, IsRequired = false, Name = "KSid", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t KSid
		{
			get
			{
				return this._KSid;
			}
			set
			{
				this._KSid = value;
			}
		}

		[ProtoMember(33, IsRequired = false, Name = "ProfileFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ProfileFlag
		{
			get
			{
				return this._ProfileFlag;
			}
			set
			{
				this._ProfileFlag = value;
			}
		}

		[ProtoMember(34, IsRequired = false, Name = "Password", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				this._Password = value;
			}
		}

		[ProtoMember(35, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(36, IsRequired = false, Name = "IsAutoReg", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IsAutoReg
		{
			get
			{
				return this._IsAutoReg;
			}
			set
			{
				this._IsAutoReg = value;
			}
		}

		[ProtoMember(37, IsRequired = false, Name = "KickResponse", DataFormat = DataFormat.Default), DefaultValue("")]
		public string KickResponse
		{
			get
			{
				return this._KickResponse;
			}
			set
			{
				this._KickResponse = value;
			}
		}

		[ProtoMember(38, IsRequired = false, Name = "ApplyBetaUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ApplyBetaUrl
		{
			get
			{
				return this._ApplyBetaUrl;
			}
			set
			{
				this._ApplyBetaUrl = value;
			}
		}

		[ProtoMember(39, IsRequired = false, Name = "DeviceInfoXml", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceInfoXml
		{
			get
			{
				return this._DeviceInfoXml;
			}
			set
			{
				this._DeviceInfoXml = value;
			}
		}

		[ProtoMember(40, IsRequired = false, Name = "SoftConfigXml", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SoftConfigXml
		{
			get
			{
				return this._SoftConfigXml;
			}
			set
			{
				this._SoftConfigXml = value;
			}
		}

		[ProtoMember(41, IsRequired = false, Name = "NewHostList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public HostList NewHostList
		{
			get
			{
				return this._NewHostList;
			}
			set
			{
				this._NewHostList = value;
			}
		}

		[ProtoMember(42, IsRequired = false, Name = "AuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AuthTicket
		{
			get
			{
				return this._AuthTicket;
			}
			set
			{
				this._AuthTicket = value;
			}
		}

		[ProtoMember(43, IsRequired = false, Name = "SafeDevice", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SafeDevice
		{
			get
			{
				return this._SafeDevice;
			}
			set
			{
				this._SafeDevice = value;
			}
		}

		[ProtoMember(44, IsRequired = false, Name = "ObsoleteItem1", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ObsoleteItem1
		{
			get
			{
				return this._ObsoleteItem1;
			}
			set
			{
				this._ObsoleteItem1 = value;
			}
		}

		[ProtoMember(45, IsRequired = false, Name = "NeedSetEmailPwd", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NeedSetEmailPwd
		{
			get
			{
				return this._NeedSetEmailPwd;
			}
			set
			{
				this._NeedSetEmailPwd = value;
			}
		}

		[ProtoMember(46, IsRequired = false, Name = "HintMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string HintMsg
		{
			get
			{
				return this._HintMsg;
			}
			set
			{
				this._HintMsg = value;
			}
		}

		[ProtoMember(47, IsRequired = false, Name = "AutoAuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AutoAuthTicket
		{
			get
			{
				return this._AutoAuthTicket;
			}
			set
			{
				this._AutoAuthTicket = value;
			}
		}

		[ProtoMember(48, IsRequired = false, Name = "DnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo DnsInfo
		{
			get
			{
				return this._DnsInfo;
			}
			set
			{
				this._DnsInfo = value;
			}
		}

		[ProtoMember(49, IsRequired = false, Name = "NextAuthType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NextAuthType
		{
			get
			{
				return this._NextAuthType;
			}
			set
			{
				this._NextAuthType = value;
			}
		}

		[ProtoMember(50, IsRequired = false, Name = "WTLoginRspBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t WTLoginRspBuff
		{
			get
			{
				return this._WTLoginRspBuff;
			}
			set
			{
				this._WTLoginRspBuff = value;
			}
		}

		[ProtoMember(51, IsRequired = false, Name = "ShowStyle", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ShowStyleKey ShowStyle
		{
			get
			{
				return this._ShowStyle;
			}
			set
			{
				this._ShowStyle = value;
			}
		}

		[ProtoMember(52, IsRequired = false, Name = "CliDBEncryptKey", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t CliDBEncryptKey
		{
			get
			{
				return this._CliDBEncryptKey;
			}
			set
			{
				this._CliDBEncryptKey = value;
			}
		}

		[ProtoMember(53, IsRequired = false, Name = "CliDBEncryptInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t CliDBEncryptInfo
		{
			get
			{
				return this._CliDBEncryptInfo;
			}
			set
			{
				this._CliDBEncryptInfo = value;
			}
		}

		[ProtoMember(54, IsRequired = false, Name = "Flag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Flag
		{
			get
			{
				return this._Flag;
			}
			set
			{
				this._Flag = value;
			}
		}

		[ProtoMember(55, IsRequired = false, Name = "SnsDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo SnsDnsInfo
		{
			get
			{
				return this._SnsDnsInfo;
			}
			set
			{
				this._SnsDnsInfo = value;
			}
		}

		[ProtoMember(56, IsRequired = false, Name = "AppDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo AppDnsInfo
		{
			get
			{
				return this._AppDnsInfo;
			}
			set
			{
				this._AppDnsInfo = value;
			}
		}

		[ProtoMember(57, IsRequired = false, Name = "VerifySignature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifySignature
		{
			get
			{
				return this._VerifySignature;
			}
			set
			{
				this._VerifySignature = value;
			}
		}

		[ProtoMember(58, IsRequired = false, Name = "VerifyBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t VerifyBuff
		{
			get
			{
				return this._VerifyBuff;
			}
			set
			{
				this._VerifyBuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
