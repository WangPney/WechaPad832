using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoAddRequest")]
	[Serializable]
	public class RcptInfoAddRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private RcptInfoNode _rcptinfo;

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

		[ProtoMember(2, IsRequired = true, Name = "rcptinfo", DataFormat = DataFormat.Default)]
		public RcptInfoNode rcptinfo
		{
			get
			{
				return this._rcptinfo;
			}
			set
			{
				this._rcptinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
