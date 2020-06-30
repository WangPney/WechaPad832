using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DeepLinkBitSet")]
	[Serializable]
	public class DeepLinkBitSet : IExtensible
	{
		private ulong _BitValue;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BitValue", DataFormat = DataFormat.TwosComplement)]
		public ulong BitValue
		{
			get
			{
				return this._BitValue;
			}
			set
			{
				this._BitValue = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
