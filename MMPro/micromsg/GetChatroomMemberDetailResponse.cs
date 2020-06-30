using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetChatroomMemberDetailResponse")]
	[Serializable]
	public class GetChatroomMemberDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ChatroomUserName = "";

		private uint _ServerVersion;

		private ChatRoomMemberData _NewChatroomData;

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

		[ProtoMember(2, IsRequired = false, Name = "ChatroomUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatroomUserName
		{
			get
			{
				return this._ChatroomUserName;
			}
			set
			{
				this._ChatroomUserName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ServerVersion", DataFormat = DataFormat.TwosComplement)]
		public uint ServerVersion
		{
			get
			{
				return this._ServerVersion;
			}
			set
			{
				this._ServerVersion = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "NewChatroomData", DataFormat = DataFormat.Default)]
		public ChatRoomMemberData NewChatroomData
		{
			get
			{
				return this._NewChatroomData;
			}
			set
			{
				this._NewChatroomData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
