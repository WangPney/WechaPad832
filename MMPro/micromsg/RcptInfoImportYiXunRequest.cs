using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoImportYiXunRequest")]
	[Serializable]
	public class RcptInfoImportYiXunRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _qq;

		private SKBuiltinBuffer_t _A2Key = null;

		private SKBuiltinBuffer_t _NewA2Key = null;

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

		[ProtoMember(2, IsRequired = true, Name = "qq", DataFormat = DataFormat.TwosComplement)]
		public uint qq
		{
			get
			{
				return this._qq;
			}
			set
			{
				this._qq = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "A2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t A2Key
		{
			get
			{
				return this._A2Key;
			}
			set
			{
				this._A2Key = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "NewA2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t NewA2Key
		{
			get
			{
				return this._NewA2Key;
			}
			set
			{
				this._NewA2Key = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
