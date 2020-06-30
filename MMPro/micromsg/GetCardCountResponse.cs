using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCardCountResponse")]
	[Serializable]
	public class GetCardCountResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _count = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
