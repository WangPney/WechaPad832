using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ManualAuthAesReqData")]
	[Serializable]
	public class ManualAuthAesReqData : IExtensible
	{
		private BaseRequest _BaseRequest;

		private BaseAuthReqInfo _BaseReqInfo = null;

		private string _IMEI = "";

		private string _SoftType = "";

		private uint _BuiltinIPSeq;

		private string _ClientSeqID = "";

		private string _Signature = "";

		private string _DeviceName = "";

		private string _DeviceType = "";

		private string _Language = "";

		private string _TimeZone = "";

		private int _Channel = 0;

		private uint _TimeStamp = 0u;

		private string _DeviceBrand = "";

		private string _DeviceModel = "";

		private string _OSType = "";

		private string _RealCountry = "";

		private string _BundleID = "";

		private string _AdSource = "";

		private string _IPhoneVer = "";

		private uint _InputType;

		private SKBuiltinBuffer_t _Clientcheckdat = null;

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

		[ProtoMember(2, IsRequired = false, Name = "BaseReqInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BaseAuthReqInfo BaseReqInfo
		{
			get
			{
				return this._BaseReqInfo;
			}
			set
			{
				this._BaseReqInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "IMEI", DataFormat = DataFormat.Default), DefaultValue("")]
		public string IMEI
		{
			get
			{
				return this._IMEI;
			}
			set
			{
				this._IMEI = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "SoftType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SoftType
		{
			get
			{
				return this._SoftType;
			}
			set
			{
				this._SoftType = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "BuiltinIPSeq", DataFormat = DataFormat.TwosComplement)]
		public uint BuiltinIPSeq
		{
			get
			{
				return this._BuiltinIPSeq;
			}
			set
			{
				this._BuiltinIPSeq = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ClientSeqID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientSeqID
		{
			get
			{
				return this._ClientSeqID;
			}
			set
			{
				this._ClientSeqID = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Signature
		{
			get
			{
				return this._Signature;
			}
			set
			{
				this._Signature = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "DeviceName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				this._DeviceName = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "DeviceType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceType
		{
			get
			{
				return this._DeviceType;
			}
			set
			{
				this._DeviceType = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "Language", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Language
		{
			get
			{
				return this._Language;
			}
			set
			{
				this._Language = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "TimeZone", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TimeZone
		{
			get
			{
				return this._TimeZone;
			}
			set
			{
				this._TimeZone = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "Channel", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Channel
		{
			get
			{
				return this._Channel;
			}
			set
			{
				this._Channel = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "DeviceBrand", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceBrand
		{
			get
			{
				return this._DeviceBrand;
			}
			set
			{
				this._DeviceBrand = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "DeviceModel", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceModel
		{
			get
			{
				return this._DeviceModel;
			}
			set
			{
				this._DeviceModel = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "OSType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OSType
		{
			get
			{
				return this._OSType;
			}
			set
			{
				this._OSType = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "RealCountry", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RealCountry
		{
			get
			{
				return this._RealCountry;
			}
			set
			{
				this._RealCountry = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "BundleID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BundleID
		{
			get
			{
				return this._BundleID;
			}
			set
			{
				this._BundleID = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "AdSource", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AdSource
		{
			get
			{
				return this._AdSource;
			}
			set
			{
				this._AdSource = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "IPhoneVer", DataFormat = DataFormat.Default), DefaultValue("")]
		public string IPhoneVer
		{
			get
			{
				return this._IPhoneVer;
			}
			set
			{
				this._IPhoneVer = value;
			}
		}

		[ProtoMember(22, IsRequired = true, Name = "InputType", DataFormat = DataFormat.TwosComplement)]
		public uint InputType
		{
			get
			{
				return this._InputType;
			}
			set
			{
				this._InputType = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "Clientcheckdat", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Clientcheckdat
		{
			get
			{
				return this._Clientcheckdat;
			}
			set
			{
				this._Clientcheckdat = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
