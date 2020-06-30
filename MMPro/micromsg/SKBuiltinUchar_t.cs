using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinUchar_t")]
	[Serializable]
	public class SKBuiltinUchar_t : IExtensible
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
