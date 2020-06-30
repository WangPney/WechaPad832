using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "WxVerifyCodeRespInfo")]
	[Serializable]
	public class WxVerifyCodeRespInfo : IExtensible
	{
		private string _VerifySignature = "";

		private SKBuiltinBuffer_t _VerifyBuff;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "VerifySignature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifySignature
		{
			get
			{
				return this._VerifySignature;
			}
			set
			{
				this._VerifySignature = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "VerifyBuff", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t VerifyBuff
		{
			get
			{
				return this._VerifyBuff;
			}
			set
			{
				this._VerifyBuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
