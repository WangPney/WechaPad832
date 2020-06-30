using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetCardCountRequest")]
	[Serializable]
	public class GetCardCountRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
