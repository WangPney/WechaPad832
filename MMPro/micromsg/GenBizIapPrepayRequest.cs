using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GenBizIapPrepayRequest")]
	[Serializable]
	public class GenBizIapPrepayRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppId = "";

		private string _NonceStr = "";

		private string _TimeStamp = "";

		private string _Package = "";

		private string _PaySign = "";

		private string _SignType = "";

		private string _StepInUrl = "";

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

		[ProtoMember(2, IsRequired = false, Name = "AppId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppId
		{
			get
			{
				return this._AppId;
			}
			set
			{
				this._AppId = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "NonceStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NonceStr
		{
			get
			{
				return this._NonceStr;
			}
			set
			{
				this._NonceStr = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TimeStamp
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

		[ProtoMember(5, IsRequired = false, Name = "Package", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Package
		{
			get
			{
				return this._Package;
			}
			set
			{
				this._Package = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "PaySign", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PaySign
		{
			get
			{
				return this._PaySign;
			}
			set
			{
				this._PaySign = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "SignType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SignType
		{
			get
			{
				return this._SignType;
			}
			set
			{
				this._SignType = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "StepInUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StepInUrl
		{
			get
			{
				return this._StepInUrl;
			}
			set
			{
				this._StepInUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
