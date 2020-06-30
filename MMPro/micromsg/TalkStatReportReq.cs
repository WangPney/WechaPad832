using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TalkStatReportReq")]
	[Serializable]
	public class TalkStatReportReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _DataNum;

		private readonly List<TalkStatReportData> _ReportData = new List<TalkStatReportData>();

		private uint _Scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "DataNum", DataFormat = DataFormat.TwosComplement)]
		public int DataNum
		{
			get
			{
				return this._DataNum;
			}
			set
			{
				this._DataNum = value;
			}
		}

		[ProtoMember(3, Name = "ReportData", DataFormat = DataFormat.Default)]
		public List<TalkStatReportData> ReportData
		{
			get
			{
				return this._ReportData;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
