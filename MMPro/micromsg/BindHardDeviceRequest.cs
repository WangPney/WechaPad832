using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindHardDeviceRequest")]
	[Serializable]
	public class BindHardDeviceRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _BindTicket = "";

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

		[ProtoMember(4, IsRequired = false, Name = "BindTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BindTicket
		{
			get
			{
				return this._BindTicket;
			}
			set
			{
				this._BindTicket = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
