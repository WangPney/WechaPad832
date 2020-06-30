using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetProductDetailResponse")]
	[Serializable]
	public class GetProductDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ProductInfo = "";

		private int _RetCode = 0;

		private string _RetMsg = "";

		private string _RecommendInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ProductInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductInfo
		{
			get
			{
				return this._ProductInfo;
			}
			set
			{
				this._ProductInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "RetCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int RetCode
		{
			get
			{
				return this._RetCode;
			}
			set
			{
				this._RetCode = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "RetMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RetMsg
		{
			get
			{
				return this._RetMsg;
			}
			set
			{
				this._RetMsg = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "RecommendInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RecommendInfo
		{
			get
			{
				return this._RecommendInfo;
			}
			set
			{
				this._RecommendInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
