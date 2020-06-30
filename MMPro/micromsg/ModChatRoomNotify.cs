using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModChatRoomNotify")]
	[Serializable]
	public class ModChatRoomNotify : IExtensible
	{
		private SKBuiltinString_t _ChatRoomName;

		private uint _Status;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ChatRoomName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ChatRoomName
		{
			get
			{
				return this._ChatRoomName;
			}
			set
			{
				this._ChatRoomName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public uint Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
