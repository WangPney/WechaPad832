using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PatternLockInfo")]
	[Serializable]
	public class PatternLockInfo : IExtensible
	{
		private uint _PatternVersion = 0u;

		private SKBuiltinBuffer_t _Sign = null;

		private uint _LockStatus = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "PatternVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PatternVersion
		{
			get
			{
				return this._PatternVersion;
			}
			set
			{
				this._PatternVersion = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Sign", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Sign
		{
			get
			{
				return this._Sign;
			}
			set
			{
				this._Sign = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "LockStatus", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LockStatus
		{
			get
			{
				return this._LockStatus;
			}
			set
			{
				this._LockStatus = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
