using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinBuffer_t")]
	[Serializable]
	public class SKBuiltinBuffer_t : IExtensible
	{
		private uint _iLen;

		private byte[] _Buffer = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "iLen", DataFormat = DataFormat.TwosComplement)]
		public uint iLen
		{
			get
			{
				return this._iLen;
			}
			set
			{
				this._iLen = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Buffer", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
