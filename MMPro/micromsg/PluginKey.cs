using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PluginKey")]
	[Serializable]
	public class PluginKey : IExtensible
	{
		private string _Key = "";

		private uint _Id = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Key", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Key
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

		[ProtoMember(2, IsRequired = false, Name = "Id", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
