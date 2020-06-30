using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsADCommentResponse")]
	[Serializable]
	public class SnsADCommentResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SnsADObject _SnsADObject;

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

		[ProtoMember(2, IsRequired = true, Name = "SnsADObject", DataFormat = DataFormat.Default)]
		public SnsADObject SnsADObject
		{
			get
			{
				return this._SnsADObject;
			}
			set
			{
				this._SnsADObject = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
