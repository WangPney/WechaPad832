using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SwitchPushMailRequest")]
	[Serializable]
	public class SwitchPushMailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _SwitchValue;

		private string _SecPwdMd5 = "";

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

		[ProtoMember(2, IsRequired = true, Name = "SwitchValue", DataFormat = DataFormat.TwosComplement)]
		public uint SwitchValue
		{
			get
			{
				return this._SwitchValue;
			}
			set
			{
				this._SwitchValue = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SecPwdMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SecPwdMd5
		{
			get
			{
				return this._SecPwdMd5;
			}
			set
			{
				this._SecPwdMd5 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
