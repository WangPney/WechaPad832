using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LockStockResponse")]
	[Serializable]
	public class LockStockResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _LockId = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "LockId", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LockId
		{
			get
			{
				return this._LockId;
			}
			set
			{
				this._LockId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
