using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetAddressResponse")]
	[Serializable]
	public class GetAddressResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _RetJson = "";

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

		[ProtoMember(2, IsRequired = false, Name = "RetJson", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RetJson
		{
			get
			{
				return this._RetJson;
			}
			set
			{
				this._RetJson = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
