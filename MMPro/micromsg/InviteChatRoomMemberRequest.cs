using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "InviteChatRoomMemberRequest")]
	[Serializable]
	public class InviteChatRoomMemberRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _MemberCount;

		private readonly List<MemberReq> _MemberList = new List<MemberReq>();

		private SKBuiltinString_t _ChatRoomName;

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

		[ProtoMember(2, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
		public uint MemberCount
		{
			get
			{
				return this._MemberCount;
			}
			set
			{
				this._MemberCount = value;
			}
		}

		[ProtoMember(3, Name = "MemberList", DataFormat = DataFormat.Default)]
		public List<MemberReq> MemberList
		{
			get
			{
				return this._MemberList;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ChatRoomName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ChatRoomName
		{
			get
			{
				return this._ChatRoomName;
			}
			set
			{
				this._ChatRoomName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
