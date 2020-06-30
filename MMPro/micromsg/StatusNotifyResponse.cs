using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "StatusNotifyResponse")]
	[Serializable]
	public class StatusNotifyResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MsgId;

		private ulong _NewMsgId = 0uL;

		private uint _ChatContactCount = 0u;

		private readonly List<ChatContact> _ChatContactList = new List<ChatContact>();

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

		[ProtoMember(2, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
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

		[ProtoMember(3, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ChatContactCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChatContactCount
		{
			get
			{
				return this._ChatContactCount;
			}
			set
			{
				this._ChatContactCount = value;
			}
		}

		[ProtoMember(5, Name = "ChatContactList", DataFormat = DataFormat.Default)]
		public List<ChatContact> ChatContactList
		{
			get
			{
				return this._ChatContactList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
