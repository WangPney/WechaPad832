using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ExtDeviceLoginConfirmGetResponse")]
	[Serializable]
	public class ExtDeviceLoginConfirmGetResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private ExtDeviceLoginConfirmOKRet _OKRet = null;

		private ExtDeviceLoginConfirmErrorRet _ErrorRet = null;

		private ExtDeviceLoginConfirmExpiredRet _ExpiredRet = null;

		private string _DeviceNameStr = "";

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

		[ProtoMember(2, IsRequired = false, Name = "OKRet", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ExtDeviceLoginConfirmOKRet OKRet
		{
			get
			{
				return this._OKRet;
			}
			set
			{
				this._OKRet = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ErrorRet", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ExtDeviceLoginConfirmErrorRet ErrorRet
		{
			get
			{
				return this._ErrorRet;
			}
			set
			{
				this._ErrorRet = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ExpiredRet", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ExtDeviceLoginConfirmExpiredRet ExpiredRet
		{
			get
			{
				return this._ExpiredRet;
			}
			set
			{
				this._ExpiredRet = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "DeviceNameStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceNameStr
		{
			get
			{
				return this._DeviceNameStr;
			}
			set
			{
				this._DeviceNameStr = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
