using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "NewGetInviteFriendRequest")]
	[Serializable]
	public class NewGetInviteFriendRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _FriendType;

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

		[ProtoMember(2, IsRequired = true, Name = "FriendType", DataFormat = DataFormat.TwosComplement)]
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
