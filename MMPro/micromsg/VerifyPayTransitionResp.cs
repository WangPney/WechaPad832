using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyPayTransitionResp")]
	[Serializable]
	public class VerifyPayTransitionResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ResultMsg = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ResultMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ResultMsg
		{
			get
			{
				return this._ResultMsg;
			}
			set
			{
				this._ResultMsg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
