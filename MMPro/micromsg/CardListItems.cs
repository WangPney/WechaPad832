using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "CardListItems")]
	[Serializable]
	public class CardListItems : IExtensible
	{
		private readonly List<CardListItem> _card_list = new List<CardListItem>();

		private IExtension extensionObject;

		[ProtoMember(1, Name = "card_list", DataFormat = DataFormat.Default)]
		public List<CardListItem> card_list
		{
			get
			{
				return this._card_list;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
