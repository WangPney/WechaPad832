using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipInviteRemindReq")]
	[Serializable]
	public class VoipInviteRemindReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _ListCount;

		private readonly List<SKBuiltinString_t> _ToUserNameList = new List<SKBuiltinString_t>();

		private uint _InviteType = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "ListCount", DataFormat = DataFormat.TwosComplement)]
		public uint ListCount
		{
			get
			{
				return this._ListCount;
			}
			set
			{
				this._ListCount = value;
			}
		}

		[ProtoMember(3, Name = "ToUserNameList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> ToUserNameList
		{
			get
			{
				return this._ToUserNameList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "InviteType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint InviteType
		{
			get
			{
				return this._InviteType;
			}
			set
			{
				this._InviteType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
