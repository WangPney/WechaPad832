using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "BaseResponse")]
	[Serializable]
	public class BaseResponse : IExtensible
	{
		private int _Ret;

		private SKBuiltinString_t _ErrMsg;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
		public int Ret
		{
			get
			{
				return this._Ret;
			}
			set
			{
				this._Ret = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ErrMsg", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ErrMsg
		{
			get
			{
				return this._ErrMsg;
			}
			set
			{
				this._ErrMsg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
