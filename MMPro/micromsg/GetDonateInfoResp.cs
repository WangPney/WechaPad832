using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetDonateInfoResp")]
	[Serializable]
	public class GetDonateInfoResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _DonateInfo = "";

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

		[ProtoMember(3, IsRequired = false, Name = "DonateInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DonateInfo
		{
			get
			{
				return this._DonateInfo;
			}
			set
			{
				this._DonateInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
