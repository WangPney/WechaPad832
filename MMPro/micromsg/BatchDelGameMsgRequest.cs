using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchDelGameMsgRequest")]
	[Serializable]
	public class BatchDelGameMsgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Count;

		private readonly List<uint> _MsgIdList = new List<uint>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
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

		[ProtoMember(3, Name = "MsgIdList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<uint> MsgIdList
		{
			get
			{
				return this._MsgIdList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
