using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "KeyBuffer")]
	[Serializable]
	public class KeyBuffer : IExtensible
	{
		private SKBuiltinString_t _synckey;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "synckey", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t synckey
		{
			get
			{
				return this._synckey;
			}
			set
			{
				this._synckey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
