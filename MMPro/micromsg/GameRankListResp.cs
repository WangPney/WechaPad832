using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GameRankListResp")]
	[Serializable]
	public class GameRankListResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _Count;

		private readonly List<UserGameAchieveInfo> _RankList = new List<UserGameAchieveInfo>();

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(3, Name = "RankList", DataFormat = DataFormat.Default)]
		public List<UserGameAchieveInfo> RankList
		{
			get
			{
				return this._RankList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
