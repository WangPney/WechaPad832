using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetQQGroupRequest")]
	[Serializable]
	public class GetQQGroupRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpType;

		private uint _GroupID;

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

		[ProtoMember(2, IsRequired = true, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
		public uint OpType
		{
			get
			{
				return this._OpType;
			}
			set
			{
				this._OpType = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "GroupID", DataFormat = DataFormat.TwosComplement)]
		public uint GroupID
		{
			get
			{
				return this._GroupID;
			}
			set
			{
				this._GroupID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
