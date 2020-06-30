using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "OCRTranslationResponse")]
	[Serializable]
	public class OCRTranslationResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ClientScanID;

		private string _Source = "";

		private string _Translation = "";

		private uint _ImageType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ClientScanID", DataFormat = DataFormat.TwosComplement)]
		public uint ClientScanID
		{
			get
			{
				return this._ClientScanID;
			}
			set
			{
				this._ClientScanID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Source", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				this._Source = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Translation", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Translation
		{
			get
			{
				return this._Translation;
			}
			set
			{
				this._Translation = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ImageType", DataFormat = DataFormat.TwosComplement)]
		public uint ImageType
		{
			get
			{
				return this._ImageType;
			}
			set
			{
				this._ImageType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
