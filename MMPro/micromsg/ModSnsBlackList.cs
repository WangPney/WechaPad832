using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModSnsBlackList")]
	[Serializable]
	public class ModSnsBlackList : IExtensible
	{
		private string _ContactUsername = "";

		private uint _ModType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ContactUsername", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ContactUsername
		{
			get
			{
				return this._ContactUsername;
			}
			set
			{
				this._ContactUsername = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ModType", DataFormat = DataFormat.TwosComplement)]
		public uint ModType
		{
			get
			{
				return this._ModType;
			}
			set
			{
				this._ModType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
