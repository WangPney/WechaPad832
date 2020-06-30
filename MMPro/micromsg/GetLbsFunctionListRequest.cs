using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetLbsFunctionListRequest")]
	[Serializable]
	public class GetLbsFunctionListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private LbsLocation _Loc;

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

		[ProtoMember(2, IsRequired = true, Name = "Loc", DataFormat = DataFormat.Default)]
		public LbsLocation Loc
		{
			get
			{
				return this._Loc;
			}
			set
			{
				this._Loc = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
