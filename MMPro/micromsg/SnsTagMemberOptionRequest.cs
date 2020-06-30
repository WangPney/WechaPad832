using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTagMemberOptionRequest")]
	[Serializable]
	public class SnsTagMemberOptionRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpCode;

		private ulong _TagId;

		private string _TagName = "";

		private uint _Count;

		private readonly List<SKBuiltinString_t> _List = new List<SKBuiltinString_t>();

		private uint _Scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TagId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "TagName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(5, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, Name = "List", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> List
		{
			get
			{
				return this._List;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
