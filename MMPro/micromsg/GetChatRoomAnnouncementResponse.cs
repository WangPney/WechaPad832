using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetChatRoomAnnouncementResponse")]
	[Serializable]
	public class GetChatRoomAnnouncementResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _Announcement = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Announcement", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
