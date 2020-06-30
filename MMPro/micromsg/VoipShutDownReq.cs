using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoipShutDownReq")]
	[Serializable]
	public class VoipShutDownReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FromUsername = "";

		private int _RoomId;

		private long _RoomKey;

		private VoipStatReportData _ReportData;

		private ulong _Timestamp64 = 0uL;

		private uint _Duration = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "FromUsername", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FromUsername
		{
			get
			{
				return this._FromUsername;
			}
			set
			{
				this._FromUsername = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
		public int RoomId
		{
			get
			{
				return this._RoomId;
			}
			set
			{
				this._RoomId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
		public long RoomKey
		{
			get
			{
				return this._RoomKey;
			}
			set
			{
				this._RoomKey = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ReportData", DataFormat = DataFormat.Default)]
		public VoipStatReportData ReportData
		{
			get
			{
				return this._ReportData;
			}
			set
			{
				this._ReportData = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Timestamp64", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong Timestamp64
		{
			get
			{
				return this._Timestamp64;
			}
			set
			{
				this._Timestamp64 = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Duration", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Duration
		{
			get
			{
				return this._Duration;
			}
			set
			{
				this._Duration = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
