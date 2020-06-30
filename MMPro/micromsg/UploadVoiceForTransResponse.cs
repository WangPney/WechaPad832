using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UploadVoiceForTransResponse")]
	[Serializable]
	public class UploadVoiceForTransResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private UploadVoiceCtx _UploadCtx;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "UploadCtx", DataFormat = DataFormat.Default)]
		public UploadVoiceCtx UploadCtx
		{
			get
			{
				return this._UploadCtx;
			}
			set
			{
				this._UploadCtx = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
