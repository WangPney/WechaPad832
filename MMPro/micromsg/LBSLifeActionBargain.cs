using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LBSLifeActionBargain")]
	[Serializable]
	public class LBSLifeActionBargain : IExtensible
	{
		private string _Desc = "";

		private string _Url = "";

		private string _IconUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Desc", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "IconUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string IconUrl
		{
			get
			{
				return this._IconUrl;
			}
			set
			{
				this._IconUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
