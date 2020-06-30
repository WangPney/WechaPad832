using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "OnlineInfo")]
	[Serializable]
	public class OnlineInfo : IExtensible
	{
		private uint _DeviceType;

		private byte[] _DeviceID = null;

		private string _WordingXML = "";

		private SKBuiltinBuffer_t _ClientKey;

		private uint _OnlineStatus;

		private uint _DeviceHelperType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "DeviceType", DataFormat = DataFormat.TwosComplement)]
		public uint DeviceType
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

		[ProtoMember(2, IsRequired = false, Name = "DeviceID", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] DeviceID
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

		[ProtoMember(3, IsRequired = false, Name = "WordingXML", DataFormat = DataFormat.Default), DefaultValue("")]
		public string WordingXML
		{
			get
			{
				return this._WordingXML;
			}
			set
			{
				this._WordingXML = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ClientKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ClientKey
		{
			get
			{
				return this._ClientKey;
			}
			set
			{
				this._ClientKey = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "OnlineStatus", DataFormat = DataFormat.TwosComplement)]
		public uint OnlineStatus
		{
			get
			{
				return this._OnlineStatus;
			}
			set
			{
				this._OnlineStatus = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "DeviceHelperType", DataFormat = DataFormat.TwosComplement)]
		public uint DeviceHelperType
		{
			get
			{
				return this._DeviceHelperType;
			}
			set
			{
				this._DeviceHelperType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
