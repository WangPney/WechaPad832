using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetIosExtensionKeyResponse")]
	[Serializable]
	public class GetIosExtensionKeyResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _Key;

		private ExtSession _ExtensionSession = null;

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

		[ProtoMember(2, IsRequired = true, Name = "Key", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				this._Key = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ExtensionSession", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ExtSession ExtensionSession
		{
			get
			{
				return this._ExtensionSession;
			}
			set
			{
				this._ExtensionSession = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
