using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionDescRequest")]
	[Serializable]
	public class GetEmotionDescRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ProductID = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
