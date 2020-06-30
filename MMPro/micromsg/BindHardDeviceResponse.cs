using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindHardDeviceResponse")]
	[Serializable]
	public class BindHardDeviceResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private HardDevice _HardDevice;

		private HardDeviceAttr _HardDeviceAttr;

		private uint _Flag = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "HardDevice", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "HardDeviceAttr", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "Flag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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
