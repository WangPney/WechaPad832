using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AppCenterResponse")]
	[Serializable]
	public class AppCenterResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _RespBuf;

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

		[ProtoMember(2, IsRequired = true, Name = "RespBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RespBuf
		{
			get
			{
				return this._RespBuf;
			}
			set
			{
				this._RespBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
