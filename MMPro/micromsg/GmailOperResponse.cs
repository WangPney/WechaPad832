using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GmailOperResponse")]
	[Serializable]
	public class GmailOperResponse : IExtensible
	{
		private uint _RetCode;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RetCode", DataFormat = DataFormat.TwosComplement)]
		public uint RetCode
		{
			get
			{
				return this._RetCode;
			}
			set
			{
				this._RetCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
