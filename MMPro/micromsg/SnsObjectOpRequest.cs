using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SnsObjectOpRequest")]
	[Serializable]
	public class SnsObjectOpRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpCount;

		private readonly List<SnsObjectOp> _OpList = new List<SnsObjectOp>();

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

		[ProtoMember(2, IsRequired = true, Name = "OpCount", DataFormat = DataFormat.TwosComplement)]
		public uint OpCount
		{
			get
			{
				return this._OpCount;
			}
			set
			{
				this._OpCount = value;
			}
		}

		[ProtoMember(3, Name = "OpList", DataFormat = DataFormat.Default)]
		public List<SnsObjectOp> OpList
		{
			get
			{
				return this._OpList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
