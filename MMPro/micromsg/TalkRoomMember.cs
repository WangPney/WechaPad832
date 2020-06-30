using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TalkRoomMember")]
	[Serializable]
	public class TalkRoomMember : IExtensible
	{
		private int _MemberID;

		private string _UserName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MemberID", DataFormat = DataFormat.TwosComplement)]
		public int MemberID
		{
			get
			{
				return this._MemberID;
			}
			set
			{
				this._MemberID = value;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
