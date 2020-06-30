using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CheckUnBindResponse")]
	[Serializable]
	public class CheckUnBindResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _RandomPasswd = "";

		private string _CanUnbindNotice = "";

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

		[ProtoMember(2, IsRequired = false, Name = "RandomPasswd", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RandomPasswd
		{
			get
			{
				return this._RandomPasswd;
			}
			set
			{
				this._RandomPasswd = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "CanUnbindNotice", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CanUnbindNotice
		{
			get
			{
				return this._CanUnbindNotice;
			}
			set
			{
				this._CanUnbindNotice = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
