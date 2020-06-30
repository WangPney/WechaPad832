using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BuiltinIP")]
	[Serializable]
	public class BuiltinIP : IExtensible
	{
		private uint _type;

		private uint _port;

		private byte[] _IP = null;

		private byte[] _Domain = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "port", DataFormat = DataFormat.TwosComplement)]
		public uint port
		{
			get
			{
				return this._port;
			}
			set
			{
				this._port = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "IP", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] IP
		{
			get
			{
				return this._IP;
			}
			set
			{
				this._IP = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Domain", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] Domain
		{
			get
			{
				return this._Domain;
			}
			set
			{
				this._Domain = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
