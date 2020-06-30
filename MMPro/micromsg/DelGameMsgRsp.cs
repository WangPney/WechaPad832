using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DelGameMsgRsp")]
	[Serializable]
	public class DelGameMsgRsp : IExtensible
	{
		private int _Ret;

		private uint _MsgId;

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

		[ProtoMember(2, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
