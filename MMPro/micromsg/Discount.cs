using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Discount")]
	[Serializable]
	public class Discount : IExtensible
	{
		private string _Title = "";

		private uint _Price;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = true, Name = "Price", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
