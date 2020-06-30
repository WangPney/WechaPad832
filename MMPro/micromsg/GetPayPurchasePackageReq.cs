using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetPayPurchasePackageReq")]
	[Serializable]
	public class GetPayPurchasePackageReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Type;

		private uint _Price;

		private string _PriceType = "";

		private string _ExtInfo = "";

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

		[ProtoMember(2, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Price", DataFormat = DataFormat.TwosComplement)]
		public uint Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				this._Price = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "PriceType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PriceType
		{
			get
			{
				return this._PriceType;
			}
			set
			{
				this._PriceType = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
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
