using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "WinphoneUnRegRequest")]
	[Serializable]
	public class WinphoneUnRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Uri = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Uri", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Uri
		{
			get
			{
				return this._Uri;
			}
			set
			{
				this._Uri = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
