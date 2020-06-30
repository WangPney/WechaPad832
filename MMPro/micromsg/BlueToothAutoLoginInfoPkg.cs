using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "BlueToothAutoLoginInfoPkg")]
	[Serializable]
	public class BlueToothAutoLoginInfoPkg : IExtensible
	{
		private SKBuiltinBuffer_t _Salt;

		private SKBuiltinBuffer_t _Data;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Salt", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				this._Salt = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
