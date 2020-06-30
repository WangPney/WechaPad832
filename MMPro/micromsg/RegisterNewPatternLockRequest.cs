using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RegisterNewPatternLockRequest")]
	[Serializable]
	public class RegisterNewPatternLockRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _paytoken = null;

		private SKBuiltinBuffer_t _patternhash = null;

		private uint _cmd = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "paytoken", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t paytoken
		{
			get
			{
				return this._paytoken;
			}
			set
			{
				this._paytoken = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "patternhash", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t patternhash
		{
			get
			{
				return this._patternhash;
			}
			set
			{
				this._patternhash = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "cmd", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
