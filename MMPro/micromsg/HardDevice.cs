using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "HardDevice")]
	[Serializable]
	public class HardDevice : IExtensible
	{
		private string _DeviceType = "";

		private string _DeviceID = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "DeviceType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceType
		{
			get
			{
				return this._DeviceType;
			}
			set
			{
				this._DeviceType = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "DeviceID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				this._DeviceID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
