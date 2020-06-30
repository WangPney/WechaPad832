using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SyncKey")]
	[Serializable]
	public class SyncKey : IExtensible
	{
		private uint _KeyCount;

		private readonly List<KeyVal> _Key = new List<KeyVal>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "KeyCount", DataFormat = DataFormat.TwosComplement)]
		public uint KeyCount
		{
			get
			{
				return this._KeyCount;
			}
			set
			{
				this._KeyCount = value;
			}
		}

		[ProtoMember(2, Name = "Key", DataFormat = DataFormat.Default)]
		public List<KeyVal> Key
		{
			get
			{
				return this._Key;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
