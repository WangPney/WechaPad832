using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModFavObject")]
	[Serializable]
	public class ModFavObject : IExtensible
	{
		private string _TagName = "";

		private string _AttrName = "";

		private string _Value = "";

		private uint _Type = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "TagName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TagName
		{
			get
			{
				return this._TagName;
			}
			set
			{
				this._TagName = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "AttrName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AttrName
		{
			get
			{
				return this._AttrName;
			}
			set
			{
				this._AttrName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Value", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(4, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
