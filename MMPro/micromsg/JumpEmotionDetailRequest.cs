using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "JumpEmotionDetailRequest")]
	[Serializable]
	public class JumpEmotionDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Url;

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

		[ProtoMember(2, IsRequired = true, Name = "Url", DataFormat = DataFormat.Default)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
