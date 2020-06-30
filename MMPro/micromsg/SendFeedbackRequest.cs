using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendFeedbackRequest")]
	[Serializable]
	public class SendFeedbackRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _MachineType = "";

		private string _Content = "";

		private uint _ReportType = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "MachineType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MachineType
		{
			get
			{
				return this._MachineType;
			}
			set
			{
				this._MachineType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ReportType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ReportType
		{
			get
			{
				return this._ReportType;
			}
			set
			{
				this._ReportType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
