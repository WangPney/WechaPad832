using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SendYoResponse")]
	[Serializable]
	public class SendYoResponse : IExtensible
	{
		private int _Ret;

		private uint _ServerTime;

		private ulong _MsgId;

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

		[ProtoMember(2, IsRequired = true, Name = "ServerTime", DataFormat = DataFormat.TwosComplement)]
		public uint ServerTime
		{
			get
			{
				return this._ServerTime;
			}
			set
			{
				this._ServerTime = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public ulong MsgId
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
