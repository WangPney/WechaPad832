using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SwitchOpVoicePrintRequest")]
	[Serializable]
	public class SwitchOpVoicePrintRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _opcode;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "opcode", DataFormat = DataFormat.TwosComplement)]
		public uint opcode
		{
			get
			{
				return this._opcode;
			}
			set
			{
				this._opcode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
