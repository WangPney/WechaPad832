using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CustomizedInfo")]
	[Serializable]
	public class CustomizedInfo : IExtensible
	{
		private uint _BrandFlag;

		private string _ExternalInfo = "";

		private string _BrandInfo = "";

		private string _BrandIconURL = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ExternalInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ExternalInfo
		{
			get
			{
				return this._ExternalInfo;
			}
			set
			{
				this._ExternalInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "BrandInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BrandInfo
		{
			get
			{
				return this._BrandInfo;
			}
			set
			{
				this._BrandInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BrandIconURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BrandIconURL
		{
			get
			{
				return this._BrandIconURL;
			}
			set
			{
				this._BrandIconURL = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
