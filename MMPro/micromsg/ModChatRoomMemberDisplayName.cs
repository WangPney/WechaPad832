using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModChatRoomMemberDisplayName")]
	[Serializable]
	public class ModChatRoomMemberDisplayName : IExtensible
	{
		private string _ChatRoomName = "";

		private string _UserName = "";

		private string _DisplayName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ChatRoomName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "DisplayName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				this._DisplayName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
