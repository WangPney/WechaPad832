using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTag")]
	[Serializable]
	public class SnsTag : IExtensible
	{
		private ulong _TagId;

		private string _TagName = "";

		private uint _Count;

		private readonly List<SKBuiltinString_t> _List = new List<SKBuiltinString_t>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "TagId", DataFormat = DataFormat.TwosComplement)]
		public ulong TagId
		{
			get
			{
				return this._TagId;
			}
			set
			{
				this._TagId = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "TagName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TagName
		{
			get
			{
				return this._TagName;
			}
			set
			{
				this._TagName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(4, Name = "List", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> List
		{
			get
			{
				return this._List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
