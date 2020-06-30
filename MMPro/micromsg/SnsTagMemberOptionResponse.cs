using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsTagMemberOptionResponse")]
	[Serializable]
	public class SnsTagMemberOptionResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SnsTag _SnsTag;

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

		[ProtoMember(2, IsRequired = true, Name = "SnsTag", DataFormat = DataFormat.Default)]
		public SnsTag SnsTag
		{
			get
			{
				return this._SnsTag;
			}
			set
			{
				this._SnsTag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
