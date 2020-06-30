using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetQRCodeRequest")]
	[Serializable]
	public class GetQRCodeRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _UserName;

		private uint _Style;

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

		[ProtoMember(2, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Style", DataFormat = DataFormat.TwosComplement)]
		public uint Style
		{
			get
			{
				return this._Style;
			}
			set
			{
				this._Style = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
