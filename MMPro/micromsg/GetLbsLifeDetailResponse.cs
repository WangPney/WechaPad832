using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetLbsLifeDetailResponse")]
	[Serializable]
	public class GetLbsLifeDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private LbsLifeDetail _LifeDetail;

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

		[ProtoMember(2, IsRequired = true, Name = "LifeDetail", DataFormat = DataFormat.Default)]
		public LbsLifeDetail LifeDetail
		{
			get
			{
				return this._LifeDetail;
			}
			set
			{
				this._LifeDetail = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
