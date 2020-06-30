using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BackupEmojiOperateRequest")]
	[Serializable]
	public class BackupEmojiOperateRequest : IExtensible
	{
		private readonly List<string> _Md5List = new List<string>();

		private uint _Opcode;

		private IExtension extensionObject;

		[ProtoMember(1, Name = "Md5List", DataFormat = DataFormat.Default)]
		public List<string> Md5List
		{
			get
			{
				return this._Md5List;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
		public uint Opcode
		{
			get
			{
				return this._Opcode;
			}
			set
			{
				this._Opcode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
