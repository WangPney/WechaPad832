using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchEmojiBackupRequest")]
	[Serializable]
	public class BatchEmojiBackupRequest : IExtensible
	{
		private readonly List<string> _Md5List = new List<string>();

		private IExtension extensionObject;

		[ProtoMember(1, Name = "Md5List", DataFormat = DataFormat.Default)]
		public List<string> Md5List
		{
			get
			{
				return this._Md5List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
