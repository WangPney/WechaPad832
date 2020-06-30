using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindGoogleContactRequest")]
	[Serializable]
	public class BindGoogleContactRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Opcode;

		private string _GoogleContactName = "";

		private uint _Force;

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

		[ProtoMember(2, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
		public uint Opcode
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

		[ProtoMember(3, IsRequired = false, Name = "GoogleContactName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GoogleContactName
		{
			get
			{
				return this._GoogleContactName;
			}
			set
			{
				this._GoogleContactName = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Force", DataFormat = DataFormat.TwosComplement)]
		public uint Force
		{
			get
			{
				return this._Force;
			}
			set
			{
				this._Force = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
