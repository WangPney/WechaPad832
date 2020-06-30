using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "NewRegResponse")]
	[Serializable]
	public class NewRegResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Uin;

		private string _SessionKey = "";

		private string _OfficialUserName = "";

		private string _OfficialNickName = "";

		private string _QQMicroBlogUserName = "";

		private string _BindEmail = "";

		private uint _PushMailStatus;

		private uint _SendCardBitFlag = 0u;

		private string _PushMailSettingTicket = "";

		private BuiltinIPList _BuiltinIPList = null;

		private string _FSURL = "";

		private string _UserName = "";

		private uint _Status = 0u;

		private NetworkControl _NetworkControl = null;

		private uint _ReturnFlag = 0u;

		private uint _RegType = 0u;

		private string _AuthKey = "";

		private PluginKeyList _PluginKeyList = null;

		private string _Password = "";

		private uint _ProfileFlag = 0u;

		private HostList _NewHostList = null;

		private string _AutoAuthTicket = "";

		private CDNDnsInfo _DnsInfo = null;

		private string _StepTicket = "";

		private string _VerifySignature = "";

		private SKBuiltinBuffer_t _VerifyBuff = null;

		private ShowStyleKey _ShowStyle = null;

		private CDNDnsInfo _SnsDnsInfo = null;

		private CDNDnsInfo _AppDnsInfo = null;

		private SecAuthRegKeySect _SecAuthRegKeySect = null;

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

		[ProtoMember(3, IsRequired = false, Name = "SessionKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SessionKey
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

		[ProtoMember(4, IsRequired = false, Name = "OfficialUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OfficialUserName
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

		[ProtoMember(5, IsRequired = false, Name = "OfficialNickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OfficialNickName
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

		[ProtoMember(6, IsRequired = false, Name = "QQMicroBlogUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string QQMicroBlogUserName
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

		[ProtoMember(7, IsRequired = false, Name = "BindEmail", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BindEmail
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

		[ProtoMember(8, IsRequired = true, Name = "PushMailStatus", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "SendCardBitFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(10, IsRequired = false, Name = "PushMailSettingTicket", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(14, IsRequired = false, Name = "BuiltinIPList", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(15, IsRequired = false, Name = "FSURL", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(16, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
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

		[ProtoMember(17, IsRequired = false, Name = "Status", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(18, IsRequired = false, Name = "NetworkControl", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(19, IsRequired = false, Name = "ReturnFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ReturnFlag
		{
			get
			{
				return this._ReturnFlag;
			}
			set
			{
				this._ReturnFlag = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "RegType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(21, IsRequired = false, Name = "AuthKey", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(22, IsRequired = false, Name = "PluginKeyList", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(23, IsRequired = false, Name = "Password", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(24, IsRequired = false, Name = "ProfileFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(25, IsRequired = false, Name = "NewHostList", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(26, IsRequired = false, Name = "AutoAuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(27, IsRequired = false, Name = "DnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(28, IsRequired = false, Name = "StepTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StepTicket
		{
			get
			{
				return this._StepTicket;
			}
			set
			{
				this._StepTicket = value;
			}
		}

		[ProtoMember(29, IsRequired = false, Name = "VerifySignature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(30, IsRequired = false, Name = "VerifyBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(31, IsRequired = false, Name = "ShowStyle", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(32, IsRequired = false, Name = "SnsDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(33, IsRequired = false, Name = "AppDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(34, IsRequired = false, Name = "SecAuthRegKeySect", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SecAuthRegKeySect SecAuthRegKeySect
		{
			get
			{
				return this._SecAuthRegKeySect;
			}
			set
			{
				this._SecAuthRegKeySect = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
