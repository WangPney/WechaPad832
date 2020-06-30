using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CreateTalkRoomRequest")]
	[Serializable]
	public class CreateTalkRoomRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _Topic;

		private uint _MemberCount;

		private readonly List<MemberReq> _MemberList = new List<MemberReq>();

		private uint _Scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Topic", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t Topic
		{
			get
			{
				return this._Topic;
			}
			set
			{
				this._Topic = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, Name = "MemberList", DataFormat = DataFormat.Default)]
		public List<MemberReq> MemberList
		{
			get
			{
				return this._MemberList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
