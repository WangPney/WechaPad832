using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ExchangeEmotionPackResponse")]
	[Serializable]
	public class ExchangeEmotionPackResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private EmotionCDNUrl _DownloadInfo;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "DownloadInfo", DataFormat = DataFormat.Default)]
		public EmotionCDNUrl DownloadInfo
		{
			get
			{
				return this._DownloadInfo;
			}
			set
			{
				this._DownloadInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
