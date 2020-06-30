using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetRecommendAppListResponse")]
	[Serializable]
	public class GetRecommendAppListResponse : IExtensible
	{
		private uint _Total;

		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<OpenAppInfo> _AppList = new List<OpenAppInfo>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Total", DataFormat = DataFormat.TwosComplement)]
		public uint Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				this._Total = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
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

		[ProtoMember(4, Name = "AppList", DataFormat = DataFormat.Default)]
		public List<OpenAppInfo> AppList
		{
			get
			{
				return this._AppList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
