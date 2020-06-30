using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModFavIndex")]
	[Serializable]
	public class ModFavIndex : IExtensible
	{
		private uint _ModField;

		private uint _ModValue;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ModField", DataFormat = DataFormat.TwosComplement)]
		public uint ModField
		{
			get
			{
				return this._ModField;
			}
			set
			{
				this._ModField = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ModValue", DataFormat = DataFormat.TwosComplement)]
		public uint ModValue
		{
			get
			{
				return this._ModValue;
			}
			set
			{
				this._ModValue = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
