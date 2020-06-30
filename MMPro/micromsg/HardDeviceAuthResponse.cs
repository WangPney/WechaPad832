using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "HardDeviceAuthResponse")]
	[Serializable]
	public class HardDeviceAuthResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _SessionKey;

		private SKBuiltinBuffer_t _SessionBuffer;

		private SKBuiltinBuffer_t _KeyBuffer;

		private uint _CacheTimeout;

		private uint _BlockTimeout;

		private uint _CryptMethod;

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

		[ProtoMember(2, IsRequired = true, Name = "SessionKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t SessionKey
		{
			get
			{
				return this._SessionKey;
			}
			set
			{
				this._SessionKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "SessionBuffer", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = true, Name = "KeyBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KeyBuffer
		{
			get
			{
				return this._KeyBuffer;
			}
			set
			{
				this._KeyBuffer = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "CacheTimeout", DataFormat = DataFormat.TwosComplement)]
		public uint CacheTimeout
		{
			get
			{
				return this._CacheTimeout;
			}
			set
			{
				this._CacheTimeout = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "BlockTimeout", DataFormat = DataFormat.TwosComplement)]
		public uint BlockTimeout
		{
			get
			{
				return this._BlockTimeout;
			}
			set
			{
				this._BlockTimeout = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "CryptMethod", DataFormat = DataFormat.TwosComplement)]
		public uint CryptMethod
		{
			get
			{
				return this._CryptMethod;
			}
			set
			{
				this._CryptMethod = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
