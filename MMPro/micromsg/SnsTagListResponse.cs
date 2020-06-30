using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTagListResponse")]
	[Serializable]
	public class SnsTagListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _OpCode;

		private string _TagListMd5 = "";

		private uint _Count;

		private readonly List<SnsTag> _List = new List<SnsTag>();

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

		[ProtoMember(3, IsRequired = false, Name = "TagListMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TagListMd5
		{
			get
			{
				return this._TagListMd5;
			}
			set
			{
				this._TagListMd5 = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, Name = "List", DataFormat = DataFormat.Default)]
		public List<SnsTag> List
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
