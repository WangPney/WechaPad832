using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModHardDevice")]
	[Serializable]
	public class ModHardDevice : IExtensible
	{
		private HardDevice _HardDevice;

		private HardDeviceAttr _HardDeviceAttr;

		private uint _BindFlag;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "HardDevice", DataFormat = DataFormat.Default)]
		public HardDevice HardDevice
		{
			get
			{
				return this._HardDevice;
			}
			set
			{
				this._HardDevice = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "HardDeviceAttr", DataFormat = DataFormat.Default)]
		public HardDeviceAttr HardDeviceAttr
		{
			get
			{
				return this._HardDeviceAttr;
			}
			set
			{
				this._HardDeviceAttr = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "BindFlag", DataFormat = DataFormat.TwosComplement)]
		public uint BindFlag
		{
			get
			{
				return this._BindFlag;
			}
			set
			{
				this._BindFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
