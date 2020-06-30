using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "CmdItem")]
	[Serializable]
	public class CmdItem : IExtensible
	{
		private int _CmdId;

		private SKBuiltinBuffer_t _CmdBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "CmdId", DataFormat = DataFormat.TwosComplement)]
		public int CmdId
		{
			get
			{
				return this._CmdId;
			}
			set
			{
				this._CmdId = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "CmdBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t CmdBuf
		{
			get
			{
				return this._CmdBuf;
			}
			set
			{
				this._CmdBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
