using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UnbindMobileByQQRequest")]
	[Serializable]
	public class UnbindMobileByQQRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _UserName;

		private string _Pwd = "";

		private string _Pwd2 = "";

		private SKBuiltinString_t _ImgSid;

		private SKBuiltinString_t _ImgCode;

		private SKBuiltinString_t _ImgEncryptKey;

		private SKBuiltinBuffer_t _KSid;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "Pwd", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				this._Pwd = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Pwd2", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pwd2
		{
			get
			{
				return this._Pwd2;
			}
			set
			{
				this._Pwd2 = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ImgSid", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = true, Name = "ImgCode", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ImgCode
		{
			get
			{
				return this._ImgCode;
			}
			set
			{
				this._ImgCode = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "ImgEncryptKey", DataFormat = DataFormat.Default)]
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

		[ProtoMember(8, IsRequired = true, Name = "KSid", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
