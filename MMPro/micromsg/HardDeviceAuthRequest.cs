using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "HardDeviceAuthRequest")]
	[Serializable]
	public class HardDeviceAuthRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private HardDevice _HardDevice;

		private uint _AuthVer;

		private SKBuiltinBuffer_t _AuthBuffer;

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

		[ProtoMember(3, IsRequired = true, Name = "AuthVer", DataFormat = DataFormat.TwosComplement)]
		public uint AuthVer
		{
			get
			{
				return this._AuthVer;
			}
			set
			{
				this._AuthVer = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "AuthBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t AuthBuffer
		{
			get
			{
				return this._AuthBuffer;
			}
			set
			{
				this._AuthBuffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
