using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLastestExpressInfoResponse")]
	[Serializable]
	public class GetLastestExpressInfoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<Express> _ExpressList = new List<Express>();

		private uint _ExpressCount = 0u;

		private int _RetCode = 0;

		private string _RetMsg = "";

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

		[ProtoMember(2, Name = "ExpressList", DataFormat = DataFormat.Default)]
		public List<Express> ExpressList
		{
			get
			{
				return this._ExpressList;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ExpressCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ExpressCount
		{
			get
			{
				return this._ExpressCount;
			}
			set
			{
				this._ExpressCount = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "RetCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int RetCode
		{
			get
			{
				return this._RetCode;
			}
			set
			{
				this._RetCode = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "RetMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RetMsg
		{
			get
			{
				return this._RetMsg;
			}
			set
			{
				this._RetMsg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
