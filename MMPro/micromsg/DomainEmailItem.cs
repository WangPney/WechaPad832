using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DomainEmailItem")]
	[Serializable]
	public class DomainEmailItem : IExtensible
	{
		private uint _Status;

		private SKBuiltinString_t _Email;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = true, Name = "Email", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this._Email = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
