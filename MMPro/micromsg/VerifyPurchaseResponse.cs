using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyPurchaseResponse")]
	[Serializable]
	public class VerifyPurchaseResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _SeriesID = "";

		private uint _BizType;

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

		[ProtoMember(2, IsRequired = false, Name = "SeriesID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SeriesID
		{
			get
			{
				return this._SeriesID;
			}
			set
			{
				this._SeriesID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "BizType", DataFormat = DataFormat.TwosComplement)]
		public uint BizType
		{
			get
			{
				return this._BizType;
			}
			set
			{
				this._BizType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
