using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetBizIapDetailResponse")]
	[Serializable]
	public class GetBizIapDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _DetailBuff = "";

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

		[ProtoMember(2, IsRequired = false, Name = "DetailBuff", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DetailBuff
		{
			get
			{
				return this._DetailBuff;
			}
			set
			{
				this._DetailBuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
