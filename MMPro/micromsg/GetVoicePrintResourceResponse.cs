using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetVoicePrintResourceResponse")]
	[Serializable]
	public class GetVoicePrintResourceResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private ResourceCtx _ResourceData;

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

		[ProtoMember(2, IsRequired = true, Name = "ResourceData", DataFormat = DataFormat.Default)]
		public ResourceCtx ResourceData
		{
			get
			{
				return this._ResourceData;
			}
			set
			{
				this._ResourceData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
