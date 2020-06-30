using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PatternLockBuffer")]
	[Serializable]
	public class PatternLockBuffer : IExtensible
	{
		private uint _uin = 0u;

		private uint _version = 0u;

		private SKBuiltinBuffer_t _svrpatternhash = null;

		private uint _lockstatus = 0u;

		private SKBuiltinBuffer_t _sign = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "uin", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint uin
		{
			get
			{
				return this._uin;
			}
			set
			{
				this._uin = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint version
		{
			get
			{
				return this._version;
			}
			set
			{
				this._version = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "svrpatternhash", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t svrpatternhash
		{
			get
			{
				return this._svrpatternhash;
			}
			set
			{
				this._svrpatternhash = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "lockstatus", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint lockstatus
		{
			get
			{
				return this._lockstatus;
			}
			set
			{
				this._lockstatus = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "sign", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t sign
		{
			get
			{
				return this._sign;
			}
			set
			{
				this._sign = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
