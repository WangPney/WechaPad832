using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetRegStyleRequest")]
	[Serializable]
	public class GetRegStyleRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientSeqID = "";

		private SKBuiltinBuffer_t _RandomEncryKey;

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

		[ProtoMember(2, IsRequired = false, Name = "ClientSeqID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientSeqID
		{
			get
			{
				return this._ClientSeqID;
			}
			set
			{
				this._ClientSeqID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RandomEncryKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RandomEncryKey
		{
			get
			{
				return this._RandomEncryKey;
			}
			set
			{
				this._RandomEncryKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
