using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "DownloadEmojiRequest")]
	[Serializable]
	public class DownloadEmojiRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _EmojiItemCount;

		private readonly List<EmojiDownloadInfoReq> _EmojiItem = new List<EmojiDownloadInfoReq>();

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
		public List<EmojiDownloadInfoReq> EmojiItem
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
