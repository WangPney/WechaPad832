using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "EmojiUploadResponse")]
	[Serializable]
	public class EmojiUploadResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<UploadEmojiInfoResp> _EmojiItem = new List<UploadEmojiInfoResp>();

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

		[ProtoMember(2, Name = "EmojiItem", DataFormat = DataFormat.Default)]
		public List<UploadEmojiInfoResp> EmojiItem
		{
			get
			{
				return this._EmojiItem;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
