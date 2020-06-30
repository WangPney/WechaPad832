using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "HardDeviceMsg")]
	[Serializable]
	public class HardDeviceMsg : IExtensible
	{
		private ulong _SessionID;

		private uint _CreateTime;

		private SKBuiltinBuffer_t _Buffer;

		private uint _Type = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SessionID", DataFormat = DataFormat.TwosComplement)]
		public ulong SessionID
		{
			get
			{
				return this._SessionID;
			}
			set
			{
				this._SessionID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
