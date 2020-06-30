using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "InitBuffer")]
	[Serializable]
	public class InitBuffer : IExtensible
	{
		private uint _MaxSyncKey;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MaxSyncKey", DataFormat = DataFormat.TwosComplement)]
		public uint MaxSyncKey
		{
			get
			{
				return this._MaxSyncKey;
			}
			set
			{
				this._MaxSyncKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
