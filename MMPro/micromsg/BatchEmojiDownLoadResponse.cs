using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchEmojiDownLoadResponse")]
	[Serializable]
	public class BatchEmojiDownLoadResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Index;

		private readonly List<string> _Md5List = new List<string>();

		private uint _EndFlag;

		private readonly List<EmojiInfo> _EmojiList = new List<EmojiInfo>();

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

		[ProtoMember(2, IsRequired = true, Name = "Index", DataFormat = DataFormat.TwosComplement)]
		public uint Index
		{
			get
			{
				return this._Index;
			}
			set
			{
				this._Index = value;
			}
		}

		[ProtoMember(3, Name = "Md5List", DataFormat = DataFormat.Default)]
		public List<string> Md5List
		{
			get
			{
				return this._Md5List;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "EndFlag", DataFormat = DataFormat.TwosComplement)]
		public uint EndFlag
		{
			get
			{
				return this._EndFlag;
			}
			set
			{
				this._EndFlag = value;
			}
		}

		[ProtoMember(5, Name = "EmojiList", DataFormat = DataFormat.Default)]
		public List<EmojiInfo> EmojiList
		{
			get
			{
				return this._EmojiList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
