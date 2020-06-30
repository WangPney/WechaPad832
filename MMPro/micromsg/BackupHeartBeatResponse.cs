using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "BackupHeartBeatResponse")]
	[Serializable]
	public class BackupHeartBeatResponse : IExtensible
	{
		private ulong _ack;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ack", DataFormat = DataFormat.TwosComplement)]
		public ulong ack
		{
			get
			{
				return this._ack;
			}
			set
			{
				this._ack = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
