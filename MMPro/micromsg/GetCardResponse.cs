using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCardResponse")]
	[Serializable]
	public class GetCardResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _Image;

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

		[ProtoMember(2, IsRequired = true, Name = "Image", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				this._Image = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
