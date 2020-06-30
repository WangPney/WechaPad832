using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TransferChatRoomOwnerRequest")]
	[Serializable]
	public class TransferChatRoomOwnerRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ChatRoomName = "";

		private string _NewOwnerUserName = "";

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

		[ProtoMember(3, IsRequired = false, Name = "NewOwnerUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NewOwnerUserName
		{
			get
			{
				return this._NewOwnerUserName;
			}
			set
			{
				this._NewOwnerUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
