using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "VoiceRemindInfo")]
	[Serializable]
	public class VoiceRemindInfo : IExtensible
	{
		private uint _RemindId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RemindId", DataFormat = DataFormat.TwosComplement)]
		public uint RemindId
		{
			get
			{
				return this._RemindId;
			}
			set
			{
				this._RemindId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
