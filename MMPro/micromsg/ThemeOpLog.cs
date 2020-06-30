using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ThemeOpLog")]
	[Serializable]
	public class ThemeOpLog : IExtensible
	{
		private uint _Key;

		private string _Value = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Key", DataFormat = DataFormat.TwosComplement)]
		public uint Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				this._Key = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Value", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
