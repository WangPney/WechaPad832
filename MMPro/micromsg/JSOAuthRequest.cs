using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "JSOAuthRequest")]
	[Serializable]
	public class JSOAuthRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private string _Url = "";

		private string _Scope = "";

		private string _Signature = "";

		private string _Signature_method = "";

		private string _TimeStamp = "";

		private string _Nonce = "";

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

		[ProtoMember(2, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scope", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Scope
		{
			get
			{
				return this._Scope;
			}
			set
			{
				this._Scope = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Signature
		{
			get
			{
				return this._Signature;
			}
			set
			{
				this._Signature = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Signature_method", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Signature_method
		{
			get
			{
				return this._Signature_method;
			}
			set
			{
				this._Signature_method = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "Nonce", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Nonce
		{
			get
			{
				return this._Nonce;
			}
			set
			{
				this._Nonce = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
