using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PushLoginURLResponse")]
	[Serializable]
	public class PushLoginURLResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _UUID = "";

		private SKBuiltinBuffer_t _NotifyKey;

		private uint _CheckTime;

		private uint _ExpiredTime;

		private string _BlueToothBroadCastUUID = "";

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

		[ProtoMember(2, IsRequired = false, Name = "UUID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UUID
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

		[ProtoMember(3, IsRequired = true, Name = "NotifyKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t NotifyKey
		{
			get
			{
				return this._NotifyKey;
			}
			set
			{
				this._NotifyKey = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "CheckTime", DataFormat = DataFormat.TwosComplement)]
		public uint CheckTime
		{
			get
			{
				return this._CheckTime;
			}
			set
			{
				this._CheckTime = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ExpiredTime", DataFormat = DataFormat.TwosComplement)]
		public uint ExpiredTime
		{
			get
			{
				return this._ExpiredTime;
			}
			set
			{
				this._ExpiredTime = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "BlueToothBroadCastUUID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BlueToothBroadCastUUID
		{
			get
			{
				return this._BlueToothBroadCastUUID;
			}
			set
			{
				this._BlueToothBroadCastUUID = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "BlueToothBroadCastContent", DataFormat = DataFormat.Default), DefaultValue(null)]
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
