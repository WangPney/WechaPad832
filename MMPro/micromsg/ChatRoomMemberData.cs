using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ChatRoomMemberData")]
	[Serializable]
	public class ChatRoomMemberData : IExtensible
	{
		private uint _MemberCount;

		private readonly List<ChatRoomMemberInfo> _ChatRoomMember = new List<ChatRoomMemberInfo>();

		private uint _InfoMask = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "ChatRoomMember", DataFormat = DataFormat.Default)]
		public List<ChatRoomMemberInfo> ChatRoomMember
		{
			get
			{
				return this._ChatRoomMember;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "InfoMask", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint InfoMask
		{
			get
			{
				return this._InfoMask;
			}
			set
			{
				this._InfoMask = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
