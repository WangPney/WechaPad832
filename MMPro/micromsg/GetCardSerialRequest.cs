using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCardSerialRequest")]
	[Serializable]
	public class GetCardSerialRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _card_id;

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

		[ProtoMember(2, IsRequired = true, Name = "card_id", DataFormat = DataFormat.Default)]
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
