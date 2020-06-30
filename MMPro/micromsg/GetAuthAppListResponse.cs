using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetAuthAppListResponse")]
	[Serializable]
	public class GetAuthAppListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _AppCount;

		private readonly List<AuthAppBaseInfo> _AuthAppList = new List<AuthAppBaseInfo>();

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

		[ProtoMember(2, IsRequired = true, Name = "AppCount", DataFormat = DataFormat.TwosComplement)]
		public uint AppCount
		{
			get
			{
				return this._AppCount;
			}
			set
			{
				this._AppCount = value;
			}
		}

		[ProtoMember(3, Name = "AuthAppList", DataFormat = DataFormat.Default)]
		public List<AuthAppBaseInfo> AuthAppList
		{
			get
			{
				return this._AuthAppList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
