using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ECDHKey")]
	[Serializable]
	public class ECDHKey : IExtensible
	{
		private int _Nid;

		private SKBuiltinBuffer_t _Key;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Nid", DataFormat = DataFormat.TwosComplement)]
		public int Nid
		{
			get
			{
				return this._Nid;
			}
			set
			{
				this._Nid = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Key", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				this._Key = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
