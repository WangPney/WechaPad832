using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTagMemMutilSetResponse")]
	[Serializable]
	public class SnsTagMemMutilSetResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ModUserName = "";

		private uint _Count;

		private readonly List<SKBuiltinUint64_t> _TagIdList = new List<SKBuiltinUint64_t>();

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

		[ProtoMember(2, IsRequired = false, Name = "ModUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ModUserName
		{
			get
			{
				return this._ModUserName;
			}
			set
			{
				this._ModUserName = value;
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

		[ProtoMember(4, Name = "TagIdList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinUint64_t> TagIdList
		{
			get
			{
				return this._TagIdList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
