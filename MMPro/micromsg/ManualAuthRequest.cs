using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ManualAuthRequest")]
	[Serializable]
	public class ManualAuthRequest : IExtensible
	{
		private ManualAuthRsaReqData _RsaReqData;

		private ManualAuthAesReqData _AesReqData;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RsaReqData", DataFormat = DataFormat.Default)]
		public ManualAuthRsaReqData RsaReqData
		{
			get
			{
				return this._RsaReqData;
			}
			set
			{
				this._RsaReqData = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "AesReqData", DataFormat = DataFormat.Default)]
		public ManualAuthAesReqData AesReqData
		{
			get
			{
				return this._AesReqData;
			}
			set
			{
				this._AesReqData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
