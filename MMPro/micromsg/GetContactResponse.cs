using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetContactResponse")]
	[Serializable]
	public class GetContactResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ContactCount;

		private readonly List<ModContact> _ContactList = new List<ModContact>();

		private readonly List<int> _Ret = new List<int>();

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

		[ProtoMember(2, IsRequired = true, Name = "ContactCount", DataFormat = DataFormat.TwosComplement)]
		public uint ContactCount
		{
			get
			{
				return this._ContactCount;
			}
			set
			{
				this._ContactCount = value;
			}
		}

		[ProtoMember(3, Name = "ContactList", DataFormat = DataFormat.Default)]
		public List<ModContact> ContactList
		{
			get
			{
				return this._ContactList;
			}
		}

		[ProtoMember(4, Name = "Ret", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<int> Ret
		{
			get
			{
				return this._Ret;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
