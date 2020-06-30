using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionDetailResponse")]
	[Serializable]
	public class GetEmotionDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private EmotionDetail _EmotionDetail;

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

		[ProtoMember(2, IsRequired = true, Name = "EmotionDetail", DataFormat = DataFormat.Default)]
		public EmotionDetail EmotionDetail
		{
			get
			{
				return this._EmotionDetail;
			}
			set
			{
				this._EmotionDetail = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
