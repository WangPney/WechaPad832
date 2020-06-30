using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetObjectDetailRequest")]
	[Serializable]
	public class GetObjectDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _NBSId;

		private uint _ObjectId;

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

		[ProtoMember(2, IsRequired = true, Name = "NBSId", DataFormat = DataFormat.TwosComplement)]
		public uint NBSId
		{
			get
			{
				return this._NBSId;
			}
			set
			{
				this._NBSId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ObjectId", DataFormat = DataFormat.TwosComplement)]
		public uint ObjectId
		{
			get
			{
				return this._ObjectId;
			}
			set
			{
				this._ObjectId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
