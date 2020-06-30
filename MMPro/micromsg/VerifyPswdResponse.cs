using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyPswdResponse")]
	[Serializable]
	public class VerifyPswdResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinString_t _ImgSid;

		private SKBuiltinBuffer_t _ImgBuf;

		private string _Ticket = "";

		private SKBuiltinString_t _ImgEncryptKey = null;

		private SKBuiltinBuffer_t _A2Key = null;

		private SKBuiltinBuffer_t _KSid = null;

		private string _AuthKey = "";

		private SKBuiltinBuffer_t _WTLoginRspBuff = null;

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

		[ProtoMember(2, IsRequired = true, Name = "ImgSid", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "Ticket", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(5, IsRequired = false, Name = "ImgEncryptKey", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(6, IsRequired = false, Name = "A2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(7, IsRequired = false, Name = "KSid", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(8, IsRequired = false, Name = "AuthKey", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(9, IsRequired = false, Name = "WTLoginRspBuff", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
