using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsObjectDetailResponse")]
	[Serializable]
	public class SnsObjectDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SnsObject _Object;

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

		[ProtoMember(2, IsRequired = true, Name = "Object", DataFormat = DataFormat.Default)]
		public SnsObject Object
		{
			get
			{
				return this._Object;
			}
			set
			{
				this._Object = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
