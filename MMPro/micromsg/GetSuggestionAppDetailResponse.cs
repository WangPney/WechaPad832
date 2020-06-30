using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetSuggestionAppDetailResponse")]
	[Serializable]
	public class GetSuggestionAppDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private RcAppList _RcDetail;

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

		[ProtoMember(2, IsRequired = true, Name = "RcDetail", DataFormat = DataFormat.Default)]
		public RcAppList RcDetail
		{
			get
			{
				return this._RcDetail;
			}
			set
			{
				this._RcDetail = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
