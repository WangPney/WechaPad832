using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CardDataInfo")]
	[Serializable]
	public class CardDataInfo : IExtensible
	{
		private string _card_id = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "card_id", DataFormat = DataFormat.Default), DefaultValue("")]
		public string card_id
		{
			get
			{
				return this._card_id;
			}
			set
			{
				this._card_id = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
