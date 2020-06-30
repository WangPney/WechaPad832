using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UnbindHardDeviceRequest")]
	[Serializable]
	public class UnbindHardDeviceRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private HardDevice _HardDevice;

		private uint _Flag = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
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
