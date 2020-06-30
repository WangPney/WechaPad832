using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GameConsumeProps")]
	[Serializable]
	public class GameConsumeProps : IExtensible
	{
		private uint _PropsId;

		private int _ConsumeCount;

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

		[ProtoMember(2, IsRequired = true, Name = "ConsumeCount", DataFormat = DataFormat.TwosComplement)]
		public int ConsumeCount
		{
			get
			{
				return this._ConsumeCount;
			}
			set
			{
				this._ConsumeCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
