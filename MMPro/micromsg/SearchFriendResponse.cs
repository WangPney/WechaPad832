using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SearchFriendResponse")]
	[Serializable]
	public class SearchFriendResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _FriendCount;

		private readonly List<FriendInfo> _FriendList = new List<FriendInfo>();

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

		[ProtoMember(2, IsRequired = true, Name = "FriendCount", DataFormat = DataFormat.TwosComplement)]
		public uint FriendCount
		{
			get
			{
				return this._FriendCount;
			}
			set
			{
				this._FriendCount = value;
			}
		}

		[ProtoMember(3, Name = "FriendList", DataFormat = DataFormat.Default)]
		public List<FriendInfo> FriendList
		{
			get
			{
				return this._FriendList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
