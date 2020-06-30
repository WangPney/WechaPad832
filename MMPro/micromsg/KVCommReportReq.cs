using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "KVCommReportReq")]
	[Serializable]
	public class KVCommReportReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Bin;

		private SKBuiltinBuffer_t _KVBuffer;

		private SKBuiltinBuffer_t _RandomEncryKey = null;

		private SKBuiltinBuffer_t _UUID = null;

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

		[ProtoMember(2, IsRequired = true, Name = "Bin", DataFormat = DataFormat.TwosComplement)]
		public uint Bin
		{
			get
			{
				return this._Bin;
			}
			set
			{
				this._Bin = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "KVBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KVBuffer
		{
			get
			{
				return this._KVBuffer;
			}
			set
			{
				this._KVBuffer = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "RandomEncryKey", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(5, IsRequired = false, Name = "UUID", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t UUID
		{
			get
			{
				return this._UUID;
			}
			set
			{
				this._UUID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
