using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchHardDeviceRequest")]
	[Serializable]
	public class SearchHardDeviceRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _HardDeviceQRCode = "";

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

		[ProtoMember(2, IsRequired = false, Name = "HardDeviceQRCode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string HardDeviceQRCode
		{
			get
			{
				return this._HardDeviceQRCode;
			}
			set
			{
				this._HardDeviceQRCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
