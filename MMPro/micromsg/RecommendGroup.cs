using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "RecommendGroup")]
	[Serializable]
	public class RecommendGroup : IExtensible
	{
		private SKBuiltinString_t _GroupName;

		private uint _MemCount;

		private readonly List<SearchOrRecommendItem> _Members = new List<SearchOrRecommendItem>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "GroupName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t GroupName
		{
			get
			{
				return this._GroupName;
			}
			set
			{
				this._GroupName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MemCount", DataFormat = DataFormat.TwosComplement)]
		public uint MemCount
		{
			get
			{
				return this._MemCount;
			}
			set
			{
				this._MemCount = value;
			}
		}

		[ProtoMember(3, Name = "Members", DataFormat = DataFormat.Default)]
		public List<SearchOrRecommendItem> Members
		{
			get
			{
				return this._Members;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
