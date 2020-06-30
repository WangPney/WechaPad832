using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "WTLoginImgRespInfo")]
	[Serializable]
	public class WTLoginImgRespInfo : IExtensible
	{
		private string _ImgEncryptKey = "";

		private SKBuiltinBuffer_t _KSid;

		private string _ImgSid = "";

		private SKBuiltinBuffer_t _ImgBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ImgEncryptKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ImgEncryptKey
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

		[ProtoMember(2, IsRequired = true, Name = "KSid", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "ImgSid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ImgSid
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

		[ProtoMember(4, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
