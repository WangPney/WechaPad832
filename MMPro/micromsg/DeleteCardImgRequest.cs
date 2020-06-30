using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DeleteCardImgRequest")]
	[Serializable]
	public class DeleteCardImgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ContactUserName = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ContactUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ContactUserName
		{
			get
			{
				return this._ContactUserName;
			}
			set
			{
				this._ContactUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
