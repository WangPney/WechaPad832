using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetMailOAuthUrlResponse")]
	[Serializable]
	public class GetMailOAuthUrlResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _OAuthUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "OAuthUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OAuthUrl
		{
			get
			{
				return this._OAuthUrl;
			}
			set
			{
				this._OAuthUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
