using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DonateHistory")]
	[Serializable]
	public class DonateHistory : IExtensible
	{
		private uint _Time;

		private string _DonateTitle = "";

		private string _DonateUrl = "";

		private uint _Price;

		private string _DonateThumbUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Time", DataFormat = DataFormat.TwosComplement)]
		public uint Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				this._Time = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "DonateTitle", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DonateTitle
		{
			get
			{
				return this._DonateTitle;
			}
			set
			{
				this._DonateTitle = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "DonateUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DonateUrl
		{
			get
			{
				return this._DonateUrl;
			}
			set
			{
				this._DonateUrl = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Price", DataFormat = DataFormat.TwosComplement)]
		public uint Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				this._Price = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "DonateThumbUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DonateThumbUrl
		{
			get
			{
				return this._DonateThumbUrl;
			}
			set
			{
				this._DonateThumbUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
