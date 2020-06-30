using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLastestExpressInfoRequest")]
	[Serializable]
	public class GetLastestExpressInfoRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ProductId = "";

		private string _LockId = "";

		private Address _Address;

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

		[ProtoMember(3, IsRequired = false, Name = "LockId", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(4, IsRequired = true, Name = "Address", DataFormat = DataFormat.Default)]
		public Address Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this._Address = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
