using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipSyncReq")]
	[Serializable]
	public class VoipSyncReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FromUsername = "";

		private int _RoomId;

		private SKBuiltinBuffer_t _KeyBuf;

		private VoipCmdList _OpLog;

		private long _RoomKey;

		private int _Selector;

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

		[ProtoMember(2, IsRequired = false, Name = "FromUsername", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FromUsername
		{
			get
			{
				return this._FromUsername;
			}
			set
			{
				this._FromUsername = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = true, Name = "KeyBuf", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = true, Name = "OpLog", DataFormat = DataFormat.Default)]
		public VoipCmdList OpLog
		{
			get
			{
				return this._OpLog;
			}
			set
			{
				this._OpLog = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = true, Name = "Selector", DataFormat = DataFormat.TwosComplement)]
		public int Selector
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

		[ProtoMember(8, IsRequired = false, Name = "Timestamp64", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
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
