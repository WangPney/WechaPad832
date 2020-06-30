using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CheckLoginQRCodeResponse")]
	[Serializable]
	public class CheckLoginQRCodeResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private LoginQRCodeNotifyPkg _NotifyPkg = null;

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

		[ProtoMember(3, IsRequired = false, Name = "NotifyPkg", DataFormat = DataFormat.Default), DefaultValue(null)]
		public LoginQRCodeNotifyPkg NotifyPkg
		{
			get
			{
				return this._NotifyPkg;
			}
			set
			{
				this._NotifyPkg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
