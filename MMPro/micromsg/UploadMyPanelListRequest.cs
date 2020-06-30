using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "UploadMyPanelListRequest")]
	[Serializable]
	public class UploadMyPanelListRequest : IExtensible
	{
		private uint _OpCode;

		private readonly List<string> _ProductIDList = new List<string>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(2, Name = "ProductIDList", DataFormat = DataFormat.Default)]
		public List<string> ProductIDList
		{
			get
			{
				return this._ProductIDList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
