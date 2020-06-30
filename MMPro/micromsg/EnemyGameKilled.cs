using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EnemyGameKilled")]
	[Serializable]
	public class EnemyGameKilled : IExtensible
	{
		private uint _Type;

		private uint _Count;

		private uint _GeneralCount = 0u;

		private uint _UsedCount = 0u;

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

		[ProtoMember(3, IsRequired = false, Name = "GeneralCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GeneralCount
		{
			get
			{
				return this._GeneralCount;
			}
			set
			{
				this._GeneralCount = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "UsedCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint UsedCount
		{
			get
			{
				return this._UsedCount;
			}
			set
			{
				this._UsedCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
