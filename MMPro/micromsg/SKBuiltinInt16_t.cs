using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinInt16_t")]
	[Serializable]
	public class SKBuiltinInt16_t : IExtensible
	{
		private int _iVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "iVal", DataFormat = DataFormat.TwosComplement)]
		public int iVal
		{
			get
			{
				return this._iVal;
			}
			set
			{
				this._iVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
