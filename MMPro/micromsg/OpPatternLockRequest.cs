using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "OpPatternLockRequest")]
	[Serializable]
	public class OpPatternLockRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _cmd = 0u;

		private SKBuiltinBuffer_t _nowpatternhash = null;

		private SKBuiltinBuffer_t _newpatternhash = null;

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

		[ProtoMember(2, IsRequired = false, Name = "cmd", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint cmd
		{
			get
			{
				return this._cmd;
			}
			set
			{
				this._cmd = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "nowpatternhash", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t nowpatternhash
		{
			get
			{
				return this._nowpatternhash;
			}
			set
			{
				this._nowpatternhash = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "newpatternhash", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t newpatternhash
		{
			get
			{
				return this._newpatternhash;
			}
			set
			{
				this._newpatternhash = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
