using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PreparePurchaseRequest")]
	[Serializable]
	public class PreparePurchaseRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ProductID = "";

		private string _Price = "";

		private string _CurrencyType = "";

		private uint _PayType;

		private string _ExtInfo = "";

		private uint _Quantity = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Price", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Price
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

		[ProtoMember(4, IsRequired = false, Name = "CurrencyType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CurrencyType
		{
			get
			{
				return this._CurrencyType;
			}
			set
			{
				this._CurrencyType = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "PayType", DataFormat = DataFormat.TwosComplement)]
		public uint PayType
		{
			get
			{
				return this._PayType;
			}
			set
			{
				this._PayType = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(8, IsRequired = false, Name = "Quantity", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				this._Quantity = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
