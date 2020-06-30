using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AutoAuthKey")]
	[Serializable]
	public class AutoAuthKey : IExtensible
	{
		private SKBuiltinBuffer_t _EncryptKey;

		private SKBuiltinBuffer_t _Key;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "EncryptKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t EncryptKey
		{
			get
			{
				return this._EncryptKey;
			}
			set
			{
				this._EncryptKey = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Key", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				this._Key = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
