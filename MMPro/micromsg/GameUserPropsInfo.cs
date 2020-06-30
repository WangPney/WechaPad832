using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GameUserPropsInfo")]
	[Serializable]
	public class GameUserPropsInfo : IExtensible
	{
		private uint _PropsId;

		private uint _Count;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "PropsId", DataFormat = DataFormat.TwosComplement)]
		public uint PropsId
		{
			get
			{
				return this._PropsId;
			}
			set
			{
				this._PropsId = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
