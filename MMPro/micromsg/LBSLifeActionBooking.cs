using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LBSLifeActionBooking")]
	[Serializable]
	public class LBSLifeActionBooking : IExtensible
	{
		private uint _Type;

		private string _Title = "";

		private string _Url = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
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
