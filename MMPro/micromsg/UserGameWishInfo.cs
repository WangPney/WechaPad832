using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UserGameWishInfo")]
	[Serializable]
	public class UserGameWishInfo : IExtensible
	{
		private UserGameInfo _UserInfo;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserInfo", DataFormat = DataFormat.Default)]
		public UserGameInfo UserInfo
		{
			get
			{
				return this._UserInfo;
			}
			set
			{
				this._UserInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
