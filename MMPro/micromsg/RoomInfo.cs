using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RoomInfo")]
	[Serializable]
	public class RoomInfo : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _NickName;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = true, Name = "NickName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
