using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ExtDeviceControlRequest")]
	[Serializable]
	public class ExtDeviceControlRequest : IExtensible
	{
		private uint _OpType = 0u;

		private uint _LockDevice = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "OpType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint OpType
		{
			get
			{
				return this._OpType;
			}
			set
			{
				this._OpType = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "LockDevice", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LockDevice
		{
			get
			{
				return this._LockDevice;
			}
			set
			{
				this._LockDevice = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
