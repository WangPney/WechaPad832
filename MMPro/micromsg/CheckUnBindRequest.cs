using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "CheckUnBindRequest")]
	[Serializable]
	public class CheckUnBindRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _BindType;

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

		[ProtoMember(2, IsRequired = true, Name = "BindType", DataFormat = DataFormat.TwosComplement)]
		public int BindType
		{
			get
			{
				return this._BindType;
			}
			set
			{
				this._BindType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
