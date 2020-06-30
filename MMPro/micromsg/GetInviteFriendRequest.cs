using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetInviteFriendRequest")]
	[Serializable]
	public class GetInviteFriendRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _FriendType = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "FriendType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FriendType
		{
			get
			{
				return this._FriendType;
			}
			set
			{
				this._FriendType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
