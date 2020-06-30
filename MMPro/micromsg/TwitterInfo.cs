using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TwitterInfo")]
	[Serializable]
	public class TwitterInfo : IExtensible
	{
		private string _Oauth_Token = "";

		private string _Oauth_Token_Secret = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Oauth_Token", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Oauth_Token
		{
			get
			{
				return this._Oauth_Token;
			}
			set
			{
				this._Oauth_Token = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Oauth_Token_Secret", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Oauth_Token_Secret
		{
			get
			{
				return this._Oauth_Token_Secret;
			}
			set
			{
				this._Oauth_Token_Secret = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
