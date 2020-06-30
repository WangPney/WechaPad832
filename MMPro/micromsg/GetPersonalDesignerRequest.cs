using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetPersonalDesignerRequest")]
	[Serializable]
	public class GetPersonalDesignerRequest : IExtensible
	{
		private uint _DesignerUin;

		private SKBuiltinBuffer_t _ReqBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "DesignerUin", DataFormat = DataFormat.TwosComplement)]
		public uint DesignerUin
		{
			get
			{
				return this._DesignerUin;
			}
			set
			{
				this._DesignerUin = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ReqBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ReqBuf
		{
			get
			{
				return this._ReqBuf;
			}
			set
			{
				this._ReqBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
