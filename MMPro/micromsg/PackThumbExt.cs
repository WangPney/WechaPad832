using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PackThumbExt")]
	[Serializable]
	public class PackThumbExt : IExtensible
	{
		private string _PreviewUrl = "";

		private string _Desc = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "PreviewUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PreviewUrl
		{
			get
			{
				return this._PreviewUrl;
			}
			set
			{
				this._PreviewUrl = value;
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
