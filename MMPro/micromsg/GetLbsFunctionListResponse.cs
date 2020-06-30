using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLbsFunctionListResponse")]
	[Serializable]
	public class GetLbsFunctionListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _LbsFunctionList = "";

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

		[ProtoMember(2, IsRequired = false, Name = "LbsFunctionList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LbsFunctionList
		{
			get
			{
				return this._LbsFunctionList;
			}
			set
			{
				this._LbsFunctionList = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
