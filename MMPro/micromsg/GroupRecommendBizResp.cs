using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GroupRecommendBizResp")]
	[Serializable]
	public class GroupRecommendBizResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private RecommendGroups _GroupList;

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

		[ProtoMember(2, IsRequired = true, Name = "GroupList", DataFormat = DataFormat.Default)]
		public RecommendGroups GroupList
		{
			get
			{
				return this._GroupList;
			}
			set
			{
				this._GroupList = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
