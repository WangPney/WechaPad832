using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "EmotionBanner")]
	[Serializable]
	public class EmotionBanner : IExtensible
	{
		private EmotionSummary _BannerSummary;

		private EmotionBannerImg _BannerImg;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BannerSummary", DataFormat = DataFormat.Default)]
		public EmotionSummary BannerSummary
		{
			get
			{
				return this._BannerSummary;
			}
			set
			{
				this._BannerSummary = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "BannerImg", DataFormat = DataFormat.Default)]
		public EmotionBannerImg BannerImg
		{
			get
			{
				return this._BannerImg;
			}
			set
			{
				this._BannerImg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
