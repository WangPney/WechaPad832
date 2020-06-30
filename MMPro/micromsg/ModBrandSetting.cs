using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModBrandSetting")]
	[Serializable]
	public class ModBrandSetting : IExtensible
	{
		private uint _BrandFlag;

		private string _UserName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BrandFlag", DataFormat = DataFormat.TwosComplement)]
		public uint BrandFlag
		{
			get
			{
				return this._BrandFlag;
			}
			set
			{
				this._BrandFlag = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
