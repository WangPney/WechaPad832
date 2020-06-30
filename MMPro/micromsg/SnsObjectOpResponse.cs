using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SnsObjectOpResponse")]
	[Serializable]
	public class SnsObjectOpResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _OpCount;

		private readonly List<int> _OpRetList = new List<int>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
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

		[ProtoMember(3, Name = "OpRetList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<int> OpRetList
		{
			get
			{
				return this._OpRetList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
