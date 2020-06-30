using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "EnemyGameInfo")]
	[Serializable]
	public class EnemyGameInfo : IExtensible
	{
		private uint _Type;

		private uint _Score;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Score", DataFormat = DataFormat.TwosComplement)]
		public uint Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				this._Score = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
