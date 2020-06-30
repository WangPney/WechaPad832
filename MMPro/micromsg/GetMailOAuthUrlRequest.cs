using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetMailOAuthUrlRequest")]
	[Serializable]
	public class GetMailOAuthUrlRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _MailAccount = "";

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

		[ProtoMember(2, IsRequired = false, Name = "MailAccount", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MailAccount
		{
			get
			{
				return this._MailAccount;
			}
			set
			{
				this._MailAccount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
