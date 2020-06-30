using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DelMemberReq")]
	[Serializable]
	public class DelMemberReq : IExtensible
	{
		private SKBuiltinString_t _MemberName;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MemberName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t MemberName
		{
			get
			{
				return this._MemberName;
			}
			set
			{
				this._MemberName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
