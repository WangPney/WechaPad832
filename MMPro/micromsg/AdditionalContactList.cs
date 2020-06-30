using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AdditionalContactList")]
	[Serializable]
	public class AdditionalContactList : IExtensible
	{
		private LinkedinContactItem _LinkedinContactItem = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "LinkedinContactItem", DataFormat = DataFormat.Default), DefaultValue(null)]
		public LinkedinContactItem LinkedinContactItem
		{
			get
			{
				return this._LinkedinContactItem;
			}
			set
			{
				this._LinkedinContactItem = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
