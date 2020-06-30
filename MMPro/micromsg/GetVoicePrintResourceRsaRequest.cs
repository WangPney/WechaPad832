using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetVoicePrintResourceRsaRequest")]
	[Serializable]
	public class GetVoicePrintResourceRsaRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _ResScence;

		private string _VerifyTicket = "";

		private SKBuiltinBuffer_t _RandomEncryKey;

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

		[ProtoMember(2, IsRequired = true, Name = "ResScence", DataFormat = DataFormat.TwosComplement)]
		public uint ResScence
		{
			get
			{
				return this._ResScence;
			}
			set
			{
				this._ResScence = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "VerifyTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifyTicket
		{
			get
			{
				return this._VerifyTicket;
			}
			set
			{
				this._VerifyTicket = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "RandomEncryKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RandomEncryKey
		{
			get
			{
				return this._RandomEncryKey;
			}
			set
			{
				this._RandomEncryKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
