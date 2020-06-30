using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipGetRoomInfoReq")]
	[Serializable]
	public class VoipGetRoomInfoReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _RoomId;

		private long _RoomKey;

		private string _CallerUserName = "";

		private uint _Type = 0u;

		private ulong _Timestamp64 = 0uL;

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

		[ProtoMember(2, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
		public int RoomId
		{
			get
			{
				return this._RoomId;
			}
			set
			{
				this._RoomId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
		public long RoomKey
		{
			get
			{
				return this._RoomKey;
			}
			set
			{
				this._RoomKey = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "CallerUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CallerUserName
		{
			get
			{
				return this._CallerUserName;
			}
			set
			{
				this._CallerUserName = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Type
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

		[ProtoMember(6, IsRequired = false, Name = "Timestamp64", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong Timestamp64
		{
			get
			{
				return this._Timestamp64;
			}
			set
			{
				this._Timestamp64 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
