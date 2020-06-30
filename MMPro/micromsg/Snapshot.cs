using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Snapshot")]
	[Serializable]
	public class Snapshot : IExtensible
	{
		private uint _ProductCount;

		private readonly List<Production> _Productions = new List<Production>();

		private Express _Express = null;

		private Address _Address = null;

		private readonly List<Receipt> _Receipt = new List<Receipt>();

		private uint _ReceiptCount = 0u;

		private string _LockId = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ProductCount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "Productions", DataFormat = DataFormat.Default)]
		public List<Production> Productions
		{
			get
			{
				return this._Productions;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Express", DataFormat = DataFormat.Default), DefaultValue(null)]
		public Express Express
		{
			get
			{
				return this._Express;
			}
			set
			{
				this._Express = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Address", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(5, Name = "Receipt", DataFormat = DataFormat.Default)]
		public List<Receipt> Receipt
		{
			get
			{
				return this._Receipt;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ReceiptCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ReceiptCount
		{
			get
			{
				return this._ReceiptCount;
			}
			set
			{
				this._ReceiptCount = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "LockId", DataFormat = DataFormat.Default), DefaultValue("")]
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
