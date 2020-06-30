using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ExitTrackRoomRequest")]
	[Serializable]
	public class ExitTrackRoomRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _TrackRoomID = "";

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

		[ProtoMember(3, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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
