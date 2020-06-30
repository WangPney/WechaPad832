using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PreparePurchaseResponse")]
	[Serializable]
	public class PreparePurchaseResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _BillNo = "";

		private string _TradeToken4TenPay = "";

		private string _Partner4TenPay = "";

		private string _Sign4TenPay = "";

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

		[ProtoMember(2, IsRequired = false, Name = "BillNo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "TradeToken4TenPay", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TradeToken4TenPay
		{
			get
			{
				return this._TradeToken4TenPay;
			}
			set
			{
				this._TradeToken4TenPay = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Partner4TenPay", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Partner4TenPay
		{
			get
			{
				return this._Partner4TenPay;
			}
			set
			{
				this._Partner4TenPay = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Sign4TenPay", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Sign4TenPay
		{
			get
			{
				return this._Sign4TenPay;
			}
			set
			{
				this._Sign4TenPay = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
