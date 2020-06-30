using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SendHardDeviceMsgRequest")]
	[Serializable]
	public class SendHardDeviceMsgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private HardDevice _HardDevice;

		private HardDeviceMsg _HardDeviceMsg;

		private SKBuiltinBuffer_t _SessionBuffer;

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

		[ProtoMember(3, IsRequired = true, Name = "HardDeviceMsg", DataFormat = DataFormat.Default)]
		public HardDeviceMsg HardDeviceMsg
		{
			get
			{
				return this._HardDeviceMsg;
			}
			set
			{
				this._HardDeviceMsg = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "SessionBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t SessionBuffer
		{
			get
			{
				return this._SessionBuffer;
			}
			set
			{
				this._SessionBuffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
