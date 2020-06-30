using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RegisterNewPatternLockResponse")]
	[Serializable]
	public class RegisterNewPatternLockResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private PatternLockBuffer _patternlockbuf = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "patternlockbuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public PatternLockBuffer patternlockbuf
		{
			get
			{
				return this._patternlockbuf;
			}
			set
			{
				this._patternlockbuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
