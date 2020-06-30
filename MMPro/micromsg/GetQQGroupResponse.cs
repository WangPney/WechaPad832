using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetQQGroupResponse")]
	[Serializable]
	public class GetQQGroupResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _OpType;

		private QQGroupList _QQGroup;

		private QQFriendList _QQFriend;

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

		[ProtoMember(2, IsRequired = true, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
		public uint OpType
		{
			get
			{
				return this._OpType;
			}
			set
			{
				this._OpType = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "QQGroup", DataFormat = DataFormat.Default)]
		public QQGroupList QQGroup
		{
			get
			{
				return this._QQGroup;
			}
			set
			{
				this._QQGroup = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "QQFriend", DataFormat = DataFormat.Default)]
		public QQFriendList QQFriend
		{
			get
			{
				return this._QQFriend;
			}
			set
			{
				this._QQFriend = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
