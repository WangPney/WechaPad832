using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchDelCardItemResponse")]
	[Serializable]
	public class BatchDelCardItemResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<string> _succ_card_ids = new List<string>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, Name = "succ_card_ids", DataFormat = DataFormat.Default)]
		public List<string> succ_card_ids
		{
			get
			{
				return this._succ_card_ids;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
