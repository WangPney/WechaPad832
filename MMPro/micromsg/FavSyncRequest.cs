using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "FavSyncRequest")]
	[Serializable]
	public class FavSyncRequest : IExtensible
	{
		private uint _Selector;

		private SKBuiltinBuffer_t _KeyBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Selector", DataFormat = DataFormat.TwosComplement)]
		public uint Selector
		{
			get
			{
				return this._Selector;
			}
			set
			{
				this._Selector = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "KeyBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KeyBuf
		{
			get
			{
				return this._KeyBuf;
			}
			set
			{
				this._KeyBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
