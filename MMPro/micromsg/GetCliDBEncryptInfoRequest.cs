using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCliDBEncryptInfoRequest")]
	[Serializable]
	public class GetCliDBEncryptInfoRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _CertVersion;

		private SKBuiltinBuffer_t _CliDBEncryptKey;

		private SKBuiltinBuffer_t _CliDBEncryptInfo;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "CertVersion", DataFormat = DataFormat.TwosComplement)]
		public uint CertVersion
		{
			get
			{
				return this._CertVersion;
			}
			set
			{
				this._CertVersion = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CliDBEncryptKey", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = true, Name = "CliDBEncryptInfo", DataFormat = DataFormat.Default)]
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
