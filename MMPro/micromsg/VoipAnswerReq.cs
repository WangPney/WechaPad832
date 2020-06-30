using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipAnswerReq")]
	[Serializable]
	public class VoipAnswerReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FromUsername = "";

		private int _RoomId;

		private int _Answer;

		private VoipRelayData _PeerId = null;

		private VoipRelayData _CapInfo = null;

		private long _RoomKey;

		private int _NetType;

		private ulong _Timestamp64 = 0uL;

		private int _OnlyAudio = 0;

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

		[ProtoMember(4, IsRequired = true, Name = "Answer", DataFormat = DataFormat.TwosComplement)]
		public int Answer
		{
			get
			{
				return this._Answer;
			}
			set
			{
				this._Answer = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "PeerId", DataFormat = DataFormat.Default), DefaultValue(null)]
		public VoipRelayData PeerId
		{
			get
			{
				return this._PeerId;
			}
			set
			{
				this._PeerId = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "CapInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public VoipRelayData CapInfo
		{
			get
			{
				return this._CapInfo;
			}
			set
			{
				this._CapInfo = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = true, Name = "NetType", DataFormat = DataFormat.TwosComplement)]
		public int NetType
		{
			get
			{
				return this._NetType;
			}
			set
			{
				this._NetType = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "Timestamp64", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
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

		[ProtoMember(10, IsRequired = false, Name = "OnlyAudio", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int OnlyAudio
		{
			get
			{
				return this._OnlyAudio;
			}
			set
			{
				this._OnlyAudio = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
