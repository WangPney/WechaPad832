using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModTXNewsCategory")]
	[Serializable]
	public class ModTXNewsCategory : IExtensible
	{
		private uint _TXNewsCategory;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "TXNewsCategory", DataFormat = DataFormat.TwosComplement)]
		public uint TXNewsCategory
		{
			get
			{
				return this._TXNewsCategory;
			}
			set
			{
				this._TXNewsCategory = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
