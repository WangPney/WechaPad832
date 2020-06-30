using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CardListItem")]
	[Serializable]
	public class CardListItem : IExtensible
	{
		private string _card_tp_id = "";

		private string _card_ext = "";

		private int _is_succ = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "card_tp_id", DataFormat = DataFormat.Default), DefaultValue("")]
		public string card_tp_id
		{
			get
			{
				return this._card_tp_id;
			}
			set
			{
				this._card_tp_id = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "card_ext", DataFormat = DataFormat.Default), DefaultValue("")]
		public string card_ext
		{
			get
			{
				return this._card_ext;
			}
			set
			{
				this._card_ext = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "is_succ", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int is_succ
		{
			get
			{
				return this._is_succ;
			}
			set
			{
				this._is_succ = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
