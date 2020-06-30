using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GeneralShareBaseInfo")]
	[Serializable]
	public class GeneralShareBaseInfo : IExtensible
	{
		private uint _DestType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "DestType", DataFormat = DataFormat.TwosComplement)]
		public uint DestType
		{
			get
			{
				return this._DestType;
			}
			set
			{
				this._DestType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
