using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadCardImgResponse")]
	[Serializable]
	public class UploadCardImgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _StartPos;

		private uint _TotalLen;

		private string _ClientId = "";

		private string _CardImgUrl = "";

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

		[ProtoMember(2, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public uint StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ClientId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				this._ClientId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "CardImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CardImgUrl
		{
			get
			{
				return this._CardImgUrl;
			}
			set
			{
				this._CardImgUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
