using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "OplogResponse")]
	[Serializable]
	public class OplogResponse : IExtensible
	{
		private int _Ret;

		private OplogRet _OplogRet;

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

		[ProtoMember(2, IsRequired = true, Name = "OplogRet", DataFormat = DataFormat.Default)]
		public OplogRet OplogRet
		{
			get
			{
				return this._OplogRet;
			}
			set
			{
				this._OplogRet = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
