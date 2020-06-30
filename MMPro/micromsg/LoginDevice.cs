using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LoginDevice")]
	[Serializable]
	public class LoginDevice : IExtensible
	{
		private string _devicename = "";

		private string _devicetype = "";

		private uint _lasttime;

		private string _uuid = "";

		private IExtension extensionObject;

		[ProtoMember(2, IsRequired = false, Name = "devicename", DataFormat = DataFormat.Default), DefaultValue("")]
		public string devicename
		{
			get
			{
				return this._devicename;
			}
			set
			{
				this._devicename = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "devicetype", DataFormat = DataFormat.Default), DefaultValue("")]
		public string devicetype
		{
			get
			{
				return this._devicetype;
			}
			set
			{
				this._devicetype = value;
			}
		}

		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string uuid
		{
			get
			{
				return this._uuid;
			}
			set
			{
				this._uuid = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "lasttime", DataFormat = DataFormat.TwosComplement)]
		public uint lasttime
		{
			get
			{
				return this._lasttime;
			}
			set
			{
				this._lasttime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
