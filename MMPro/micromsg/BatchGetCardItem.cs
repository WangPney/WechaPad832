using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetCardItem")]
	[Serializable]
	public class BatchGetCardItem : IExtensible
	{
		private string _card_id = "";

		private CardDataInfo _card_data_info = null;

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

		[ProtoMember(2, IsRequired = false, Name = "card_data_info", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CardDataInfo card_data_info
		{
			get
			{
				return this._card_data_info;
			}
			set
			{
				this._card_data_info = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
