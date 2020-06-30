using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetIosExtensionKeyRequest")]
	[Serializable]
	public class GetIosExtensionKeyRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _ExtensionSessionType = 0u;

		private byte[] _ExtensionDeviceId = null;

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

		[ProtoMember(2, IsRequired = false, Name = "ExtensionSessionType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ExtensionSessionType
		{
			get
			{
				return this._ExtensionSessionType;
			}
			set
			{
				this._ExtensionSessionType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ExtensionDeviceId", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] ExtensionDeviceId
		{
			get
			{
				return this._ExtensionDeviceId;
			}
			set
			{
				this._ExtensionDeviceId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
