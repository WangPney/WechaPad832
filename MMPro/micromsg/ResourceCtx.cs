using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ResourceCtx")]
	[Serializable]
	public class ResourceCtx : IExtensible
	{
		private uint _ResId;

		private SKBuiltinBuffer_t _ResData;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ResId", DataFormat = DataFormat.TwosComplement)]
		public uint ResId
		{
			get
			{
				return this._ResId;
			}
			set
			{
				this._ResId = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ResData", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ResData
		{
			get
			{
				return this._ResData;
			}
			set
			{
				this._ResData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
