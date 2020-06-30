using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SetChatRoomAnnouncementRequest")]
	[Serializable]
	public class SetChatRoomAnnouncementRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ChatRoomName = "";

		private string _Announcement = "";

		private uint _SetAnnouncementFlag = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "ChatRoomName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomName
		{
			get
			{
				return this._ChatRoomName;
			}
			set
			{
				this._ChatRoomName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Announcement", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Announcement
		{
			get
			{
				return this._Announcement;
			}
			set
			{
				this._Announcement = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "SetAnnouncementFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SetAnnouncementFlag
		{
			get
			{
				return this._SetAnnouncementFlag;
			}
			set
			{
				this._SetAnnouncementFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
