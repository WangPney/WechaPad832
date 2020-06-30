using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SKBuiltinUint64_t")]
	[Serializable]
	public class SKBuiltinUint64_t : IExtensible
	{
		private ulong _ullVal;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ullVal", DataFormat = DataFormat.TwosComplement)]
		public ulong ullVal
		{
			get
			{
				return this._ullVal;
			}
			set
			{
				this._ullVal = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
