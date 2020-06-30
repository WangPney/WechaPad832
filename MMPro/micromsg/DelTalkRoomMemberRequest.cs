using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DelTalkRoomMemberRequest")]
	[Serializable]
	public class DelTalkRoomMemberRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _MemberCount;

		private readonly List<DelMemberReq> _MemberList = new List<DelMemberReq>();

		private string _TalkRoomName = "";

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
		public List<DelMemberReq> MemberList
		{
			get
			{
				return this._MemberList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "TalkRoomName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TalkRoomName
		{
			get
			{
				return this._TalkRoomName;
			}
			set
			{
				this._TalkRoomName = value;
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
