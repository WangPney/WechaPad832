using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetTalkRoomMemberResp")]
	[Serializable]
	public class GetTalkRoomMemberResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _MicSeq;

		private int _MemberNum;

		private readonly List<TalkRoomMember> _MemberList = new List<TalkRoomMember>();

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

		[ProtoMember(3, IsRequired = true, Name = "MemberNum", DataFormat = DataFormat.TwosComplement)]
		public int MemberNum
		{
			get
			{
				return this._MemberNum;
			}
			set
			{
				this._MemberNum = value;
			}
		}

		[ProtoMember(4, Name = "MemberList", DataFormat = DataFormat.Default)]
		public List<TalkRoomMember> MemberList
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
