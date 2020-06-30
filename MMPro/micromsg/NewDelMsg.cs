using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "NewDelMsg")]
	[Serializable]
	public class NewDelMsg : IExtensible
	{
		private string _FromUserName = "";

		private string _ToUserName = "";

		private int _MsgId;

		private uint _MsgType;

		private long _NewMsgId = 0L;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "FromUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FromUserName
		{
			get
			{
				return this._FromUserName;
			}
			set
			{
				this._FromUserName = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ToUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ToUserName
		{
			get
			{
				return this._ToUserName;
			}
			set
			{
				this._ToUserName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public int MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "MsgType", DataFormat = DataFormat.TwosComplement)]
		public uint MsgType
		{
			get
			{
				return this._MsgType;
			}
			set
			{
				this._MsgType = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public long NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
