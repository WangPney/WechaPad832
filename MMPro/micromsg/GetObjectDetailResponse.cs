using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetObjectDetailResponse")]
	[Serializable]
	public class GetObjectDetailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _DetailInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "DetailInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DetailInfo
		{
			get
			{
				return this._DetailInfo;
			}
			set
			{
				this._DetailInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
