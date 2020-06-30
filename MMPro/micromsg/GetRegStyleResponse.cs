using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetRegStyleResponse")]
	[Serializable]
	public class GetRegStyleResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private ShowStyleKey _RegStyle;

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

		[ProtoMember(2, IsRequired = true, Name = "RegStyle", DataFormat = DataFormat.Default)]
		public ShowStyleKey RegStyle
		{
			get
			{
				return this._RegStyle;
			}
			set
			{
				this._RegStyle = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
