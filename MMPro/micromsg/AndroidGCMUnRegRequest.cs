using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AndroidGCMUnRegRequest")]
	[Serializable]
	public class AndroidGCMUnRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Token = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Token", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				this._Token = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
