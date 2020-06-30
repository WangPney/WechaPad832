using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "QQFriendList")]
	[Serializable]
	public class QQFriendList : IExtensible
	{
		private uint _GroupID;

		private uint _Count;

		private readonly List<QQFriendInGroup> _QQFriends = new List<QQFriendInGroup>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "GroupID", DataFormat = DataFormat.TwosComplement)]
		public uint GroupID
		{
			get
			{
				return this._GroupID;
			}
			set
			{
				this._GroupID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, Name = "QQFriends", DataFormat = DataFormat.Default)]
		public List<QQFriendInGroup> QQFriends
		{
			get
			{
				return this._QQFriends;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
