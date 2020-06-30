using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLbsLifeDetailRequest")]
	[Serializable]
	public class GetLbsLifeDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _BusinessId = "";

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

		[ProtoMember(2, IsRequired = false, Name = "BusinessId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BusinessId
		{
			get
			{
				return this._BusinessId;
			}
			set
			{
				this._BusinessId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
