using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BizBottleInfo")]
	[Serializable]
	public class BizBottleInfo : IExtensible
	{
		private string _BottleID = "";

		private uint _MsgType;

		private string _FromUserName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "BottleID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BottleID
		{
			get
			{
				return this._BottleID;
			}
			set
			{
				this._BottleID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MsgType", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "FromUserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
