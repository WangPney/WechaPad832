using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CancelPurchaseRequest")]
	[Serializable]
	public class CancelPurchaseRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ProductID = "";

		private uint _VerifyType;

		private uint _PayType;

		private string _Price = "";

		private string _CurrencyType = "";

		private string _BillNo = "";

		private uint _PayTime;

		private int _ErrorCode;

		private string _ErrorDescription = "";

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

		[ProtoMember(3, IsRequired = true, Name = "VerifyType", DataFormat = DataFormat.TwosComplement)]
		public uint VerifyType
		{
			get
			{
				return this._VerifyType;
			}
			set
			{
				this._VerifyType = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "PayType", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "Price", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(6, IsRequired = false, Name = "CurrencyType", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(7, IsRequired = false, Name = "BillNo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BillNo
		{
			get
			{
				return this._BillNo;
			}
			set
			{
				this._BillNo = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "PayTime", DataFormat = DataFormat.TwosComplement)]
		public uint PayTime
		{
			get
			{
				return this._PayTime;
			}
			set
			{
				this._PayTime = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public int ErrorCode
		{
			get
			{
				return this._ErrorCode;
			}
			set
			{
				this._ErrorCode = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "ErrorDescription", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ErrorDescription
		{
			get
			{
				return this._ErrorDescription;
			}
			set
			{
				this._ErrorDescription = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
