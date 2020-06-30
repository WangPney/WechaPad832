using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "RecommendGroups")]
	[Serializable]
	public class RecommendGroups : IExtensible
	{
		private uint _GroupCount;

		private readonly List<RecommendGroup> _Groups = new List<RecommendGroup>();

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

		[ProtoMember(2, Name = "Groups", DataFormat = DataFormat.Default)]
		public List<RecommendGroup> Groups
		{
			get
			{
				return this._Groups;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
