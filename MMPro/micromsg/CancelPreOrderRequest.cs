using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CancelPreOrderRequest")]
	[Serializable]
	public class CancelPreOrderRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _ProductCount;

		private readonly List<SampleProduct> _Product = new List<SampleProduct>();

		private string _LockId = "";

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

		[ProtoMember(2, IsRequired = true, Name = "ProductCount", DataFormat = DataFormat.TwosComplement)]
		public uint ProductCount
		{
			get
			{
				return this._ProductCount;
			}
			set
			{
				this._ProductCount = value;
			}
		}

		[ProtoMember(3, Name = "Product", DataFormat = DataFormat.Default)]
		public List<SampleProduct> Product
		{
			get
			{
				return this._Product;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "LockId", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
