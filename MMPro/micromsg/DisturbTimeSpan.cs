using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DisturbTimeSpan")]
	[Serializable]
	public class DisturbTimeSpan : IExtensible
	{
		private uint _BeginTime;

		private uint _EndTime;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BeginTime", DataFormat = DataFormat.TwosComplement)]
		public uint BeginTime
		{
			get
			{
				return this._BeginTime;
			}
			set
			{
				this._BeginTime = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "EndTime", DataFormat = DataFormat.TwosComplement)]
		public uint EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				this._EndTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
