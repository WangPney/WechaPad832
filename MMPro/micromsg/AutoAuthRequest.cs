using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AutoAuthRequest")]
	[Serializable]
	public class AutoAuthRequest : IExtensible
	{
		private AutoAuthRsaReqData _RsaReqData;

		private AutoAuthAesReqData _AesReqData;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RsaReqData", DataFormat = DataFormat.Default)]
		public AutoAuthRsaReqData RsaReqData
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
		public AutoAuthAesReqData AesReqData
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
