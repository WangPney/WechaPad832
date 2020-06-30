using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCertRequest")]
	[Serializable]
	public class GetCertRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _RandomEncryKey;

		private uint _CurrentCertVersion;

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

		[ProtoMember(2, IsRequired = true, Name = "RandomEncryKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RandomEncryKey
		{
			get
			{
				return this._RandomEncryKey;
			}
			set
			{
				this._RandomEncryKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CurrentCertVersion", DataFormat = DataFormat.TwosComplement)]
		public uint CurrentCertVersion
		{
			get
			{
				return this._CurrentCertVersion;
			}
			set
			{
				this._CurrentCertVersion = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
