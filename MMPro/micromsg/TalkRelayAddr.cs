using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "TalkRelayAddr")]
	[Serializable]
	public class TalkRelayAddr : IExtensible
	{
		private uint _Ip;

		private uint _Port;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Ip", DataFormat = DataFormat.TwosComplement)]
		public uint Ip
		{
			get
			{
				return this._Ip;
			}
			set
			{
				this._Ip = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Port", DataFormat = DataFormat.TwosComplement)]
		public uint Port
		{
			get
			{
				return this._Port;
			}
			set
			{
				this._Port = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
