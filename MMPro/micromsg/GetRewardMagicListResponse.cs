using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetRewardMagicListResponse")]
	[Serializable]
	public class GetRewardMagicListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<RewardMagic> _Magic = new List<RewardMagic>();

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

		[ProtoMember(2, Name = "Magic", DataFormat = DataFormat.Default)]
		public List<RewardMagic> Magic
		{
			get
			{
				return this._Magic;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
