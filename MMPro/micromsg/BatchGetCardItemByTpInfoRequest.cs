using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetCardItemByTpInfoRequest")]
	[Serializable]
	public class BatchGetCardItemByTpInfoRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private readonly List<CardTpInfoItem> _items = new List<CardTpInfoItem>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<CardTpInfoItem> items
		{
			get
			{
				return this._items;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
