using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UpdateStatOpLog")]
	[Serializable]
	public class UpdateStatOpLog : IExtensible
	{
		private uint _OpCode;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
