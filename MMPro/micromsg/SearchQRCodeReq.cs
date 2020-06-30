using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchQRCodeReq")]
	[Serializable]
	public class SearchQRCodeReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _QRCode = "";

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

		[ProtoMember(2, IsRequired = false, Name = "QRCode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string QRCode
		{
			get
			{
				return this._QRCode;
			}
			set
			{
				this._QRCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
