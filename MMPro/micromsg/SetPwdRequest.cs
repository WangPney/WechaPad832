using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SetPwdRequest")]
	[Serializable]
	public class SetPwdRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Password = "";

		private string _Ticket = "";

		private SKBuiltinBuffer_t _AutoAuthKey = null;

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

		[ProtoMember(2, IsRequired = false, Name = "Password", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				this._Password = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Ticket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Ticket
		{
			get
			{
				return this._Ticket;
			}
			set
			{
				this._Ticket = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "AutoAuthKey", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t AutoAuthKey
		{
			get
			{
				return this._AutoAuthKey;
			}
			set
			{
				this._AutoAuthKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
