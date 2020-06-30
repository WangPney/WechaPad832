using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "NewAuthRsaReqData")]
	[Serializable]
	public class NewAuthRsaReqData : IExtensible
	{
		private SKBuiltinBuffer_t _RandomEncryKey;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RandomEncryKey", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
