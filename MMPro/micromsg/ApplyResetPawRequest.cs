using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ApplyResetPawRequest")]
	[Serializable]
	public class ApplyResetPawRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _Type;

		private string _ResetInfo = "";

		private uint _GetMethod = 0u;

		private SKBuiltinBuffer_t _RandomEncryKey = null;

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

		[ProtoMember(2, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "ResetInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ResetInfo
		{
			get
			{
				return this._ResetInfo;
			}
			set
			{
				this._ResetInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "GetMethod", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GetMethod
		{
			get
			{
				return this._GetMethod;
			}
			set
			{
				this._GetMethod = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "RandomEncryKey", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t RandomEncryKey
		{
			get
			{
				return this._RandomEncryKey;
			}
			set
			{
				this._RandomEncryKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
