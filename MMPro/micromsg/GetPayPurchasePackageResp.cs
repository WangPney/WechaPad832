using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetPayPurchasePackageResp")]
	[Serializable]
	public class GetPayPurchasePackageResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _Package = "";

		private string _ExtInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Package", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Package
		{
			get
			{
				return this._Package;
			}
			set
			{
				this._Package = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
