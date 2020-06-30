using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetWeChatOutCouponsResponse")]
	[Serializable]
	public class GetWeChatOutCouponsResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _Coupons = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Coupons", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Coupons
		{
			get
			{
				return this._Coupons;
			}
			set
			{
				this._Coupons = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
