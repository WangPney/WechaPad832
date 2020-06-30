using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetNBSDetailResponse")]
	[Serializable]
	public class GetNBSDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _DetailInfo = "";

		private string _CardInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "DetailInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DetailInfo
		{
			get
			{
				return this._DetailInfo;
			}
			set
			{
				this._DetailInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "CardInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CardInfo
		{
			get
			{
				return this._CardInfo;
			}
			set
			{
				this._CardInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
