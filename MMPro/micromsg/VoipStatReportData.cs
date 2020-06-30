using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "VoipStatReportData")]
	[Serializable]
	public class VoipStatReportData : IExtensible
	{
		private SKBuiltinString_t _StatReport;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "StatReport", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t StatReport
		{
			get
			{
				return this._StatReport;
			}
			set
			{
				this._StatReport = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
