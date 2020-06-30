using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "HeartBeatResponse")]
	[Serializable]
	public class HeartBeatResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _NextTime;

		private uint _Selector = 0u;

		private SKBuiltinBuffer_t _BlueToothBroadCastContent = null;

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

		[ProtoMember(2, IsRequired = true, Name = "NextTime", DataFormat = DataFormat.TwosComplement)]
		public uint NextTime
		{
			get
			{
				return this._NextTime;
			}
			set
			{
				this._NextTime = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Selector", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Selector
		{
			get
			{
				return this._Selector;
			}
			set
			{
				this._Selector = value;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
