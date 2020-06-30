using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BackupEmojiOperateResponse")]
	[Serializable]
	public class BackupEmojiOperateResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<string> _NeedUploadMd5List = new List<string>();

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

		[ProtoMember(2, Name = "NeedUploadMd5List", DataFormat = DataFormat.Default)]
		public List<string> NeedUploadMd5List
		{
			get
			{
				return this._NeedUploadMd5List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
