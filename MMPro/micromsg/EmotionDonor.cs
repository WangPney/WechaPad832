using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "EmotionDonor")]
	[Serializable]
	public class EmotionDonor : IExtensible
	{
		private string _HeadUrl;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "HeadUrl", DataFormat = DataFormat.Default)]
		public string HeadUrl
		{
			get
			{
				return this._HeadUrl;
			}
			set
			{
				this._HeadUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
