using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinDouble64_t")]
	[Serializable]
	public class SKBuiltinDouble64_t : IExtensible
	{
		private double _dVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "dVal", DataFormat = DataFormat.TwosComplement)]
		public double dVal
		{
			get
			{
				return this._dVal;
			}
			set
			{
				this._dVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
