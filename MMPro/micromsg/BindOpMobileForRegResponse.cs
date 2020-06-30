using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindOpMobileForRegResponse")]
	[Serializable]
	public class BindOpMobileForRegResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ticket = "";

		private string _SmsNo = "";

		private uint _NeedSetPwd = 0u;

		private string _Pwd = "";

		private string _Username = "";

		private HostList _NewHostList = null;

		private BuiltinIPList _BuiltinIPList = null;

		private NetworkControl _NetworkControl = null;

		private string _AuthTicket = "";

		private uint _SafeDevice = 0u;

		private string _CC = "";

		private uint _ObsoleteItem1 = 0u;

		private SafeDeviceList _SafeDeviceList = null;

		private string _PureMobile = "";

		private string _FormatedMobile = "";

		private ShowStyleKey _ShowStyle = null;

		private uint _MmtlsControlBitFlag = 0u;

		private string _SmsUpCode = "";

		private string _SmsUpMobile = "";

		private uint _MobileCheckType = 0u;

		private string _regSessionId = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ticket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ticket
		{
			get
			{
				return this._ticket;
			}
			set
			{
				this._ticket = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SmsNo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmsNo
		{
			get
			{
				return this._SmsNo;
			}
			set
			{
				this._SmsNo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "NeedSetPwd", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NeedSetPwd
		{
			get
			{
				return this._NeedSetPwd;
			}
			set
			{
				this._NeedSetPwd = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Pwd", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				this._Pwd = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Username", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this._Username = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "NewHostList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public HostList NewHostList
		{
			get
			{
				return this._NewHostList;
			}
			set
			{
				this._NewHostList = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "BuiltinIPList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BuiltinIPList BuiltinIPList
		{
			get
			{
				return this._BuiltinIPList;
			}
			set
			{
				this._BuiltinIPList = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "NetworkControl", DataFormat = DataFormat.Default), DefaultValue(null)]
		public NetworkControl NetworkControl
		{
			get
			{
				return this._NetworkControl;
			}
			set
			{
				this._NetworkControl = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "AuthTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AuthTicket
		{
			get
			{
				return this._AuthTicket;
			}
			set
			{
				this._AuthTicket = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "SafeDevice", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SafeDevice
		{
			get
			{
				return this._SafeDevice;
			}
			set
			{
				this._SafeDevice = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "CC", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CC
		{
			get
			{
				return this._CC;
			}
			set
			{
				this._CC = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "ObsoleteItem1", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ObsoleteItem1
		{
			get
			{
				return this._ObsoleteItem1;
			}
			set
			{
				this._ObsoleteItem1 = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "SafeDeviceList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SafeDeviceList SafeDeviceList
		{
			get
			{
				return this._SafeDeviceList;
			}
			set
			{
				this._SafeDeviceList = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "PureMobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PureMobile
		{
			get
			{
				return this._PureMobile;
			}
			set
			{
				this._PureMobile = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "FormatedMobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FormatedMobile
		{
			get
			{
				return this._FormatedMobile;
			}
			set
			{
				this._FormatedMobile = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "ShowStyle", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ShowStyleKey ShowStyle
		{
			get
			{
				return this._ShowStyle;
			}
			set
			{
				this._ShowStyle = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "MmtlsControlBitFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MmtlsControlBitFlag
		{
			get
			{
				return this._MmtlsControlBitFlag;
			}
			set
			{
				this._MmtlsControlBitFlag = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "SmsUpCode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmsUpCode
		{
			get
			{
				return this._SmsUpCode;
			}
			set
			{
				this._SmsUpCode = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "SmsUpMobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmsUpMobile
		{
			get
			{
				return this._SmsUpMobile;
			}
			set
			{
				this._SmsUpMobile = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "MobileCheckType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MobileCheckType
		{
			get
			{
				return this._MobileCheckType;
			}
			set
			{
				this._MobileCheckType = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "regSessionId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string regSessionId
		{
			get
			{
				return this._regSessionId;
			}
			set
			{
				this._regSessionId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
