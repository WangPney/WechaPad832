using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTimeLineWithTypeRequest")]
	[Serializable]
	public class SnsTimeLineWithTypeRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private ulong _SelectType = 0uL;

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

		[ProtoMember(2, IsRequired = false, Name = "SelectType", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong SelectType
		{
			get
			{
				return this._SelectType;
			}
			set
			{
				this._SelectType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
