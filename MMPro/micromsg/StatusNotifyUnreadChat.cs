using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "StatusNotifyUnreadChat")]
	[Serializable]
	public class StatusNotifyUnreadChat : IExtensible
	{
		private string _UserName = "";

		private uint _LastReadTime;

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

		[ProtoMember(2, IsRequired = true, Name = "LastReadTime", DataFormat = DataFormat.TwosComplement)]
		public uint LastReadTime
		{
			get
			{
				return this._LastReadTime;
			}
			set
			{
				this._LastReadTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
