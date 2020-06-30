using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionListRequest")]
	[Serializable]
	public class GetEmotionListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _ReqBuf;

		private uint _ReqType;

		private uint _Scene = 0u;

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

		[ProtoMember(3, IsRequired = true, Name = "ReqType", DataFormat = DataFormat.TwosComplement)]
		public uint ReqType
		{
			get
			{
				return this._ReqType;
			}
			set
			{
				this._ReqType = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
