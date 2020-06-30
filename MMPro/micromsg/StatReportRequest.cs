using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "StatReportRequest")]
	[Serializable]
	public class StatReportRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private StatReportInfo _Info;

		private StatReportExtInfo _ExtInfo;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Info", DataFormat = DataFormat.Default)]
		public StatReportInfo Info
		{
			get
			{
				return this._Info;
			}
			set
			{
				this._Info = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ExtInfo", DataFormat = DataFormat.Default)]
		public StatReportExtInfo ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
