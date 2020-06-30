using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "HeartBeatRequest")]
	[Serializable]
	public class HeartBeatRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _TimeStamp;

		private SKBuiltinBuffer_t _KeyBuf = null;

		private SKBuiltinBuffer_t _BlueToothBroadCastContent = null;

		private uint _Scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "KeyBuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t KeyBuf
		{
			get
			{
				return this._KeyBuf;
			}
			set
			{
				this._KeyBuf = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BlueToothBroadCastContent", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t BlueToothBroadCastContent
		{
			get
			{
				return this._BlueToothBroadCastContent;
			}
			set
			{
				this._BlueToothBroadCastContent = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
