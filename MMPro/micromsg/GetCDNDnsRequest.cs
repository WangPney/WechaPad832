using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCDNDnsRequest")]
	[Serializable]
	public class GetCDNDnsRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientIP = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ClientIP", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientIP
		{
			get
			{
				return this._ClientIP;
			}
			set
			{
				this._ClientIP = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
