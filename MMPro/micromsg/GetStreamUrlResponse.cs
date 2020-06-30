using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetStreamUrlResponse")]
	[Serializable]
	public class GetStreamUrlResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _StreamUrl = "";

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

		[ProtoMember(2, IsRequired = false, Name = "StreamUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StreamUrl
		{
			get
			{
				return this._StreamUrl;
			}
			set
			{
				this._StreamUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
