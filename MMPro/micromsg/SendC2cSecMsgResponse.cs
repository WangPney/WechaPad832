using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendC2cSecMsgResponse")]
	[Serializable]
	public class SendC2cSecMsgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _ErrCode = 0;

		private string _ErrMsg = "";

		private string _MsgId = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ErrCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int ErrCode
		{
			get
			{
				return this._ErrCode;
			}
			set
			{
				this._ErrCode = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ErrMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ErrMsg
		{
			get
			{
				return this._ErrMsg;
			}
			set
			{
				this._ErrMsg = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "MsgId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
