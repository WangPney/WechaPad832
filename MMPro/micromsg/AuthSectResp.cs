using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AuthSectResp")]
	[Serializable]
	public class AuthSectResp : IExtensible
	{
		private uint _Uin;

		private ECDHKey _SvrPubECDHKey;

		private SKBuiltinBuffer_t _SessionKey;

		private SKBuiltinBuffer_t _AutoAuthKey;

		private uint _WTLoginRspBuffFlag;

		private SKBuiltinBuffer_t _WTLoginRspBuff = null;

		private WTLoginImgRespInfo _WTLoginImgRespInfo = null;

		private WxVerifyCodeRespInfo _WxVerifyCodeRespInfo = null;

		private SKBuiltinBuffer_t _CliDBEncryptKey = null;

		private SKBuiltinBuffer_t _CliDBEncryptInfo = null;

		private string _AuthKey = "";

		private SKBuiltinBuffer_t _A2Key = null;

		private string _ApplyBetaUrl = "";

		private ShowStyleKey _ShowStyle = null;

		private string _AuthTicket = "";

		private uint _NewVersion = 0u;

		private uint _UpdateFlag = 0u;

		private uint _AuthResultFlag = 0u;

		private string _FSURL = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Uin", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = true, Name = "SvrPubECDHKey", DataFormat = DataFormat.Default)]
		public ECDHKey SvrPubECDHKey
		{
			get
			{
				return this._SvrPubECDHKey;
			}
			set
			{
				this._SvrPubECDHKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "SessionKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t SessionKey
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

		[ProtoMember(4, IsRequired = true, Name = "AutoAuthKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t AutoAuthKey
		{
			get
			{
				return this._AutoAuthKey;
			}
			set
			{
				this._AutoAuthKey = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "WTLoginRspBuffFlag", DataFormat = DataFormat.TwosComplement)]
		public uint WTLoginRspBuffFlag
		{
			get
			{
				return this._WTLoginRspBuffFlag;
			}
			set
			{
				this._WTLoginRspBuffFlag = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "WTLoginRspBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(7, IsRequired = false, Name = "WTLoginImgRespInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public WTLoginImgRespInfo WTLoginImgRespInfo
		{
			get
			{
				return this._WTLoginImgRespInfo;
			}
			set
			{
				this._WTLoginImgRespInfo = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "WxVerifyCodeRespInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public WxVerifyCodeRespInfo WxVerifyCodeRespInfo
		{
			get
			{
				return this._WxVerifyCodeRespInfo;
			}
			set
			{
				this._WxVerifyCodeRespInfo = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "CliDBEncryptKey", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(10, IsRequired = false, Name = "CliDBEncryptInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(11, IsRequired = false, Name = "AuthKey", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(12, IsRequired = false, Name = "A2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(14, IsRequired = false, Name = "ApplyBetaUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(15, IsRequired = false, Name = "ShowStyle", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(16, IsRequired = false, Name = "AuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(17, IsRequired = false, Name = "NewVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(18, IsRequired = false, Name = "UpdateFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint UpdateFlag
		{
			get
			{
				return this._UpdateFlag;
			}
			set
			{
				this._UpdateFlag = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "AuthResultFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AuthResultFlag
		{
			get
			{
				return this._AuthResultFlag;
			}
			set
			{
				this._AuthResultFlag = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "FSURL", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
