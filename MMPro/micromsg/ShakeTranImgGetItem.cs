using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeTranImgGetItem")]
	[Serializable]
	public class ShakeTranImgGetItem : IExtensible
	{
		private string _WebUrl = "";

		private string _ThumbUrl = "";

		private string _ImgUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "WebUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string WebUrl
		{
			get
			{
				return this._WebUrl;
			}
			set
			{
				this._WebUrl = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ThumbUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ThumbUrl
		{
			get
			{
				return this._ThumbUrl;
			}
			set
			{
				this._ThumbUrl = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ImgUrl
		{
			get
			{
				return this._ImgUrl;
			}
			set
			{
				this._ImgUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
