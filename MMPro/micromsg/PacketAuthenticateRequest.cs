using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PacketAuthenticateRequest")]
	[Serializable]
	public class PacketAuthenticateRequest : IExtensible
	{
		private int _Step;

		private string _ID;

		private byte[] _Data = null;

		private int _Version = 0;

		private int _Type = 0;

		private int _SupportExt = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Step", DataFormat = DataFormat.TwosComplement)]
		public int Step
		{
			get
			{
				return this._Step;
			}
			set
			{
				this._Step = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ID", DataFormat = DataFormat.Default)]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Data", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Version", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				this._Version = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "SupportExt", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int SupportExt
		{
			get
			{
				return this._SupportExt;
			}
			set
			{
				this._SupportExt = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
