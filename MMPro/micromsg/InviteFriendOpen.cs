using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "InviteFriendOpen")]
	[Serializable]
	public class InviteFriendOpen : IExtensible
	{
		private string _UserName = "";

		private uint _FriendType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = true, Name = "FriendType", DataFormat = DataFormat.TwosComplement)]
		public uint FriendType
		{
			get
			{
				return this._FriendType;
			}
			set
			{
				this._FriendType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
