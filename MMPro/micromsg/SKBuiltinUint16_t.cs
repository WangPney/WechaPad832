using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinUint16_t")]
	[Serializable]
	public class SKBuiltinUint16_t : IExtensible
	{
		private uint _uiVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "uiVal", DataFormat = DataFormat.TwosComplement)]
		public uint uiVal
		{
			get
			{
				return this._uiVal;
			}
			set
			{
				this._uiVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
