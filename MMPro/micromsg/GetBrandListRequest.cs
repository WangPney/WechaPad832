using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetBrandListRequest")]
	[Serializable]
	public class GetBrandListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _UserName = "";

		private SKBuiltinBuffer_t _RequestBuffer = null;

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

		[ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "RequestBuffer", DataFormat = DataFormat.Default), DefaultValue(null)]
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
