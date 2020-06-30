using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LbsRoomMemberRequest")]
	[Serializable]
	public class LbsRoomMemberRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _RoomName = "";

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

		[ProtoMember(2, IsRequired = false, Name = "RoomName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RoomName
		{
			get
			{
				return this._RoomName;
			}
			set
			{
				this._RoomName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
