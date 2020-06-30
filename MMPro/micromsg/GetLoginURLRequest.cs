using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLoginURLRequest")]
	[Serializable]
	public class GetLoginURLRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _UUID = "";

		private byte[] _FromDeviceID = null;

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

		[ProtoMember(2, IsRequired = false, Name = "UUID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UUID
		{
			get
			{
				return this._UUID;
			}
			set
			{
				this._UUID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "FromDeviceID", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] FromDeviceID
		{
			get
			{
				return this._FromDeviceID;
			}
			set
			{
				this._FromDeviceID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
