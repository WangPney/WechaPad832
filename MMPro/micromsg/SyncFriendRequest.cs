using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SyncFriendRequest")]
	[Serializable]
	public class SyncFriendRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _UserName;

		private uint _SyncKey;

		private int _Scene;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "SyncKey", DataFormat = DataFormat.TwosComplement)]
		public uint SyncKey
		{
			get
			{
				return this._SyncKey;
			}
			set
			{
				this._SyncKey = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
		public int Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
