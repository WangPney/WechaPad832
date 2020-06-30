using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EmojiInfo")]
	[Serializable]
	public class EmojiInfo : IExtensible
	{
		private string _Md5;

		private string _Url = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Md5", DataFormat = DataFormat.Default)]
		public string Md5
		{
			get
			{
				return this._Md5;
			}
			set
			{
				this._Md5 = value;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
