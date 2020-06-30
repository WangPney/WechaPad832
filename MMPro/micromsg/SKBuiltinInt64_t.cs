using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinInt64_t")]
	[Serializable]
	public class SKBuiltinInt64_t : IExtensible
	{
		private long _llVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "llVal", DataFormat = DataFormat.TwosComplement)]
		public long llVal
		{
			get
			{
				return this._llVal;
			}
			set
			{
				this._llVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
