using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsGroup")]
	[Serializable]
	public class SnsGroup : IExtensible
	{
		private ulong _GroupId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "GroupId", DataFormat = DataFormat.TwosComplement)]
		public ulong GroupId
		{
			get
			{
				return this._GroupId;
			}
			set
			{
				this._GroupId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
