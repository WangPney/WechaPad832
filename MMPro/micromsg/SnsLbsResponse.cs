using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SnsLbsResponse")]
	[Serializable]
	public class SnsLbsResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ContactCount;

		private readonly List<SnsLbsContactInfo> _ContactList = new List<SnsLbsContactInfo>();

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
		public List<SnsLbsContactInfo> ContactList
		{
			get
			{
				return this._ContactList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
