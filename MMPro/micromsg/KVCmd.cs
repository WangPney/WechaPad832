using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "KVCmd")]
	[Serializable]
	public class KVCmd : IExtensible
	{
		private uint _Key;

		private SKBuiltinBuffer_t _Value;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Key", DataFormat = DataFormat.TwosComplement)]
		public uint Key
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

		[ProtoMember(2, IsRequired = true, Name = "Value", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
