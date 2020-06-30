using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "BatchEmojiDownLoadRequest")]
	[Serializable]
	public class BatchEmojiDownLoadRequest : IExtensible
	{
		private uint _Index;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Index", DataFormat = DataFormat.TwosComplement)]
		public uint Index
		{
			get
			{
				return this._Index;
			}
			set
			{
				this._Index = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
