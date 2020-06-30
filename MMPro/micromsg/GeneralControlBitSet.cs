using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GeneralControlBitSet")]
	[Serializable]
	public class GeneralControlBitSet : IExtensible
	{
		private uint _BitValue;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BitValue", DataFormat = DataFormat.TwosComplement)]
		public uint BitValue
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
