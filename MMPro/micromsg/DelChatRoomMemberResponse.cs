using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "DelChatRoomMemberResponse")]
	[Serializable]
	public class DelChatRoomMemberResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MemberCount;

		private readonly List<DelMemberResp> _MemberList = new List<DelMemberResp>();

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
		public List<DelMemberResp> MemberList
		{
			get
			{
				return this._MemberList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
