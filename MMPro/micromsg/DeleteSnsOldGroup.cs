using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "DeleteSnsOldGroup")]
	[Serializable]
	public class DeleteSnsOldGroup : IExtensible
	{
		private uint _GroupCount;

		private readonly List<ulong> _GroupIds = new List<ulong>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "GroupCount", DataFormat = DataFormat.TwosComplement)]
		public uint GroupCount
		{
			get
			{
				return this._GroupCount;
			}
			set
			{
				this._GroupCount = value;
			}
		}

		[ProtoMember(2, Name = "GroupIds", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<ulong> GroupIds
		{
			get
			{
				return this._GroupIds;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
