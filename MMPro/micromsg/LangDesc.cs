using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LangDesc")]
	[Serializable]
	public class LangDesc : IExtensible
	{
		private string _Lang = "";

		private string _Desc = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Lang", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Lang
		{
			get
			{
				return this._Lang;
			}
			set
			{
				this._Lang = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Desc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Desc
		{
			get
			{
				return this._Desc;
			}
			set
			{
				this._Desc = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
