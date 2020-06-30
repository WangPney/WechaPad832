using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "CmdList")]
	[Serializable]
	public class CmdList : IExtensible
	{
		private uint _Count;

		private readonly List<CmdItem> _List = new List<CmdItem>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(2, Name = "List", DataFormat = DataFormat.Default)]
		public List<CmdItem> List
		{
			get
			{
				return this._List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
