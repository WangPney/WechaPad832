using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipStatusItem")]
	[Serializable]
	public class VoipStatusItem : IExtensible
	{
		private string _Username = "";

		private int _Status;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Username", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this._Username = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
