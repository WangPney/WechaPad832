using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsPostResponse")]
	[Serializable]
	public class SnsPostResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SnsObject _SnsObject;

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

		[ProtoMember(2, IsRequired = true, Name = "SnsObject", DataFormat = DataFormat.Default)]
		public SnsObject SnsObject
		{
			get
			{
				return this._SnsObject;
			}
			set
			{
				this._SnsObject = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
