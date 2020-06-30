using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetBizIapDetailRequest")]
	[Serializable]
	public class GetBizIapDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _SerialId = "";

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

		[ProtoMember(3, IsRequired = false, Name = "SerialId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SerialId
		{
			get
			{
				return this._SerialId;
			}
			set
			{
				this._SerialId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
