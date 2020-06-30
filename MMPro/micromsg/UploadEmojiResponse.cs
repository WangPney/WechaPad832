using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "UploadEmojiResponse")]
	[Serializable]
	public class UploadEmojiResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _EmojiItemCount;

		private readonly List<EmojiUploadInfoResp> _EmojiItem = new List<EmojiUploadInfoResp>();

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

		[ProtoMember(2, IsRequired = true, Name = "EmojiItemCount", DataFormat = DataFormat.TwosComplement)]
		public int EmojiItemCount
		{
			get
			{
				return this._EmojiItemCount;
			}
			set
			{
				this._EmojiItemCount = value;
			}
		}

		[ProtoMember(3, Name = "EmojiItem", DataFormat = DataFormat.Default)]
		public List<EmojiUploadInfoResp> EmojiItem
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
