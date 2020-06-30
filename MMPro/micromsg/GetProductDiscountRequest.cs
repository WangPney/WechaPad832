using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetProductDiscountRequest")]
	[Serializable]
	public class GetProductDiscountRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _LockId = "";

		private string _Url = "";

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

		[ProtoMember(2, IsRequired = false, Name = "LockId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LockId
		{
			get
			{
				return this._LockId;
			}
			set
			{
				this._LockId = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
