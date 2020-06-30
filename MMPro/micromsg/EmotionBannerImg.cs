using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EmotionBannerImg")]
	[Serializable]
	public class EmotionBannerImg : IExtensible
	{
		private string _ImgUrl = "";

		private uint _Width;

		private uint _Height;

		private string _StripUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = true, Name = "Width", DataFormat = DataFormat.TwosComplement)]
		public uint Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Height", DataFormat = DataFormat.TwosComplement)]
		public uint Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "StripUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StripUrl
		{
			get
			{
				return this._StripUrl;
			}
			set
			{
				this._StripUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
