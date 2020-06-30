using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserPositionItem")]
	[Serializable]
	public class UserPositionItem : IExtensible
	{
		private string _Username = "";

		private PositionItem _Position;

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

		[ProtoMember(2, IsRequired = true, Name = "Position", DataFormat = DataFormat.Default)]
		public PositionItem Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				this._Position = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
