using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CardShopLBSRequest")]
	[Serializable]
	public class CardShopLBSRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _card_tp_id = "";

		private float _longitude;

		private float _latitude;

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

		[ProtoMember(2, IsRequired = false, Name = "card_tp_id", DataFormat = DataFormat.Default), DefaultValue("")]
		public string card_tp_id
		{
			get
			{
				return this._card_tp_id;
			}
			set
			{
				this._card_tp_id = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "longitude", DataFormat = DataFormat.FixedSize)]
		public float longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				this._longitude = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "latitude", DataFormat = DataFormat.FixedSize)]
		public float latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				this._latitude = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
