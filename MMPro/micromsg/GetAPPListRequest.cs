using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetAPPListRequest")]
	[Serializable]
	public class GetAPPListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Hash;

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

		[ProtoMember(2, IsRequired = true, Name = "Hash", DataFormat = DataFormat.TwosComplement)]
		public uint Hash
		{
			get
			{
				return this._Hash;
			}
			set
			{
				this._Hash = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
