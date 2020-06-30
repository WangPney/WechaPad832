using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TranslateOrgMsg")]
	[Serializable]
	public class TranslateOrgMsg : IExtensible
	{
		private uint _ClientMsgID;

		private string _TextMsg = "";

		private string _ChatRoomID = "";

		private uint _Scene = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ClientMsgID", DataFormat = DataFormat.TwosComplement)]
		public uint ClientMsgID
		{
			get
			{
				return this._ClientMsgID;
			}
			set
			{
				this._ClientMsgID = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "TextMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TextMsg
		{
			get
			{
				return this._TextMsg;
			}
			set
			{
				this._TextMsg = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ChatRoomID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomID
		{
			get
			{
				return this._ChatRoomID;
			}
			set
			{
				this._ChatRoomID = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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
