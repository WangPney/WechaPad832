using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetRewardMagicListRequest")]
	[Serializable]
	public class GetRewardMagicListRequest : IExtensible
	{
		private uint _Scene;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
