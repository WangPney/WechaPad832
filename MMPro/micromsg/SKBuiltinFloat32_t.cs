using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinFloat32_t")]
	[Serializable]
	public class SKBuiltinFloat32_t : IExtensible
	{
		private float _fVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "fVal", DataFormat = DataFormat.FixedSize)]
		public float fVal
		{
			get
			{
				return this._fVal;
			}
			set
			{
				this._fVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
