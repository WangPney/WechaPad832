using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UserGameAchieveInfo")]
	[Serializable]
	public class UserGameAchieveInfo : IExtensible
	{
		private UserGameInfo _UserInfo;

		private uint _Score;

		private uint _Rank;

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

		[ProtoMember(2, IsRequired = true, Name = "Score", DataFormat = DataFormat.TwosComplement)]
		public uint Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				this._Score = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Rank", DataFormat = DataFormat.TwosComplement)]
		public uint Rank
		{
			get
			{
				return this._Rank;
			}
			set
			{
				this._Rank = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
