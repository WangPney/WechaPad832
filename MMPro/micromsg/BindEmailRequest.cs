using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindEmailRequest")]
	[Serializable]
	public class BindEmailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpCode;

		private string _Email = "";

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

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Email", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this._Email = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
