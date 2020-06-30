using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RadarChatRoomMember")]
	[Serializable]
	public class RadarChatRoomMember : IExtensible
	{
		private string _UserName = "";

		private string _AntispamTicket = "";

		private string _EncodeUserName = "";

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

		[ProtoMember(2, IsRequired = false, Name = "AntispamTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AntispamTicket
		{
			get
			{
				return this._AntispamTicket;
			}
			set
			{
				this._AntispamTicket = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "EncodeUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string EncodeUserName
		{
			get
			{
				return this._EncodeUserName;
			}
			set
			{
				this._EncodeUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
