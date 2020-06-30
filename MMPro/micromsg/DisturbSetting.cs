using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DisturbSetting")]
	[Serializable]
	public class DisturbSetting : IExtensible
	{
		private uint _NightSetting;

		private DisturbTimeSpan _NightTime;

		private uint _AllDaySetting;

		private DisturbTimeSpan _AllDayTime;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "NightSetting", DataFormat = DataFormat.TwosComplement)]
		public uint NightSetting
		{
			get
			{
				return this._NightSetting;
			}
			set
			{
				this._NightSetting = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "NightTime", DataFormat = DataFormat.Default)]
		public DisturbTimeSpan NightTime
		{
			get
			{
				return this._NightTime;
			}
			set
			{
				this._NightTime = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "AllDaySetting", DataFormat = DataFormat.TwosComplement)]
		public uint AllDaySetting
		{
			get
			{
				return this._AllDaySetting;
			}
			set
			{
				this._AllDaySetting = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "AllDayTime", DataFormat = DataFormat.Default)]
		public DisturbTimeSpan AllDayTime
		{
			get
			{
				return this._AllDayTime;
			}
			set
			{
				this._AllDayTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
