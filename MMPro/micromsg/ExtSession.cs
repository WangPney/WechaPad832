using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ExtSession")]
	[Serializable]
	public class ExtSession : IExtensible
	{
		private uint _SessionType;

		private SKBuiltinBuffer_t _SessionKey;

		private SKBuiltinBuffer_t _ServerId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SessionType", DataFormat = DataFormat.TwosComplement)]
		public uint SessionType
		{
			get
			{
				return this._SessionType;
			}
			set
			{
				this._SessionType = value;
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

		[ProtoMember(3, IsRequired = true, Name = "ServerId", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ServerId
		{
			get
			{
				return this._ServerId;
			}
			set
			{
				this._ServerId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
