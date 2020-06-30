using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserInfoExt")]
	[Serializable]
	public class UserInfoExt : IExtensible
	{
		private SnsUserInfo _SnsUserInfo;

		private string _MyBrandList = "";

		private string _MsgPushSound = "";

		private string _VoipPushSound = "";

		private uint _BigChatRoomSize = 0u;

		private uint _BigChatRoomQuota = 0u;

		private uint _BigChatRoomInvite = 0u;

		private string _SafeMobile = "";

		private string _BigHeadImgUrl = "";

		private string _SmallHeadImgUrl = "";

		private uint _MainAcctType = 0u;

		private SKBuiltinString_t _ExtXml = null;

		private SafeDeviceList _SafeDeviceList = null;

		private uint _SafeDevice = 0u;

		private uint _GrayscaleFlag = 0u;

		private string _GoogleContactName = "";

		private string _IDCardNum = "";

		private string _RealName = "";

		private string _RegCountry = "";

		private string _BBPPID = "";

		private string _BBPIN = "";

		private string _BBMNickName = "";

		private LinkedinContactItem _LinkedinContactItem = null;

		private string _KFInfo = "";

		private PatternLockInfo _PatternLockInfo = null;

		private string _SecurityDeviceId = "";

		private uint _PayWalletType = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SnsUserInfo", DataFormat = DataFormat.Default)]
		public SnsUserInfo SnsUserInfo
		{
			get
			{
				return this._SnsUserInfo;
			}
			set
			{
				this._SnsUserInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "MyBrandList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MyBrandList
		{
			get
			{
				return this._MyBrandList;
			}
			set
			{
				this._MyBrandList = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "MsgPushSound", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MsgPushSound
		{
			get
			{
				return this._MsgPushSound;
			}
			set
			{
				this._MsgPushSound = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "VoipPushSound", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VoipPushSound
		{
			get
			{
				return this._VoipPushSound;
			}
			set
			{
				this._VoipPushSound = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "BigChatRoomSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint BigChatRoomSize
		{
			get
			{
				return this._BigChatRoomSize;
			}
			set
			{
				this._BigChatRoomSize = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "BigChatRoomQuota", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint BigChatRoomQuota
		{
			get
			{
				return this._BigChatRoomQuota;
			}
			set
			{
				this._BigChatRoomQuota = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "BigChatRoomInvite", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint BigChatRoomInvite
		{
			get
			{
				return this._BigChatRoomInvite;
			}
			set
			{
				this._BigChatRoomInvite = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "SafeMobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SafeMobile
		{
			get
			{
				return this._SafeMobile;
			}
			set
			{
				this._SafeMobile = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BigHeadImgUrl
		{
			get
			{
				return this._BigHeadImgUrl;
			}
			set
			{
				this._BigHeadImgUrl = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmallHeadImgUrl
		{
			get
			{
				return this._SmallHeadImgUrl;
			}
			set
			{
				this._SmallHeadImgUrl = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "MainAcctType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MainAcctType
		{
			get
			{
				return this._MainAcctType;
			}
			set
			{
				this._MainAcctType = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "ExtXml", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t ExtXml
		{
			get
			{
				return this._ExtXml;
			}
			set
			{
				this._ExtXml = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "SafeDeviceList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SafeDeviceList SafeDeviceList
		{
			get
			{
				return this._SafeDeviceList;
			}
			set
			{
				this._SafeDeviceList = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "SafeDevice", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(15, IsRequired = false, Name = "GrayscaleFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GrayscaleFlag
		{
			get
			{
				return this._GrayscaleFlag;
			}
			set
			{
				this._GrayscaleFlag = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "GoogleContactName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GoogleContactName
		{
			get
			{
				return this._GoogleContactName;
			}
			set
			{
				this._GoogleContactName = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "IDCardNum", DataFormat = DataFormat.Default), DefaultValue("")]
		public string IDCardNum
		{
			get
			{
				return this._IDCardNum;
			}
			set
			{
				this._IDCardNum = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "RealName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RealName
		{
			get
			{
				return this._RealName;
			}
			set
			{
				this._RealName = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "RegCountry", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RegCountry
		{
			get
			{
				return this._RegCountry;
			}
			set
			{
				this._RegCountry = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "BBPPID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPPID
		{
			get
			{
				return this._BBPPID;
			}
			set
			{
				this._BBPPID = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "BBPIN", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPIN
		{
			get
			{
				return this._BBPIN;
			}
			set
			{
				this._BBPIN = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "BBMNickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBMNickName
		{
			get
			{
				return this._BBMNickName;
			}
			set
			{
				this._BBMNickName = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "LinkedinContactItem", DataFormat = DataFormat.Default), DefaultValue(null)]
		public LinkedinContactItem LinkedinContactItem
		{
			get
			{
				return this._LinkedinContactItem;
			}
			set
			{
				this._LinkedinContactItem = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "KFInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string KFInfo
		{
			get
			{
				return this._KFInfo;
			}
			set
			{
				this._KFInfo = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "PatternLockInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public PatternLockInfo PatternLockInfo
		{
			get
			{
				return this._PatternLockInfo;
			}
			set
			{
				this._PatternLockInfo = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "SecurityDeviceId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SecurityDeviceId
		{
			get
			{
				return this._SecurityDeviceId;
			}
			set
			{
				this._SecurityDeviceId = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "PayWalletType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PayWalletType
		{
			get
			{
				return this._PayWalletType;
			}
			set
			{
				this._PayWalletType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
