using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TalkMicActionResp")]
	[Serializable]
	public class TalkMicActionResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _MicSeq;

		private uint _ChannelId = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "MicSeq", DataFormat = DataFormat.TwosComplement)]
		public int MicSeq
		{
			get
			{
				return this._MicSeq;
			}
			set
			{
				this._MicSeq = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ChannelId", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChannelId
		{
			get
			{
				return this._ChannelId;
			}
			set
			{
				this._ChannelId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
