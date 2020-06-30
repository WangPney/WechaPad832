using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetGameMsgResponse")]
	[Serializable]
	public class BatchGetGameMsgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<GameMsg> _MsgList = new List<GameMsg>();

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(3, Name = "MsgList", DataFormat = DataFormat.Default)]
		public List<GameMsg> MsgList
		{
			get
			{
				return this._MsgList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
