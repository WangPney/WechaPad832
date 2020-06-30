using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipInviteReq")]
	[Serializable]
	public class VoipInviteReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FromUsername = "";

		private int _InviteUserCount;

		private readonly List<SKBuiltinString_t> _ToUsernameList = new List<SKBuiltinString_t>();

		private VoipRelayData _PeerId;

		private VoipRelayData _CapInfo;

		private int _NetType;

		private int _CallType;

		private int _RoomId = 0;

		private long _RoomKey = 0L;

		private uint _InviteType = 0u;

		private ulong _Timestamp64 = 0uL;

		private int _HDVideo = 0;

		private uint _InviteId = 0u;

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

		[ProtoMember(3, IsRequired = true, Name = "InviteUserCount", DataFormat = DataFormat.TwosComplement)]
		public int InviteUserCount
		{
			get
			{
				return this._InviteUserCount;
			}
			set
			{
				this._InviteUserCount = value;
			}
		}

		[ProtoMember(4, Name = "ToUsernameList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> ToUsernameList
		{
			get
			{
				return this._ToUsernameList;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "PeerId", DataFormat = DataFormat.Default)]
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

		[ProtoMember(7, IsRequired = true, Name = "CapInfo", DataFormat = DataFormat.Default)]
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

		[ProtoMember(9, IsRequired = true, Name = "CallType", DataFormat = DataFormat.TwosComplement)]
		public int CallType
		{
			get
			{
				return this._CallType;
			}
			set
			{
				this._CallType = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "RoomId", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(11, IsRequired = false, Name = "RoomKey", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(12, IsRequired = false, Name = "InviteType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint InviteType
		{
			get
			{
				return this._InviteType;
			}
			set
			{
				this._InviteType = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "Timestamp64", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
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

		[ProtoMember(14, IsRequired = false, Name = "HDVideo", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int HDVideo
		{
			get
			{
				return this._HDVideo;
			}
			set
			{
				this._HDVideo = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "InviteId", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint InviteId
		{
			get
			{
				return this._InviteId;
			}
			set
			{
				this._InviteId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
