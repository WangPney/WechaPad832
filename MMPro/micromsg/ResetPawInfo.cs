using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ResetPawInfo")]
	[Serializable]
	public class ResetPawInfo : IExtensible
	{
		private uint _CreateTime;

		private uint _IsReset;

		private uint _ID;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
		public uint CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				this._CreateTime = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "IsReset", DataFormat = DataFormat.TwosComplement)]
		public uint IsReset
		{
			get
			{
				return this._IsReset;
			}
			set
			{
				this._IsReset = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public uint ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
