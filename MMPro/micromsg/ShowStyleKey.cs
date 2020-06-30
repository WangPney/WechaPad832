using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "ShowStyleKey")]
	[Serializable]
	public class ShowStyleKey : IExtensible
	{
		private uint _KeyCount;

		private readonly List<StyleKeyVal> _Key = new List<StyleKeyVal>();

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
		public List<StyleKeyVal> Key
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
