using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCardListFromAppResponse")]
	[Serializable]
	public class GetCardListFromAppResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _json_ret = "";

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

		[ProtoMember(2, IsRequired = false, Name = "json_ret", DataFormat = DataFormat.Default), DefaultValue("")]
		public string json_ret
		{
			get
			{
				return this._json_ret;
			}
			set
			{
				this._json_ret = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
