using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "KVCommReportResp")]
	[Serializable]
	public class KVCommReportResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _KVResponBuffer;

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

		[ProtoMember(2, IsRequired = true, Name = "KVResponBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KVResponBuffer
		{
			get
			{
				return this._KVResponBuffer;
			}
			set
			{
				this._KVResponBuffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
