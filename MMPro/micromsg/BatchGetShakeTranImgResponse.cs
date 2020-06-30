using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetShakeTranImgResponse")]
	[Serializable]
	public class BatchGetShakeTranImgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<ShakeTranImgGetItem> _ImgUrlList = new List<ShakeTranImgGetItem>();

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(3, Name = "ImgUrlList", DataFormat = DataFormat.Default)]
		public List<ShakeTranImgGetItem> ImgUrlList
		{
			get
			{
				return this._ImgUrlList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
