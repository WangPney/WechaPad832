using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GenBizIapPrepayResponse")]
	[Serializable]
	public class GenBizIapPrepayResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ProductId = "";

		private string _ExtInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ProductId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				this._ProductId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
