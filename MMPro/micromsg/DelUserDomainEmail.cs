using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DelUserDomainEmail")]
	[Serializable]
	public class DelUserDomainEmail : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _Email;

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
