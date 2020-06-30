using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BlackBerryUnRegRequest")]
	[Serializable]
	public class BlackBerryUnRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Pin = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Pin", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pin
		{
			get
			{
				return this._Pin;
			}
			set
			{
				this._Pin = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
