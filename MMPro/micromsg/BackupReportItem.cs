using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "BackupReportItem")]
	[Serializable]
	public class BackupReportItem : IExtensible
	{
		private string _BakChatName;

		private uint _MsgCount;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BakChatName", DataFormat = DataFormat.Default)]
		public string BakChatName
		{
			get
			{
				return this._BakChatName;
			}
			set
			{
				this._BakChatName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MsgCount", DataFormat = DataFormat.TwosComplement)]
		public uint MsgCount
		{
			get
			{
				return this._MsgCount;
			}
			set
			{
				this._MsgCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
