using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CDNUploadMsgImgPrepareResponse")]
	[Serializable]
	public class CDNUploadMsgImgPrepareResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ClientImgId = "";

		private string _FromUserName = "";

		private string _ToUserName = "";

		private uint _CreateTime;

		private ulong _NewMsgId = 0uL;

		private string _AESKey = "";

		private string _FileId = "";

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

		[ProtoMember(3, IsRequired = false, Name = "ClientImgId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientImgId
		{
			get
			{
				return this._ClientImgId;
			}
			set
			{
				this._ClientImgId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "FromUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FromUserName
		{
			get
			{
				return this._FromUserName;
			}
			set
			{
				this._FromUserName = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ToUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ToUserName
		{
			get
			{
				return this._ToUserName;
			}
			set
			{
				this._ToUserName = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
		public uint CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				this._CreateTime = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "AESKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AESKey
		{
			get
			{
				return this._AESKey;
			}
			set
			{
				this._AESKey = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "FileId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FileId
		{
			get
			{
				return this._FileId;
			}
			set
			{
				this._FileId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
