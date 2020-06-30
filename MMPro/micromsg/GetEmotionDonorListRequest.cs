using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionDonorListRequest")]
	[Serializable]
	public class GetEmotionDonorListRequest : IExtensible
	{
		private string _ProductID;

		private SKBuiltinBuffer_t _ReqBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ProductID", DataFormat = DataFormat.Default)]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ReqBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ReqBuf
		{
			get
			{
				return this._ReqBuf;
			}
			set
			{
				this._ReqBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
