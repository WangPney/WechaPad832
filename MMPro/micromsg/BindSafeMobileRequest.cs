using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindSafeMobileRequest")]
	[Serializable]
	public class BindSafeMobileRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Mobile = "";

		private int _Opcode;

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

		[ProtoMember(2, IsRequired = false, Name = "Mobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Mobile
		{
			get
			{
				return this._Mobile;
			}
			set
			{
				this._Mobile = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
		public int Opcode
		{
			get
			{
				return this._Opcode;
			}
			set
			{
				this._Opcode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
