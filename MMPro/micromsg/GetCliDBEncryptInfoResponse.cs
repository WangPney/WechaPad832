using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCliDBEncryptInfoResponse")]
	[Serializable]
	public class GetCliDBEncryptInfoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _CliDBEncryptKey;

		private SKBuiltinBuffer_t _CliDBEncryptInfo;

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

		[ProtoMember(2, IsRequired = true, Name = "CliDBEncryptKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t CliDBEncryptKey
		{
			get
			{
				return this._CliDBEncryptKey;
			}
			set
			{
				this._CliDBEncryptKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CliDBEncryptInfo", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t CliDBEncryptInfo
		{
			get
			{
				return this._CliDBEncryptInfo;
			}
			set
			{
				this._CliDBEncryptInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
