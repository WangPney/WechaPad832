using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AddChatRoomDonateRecordReq")]
	[Serializable]
	public class AddChatRoomDonateRecordReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ChatRoomName = "";

		private string _TransID = "";

		private string _Title = "";

		private string _WebUrl = "";

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

		[ProtoMember(3, IsRequired = false, Name = "TransID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TransID
		{
			get
			{
				return this._TransID;
			}
			set
			{
				this._TransID = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "WebUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string WebUrl
		{
			get
			{
				return this._WebUrl;
			}
			set
			{
				this._WebUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
