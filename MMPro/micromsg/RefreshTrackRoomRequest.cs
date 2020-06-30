using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RefreshTrackRoomRequest")]
	[Serializable]
	public class RefreshTrackRoomRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _TrackRoomID = "";

		private int _Type;

		private UserPositionItem _UserPosition;

		private uint _TimeStamp = 0u;

		private TrackPOIItem _UserPoi = null;

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

		[ProtoMember(2, IsRequired = false, Name = "TrackRoomID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TrackRoomID
		{
			get
			{
				return this._TrackRoomID;
			}
			set
			{
				this._TrackRoomID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = true, Name = "UserPosition", DataFormat = DataFormat.Default)]
		public UserPositionItem UserPosition
		{
			get
			{
				return this._UserPosition;
			}
			set
			{
				this._UserPosition = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(6, IsRequired = false, Name = "UserPoi", DataFormat = DataFormat.Default), DefaultValue(null)]
		public TrackPOIItem UserPoi
		{
			get
			{
				return this._UserPoi;
			}
			set
			{
				this._UserPoi = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
