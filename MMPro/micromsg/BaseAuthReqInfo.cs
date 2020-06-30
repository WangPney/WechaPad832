using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BaseAuthReqInfo")]
	[Serializable]
	public class BaseAuthReqInfo : IExtensible
	{
		private SKBuiltinBuffer_t _WTLoginReqBuff = null;

		private WTLoginImgReqInfo _WTLoginImgReqInfo = null;

		private WxVerifyCodeReqInfo _WxVerifyCodeReqInfo = null;

		private SKBuiltinBuffer_t _CliDBEncryptKey = null;

		private SKBuiltinBuffer_t _CliDBEncryptInfo = null;

		private uint _AuthReqFlag = 0u;

		private string _AuthTicket = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "WTLoginReqBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t WTLoginReqBuff
		{
			get
			{
				return this._WTLoginReqBuff;
			}
			set
			{
				this._WTLoginReqBuff = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "WTLoginImgReqInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public WTLoginImgReqInfo WTLoginImgReqInfo
		{
			get
			{
				return this._WTLoginImgReqInfo;
			}
			set
			{
				this._WTLoginImgReqInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "WxVerifyCodeReqInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public WxVerifyCodeReqInfo WxVerifyCodeReqInfo
		{
			get
			{
				return this._WxVerifyCodeReqInfo;
			}
			set
			{
				this._WxVerifyCodeReqInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "CliDBEncryptKey", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(5, IsRequired = false, Name = "CliDBEncryptInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(6, IsRequired = false, Name = "AuthReqFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AuthReqFlag
		{
			get
			{
				return this._AuthReqFlag;
			}
			set
			{
				this._AuthReqFlag = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "AuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
