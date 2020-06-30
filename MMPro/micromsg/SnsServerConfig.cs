using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsServerConfig")]
	[Serializable]
	public class SnsServerConfig : IExtensible
	{
		private int _PostMentionLimit = 0;

		private int _CopyAndPasteWordLimit = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "PostMentionLimit", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int PostMentionLimit
		{
			get
			{
				return this._PostMentionLimit;
			}
			set
			{
				this._PostMentionLimit = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "CopyAndPasteWordLimit", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CopyAndPasteWordLimit
		{
			get
			{
				return this._CopyAndPasteWordLimit;
			}
			set
			{
				this._CopyAndPasteWordLimit = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
