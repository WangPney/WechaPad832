using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ShakeBuffer")]
	[Serializable]
	public class ShakeBuffer : IExtensible
	{
		private uint _ReportTime;

		private uint _X;

		private uint _Y;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ReportTime", DataFormat = DataFormat.TwosComplement)]
		public uint ReportTime
		{
			get
			{
				return this._ReportTime;
			}
			set
			{
				this._ReportTime = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "X", DataFormat = DataFormat.TwosComplement)]
		public uint X
		{
			get
			{
				return this._X;
			}
			set
			{
				this._X = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Y", DataFormat = DataFormat.TwosComplement)]
		public uint Y
		{
			get
			{
				return this._Y;
			}
			set
			{
				this._Y = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
