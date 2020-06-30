using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetCardArray")]
	[Serializable]
	public class BatchGetCardArray : IExtensible
	{
		private readonly List<BatchGetCardItem> _card_array = new List<BatchGetCardItem>();

		private IExtension extensionObject;

		[ProtoMember(1, Name = "card_array", DataFormat = DataFormat.Default)]
		public List<BatchGetCardItem> card_array
		{
			get
			{
				return this._card_array;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
