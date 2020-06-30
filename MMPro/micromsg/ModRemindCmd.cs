using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModRemindCmd")]
	[Serializable]
	public class ModRemindCmd : IExtensible
	{
		private uint _RemindID;

		private ulong _RemindTime;

		private uint _Flag;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RemindID", DataFormat = DataFormat.TwosComplement)]
		public uint RemindID
		{
			get
			{
				return this._RemindID;
			}
			set
			{
				this._RemindID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "RemindTime", DataFormat = DataFormat.TwosComplement)]
		public ulong RemindTime
		{
			get
			{
				return this._RemindTime;
			}
			set
			{
				this._RemindTime = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Flag", DataFormat = DataFormat.TwosComplement)]
		public uint Flag
		{
			get
			{
				return this._Flag;
			}
			set
			{
				this._Flag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
