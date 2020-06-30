using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetBrandListResponse")]
	[Serializable]
	public class GetBrandListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _BrandList = "";

		private SKBuiltinBuffer_t _RequestBuffer;

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

		[ProtoMember(2, IsRequired = false, Name = "BrandList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BrandList
		{
			get
			{
				return this._BrandList;
			}
			set
			{
				this._BrandList = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RequestBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RequestBuffer
		{
			get
			{
				return this._RequestBuffer;
			}
			set
			{
				this._RequestBuffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
