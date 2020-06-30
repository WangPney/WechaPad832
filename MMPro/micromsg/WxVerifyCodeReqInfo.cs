using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "WxVerifyCodeReqInfo")]
	[Serializable]
	public class WxVerifyCodeReqInfo : IExtensible
	{
		private string _VerifySignature = "";

		private string _VerifyContent = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "VerifySignature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifySignature
		{
			get
			{
				return this._VerifySignature;
			}
			set
			{
				this._VerifySignature = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "VerifyContent", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifyContent
		{
			get
			{
				return this._VerifyContent;
			}
			set
			{
				this._VerifyContent = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
