using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTagMemMutilSetRequest")]
	[Serializable]
	public class SnsTagMemMutilSetRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ModUserName = "";

		private uint _Count;

		private readonly List<SKBuiltinUint64_t> _TagIdList = new List<SKBuiltinUint64_t>();

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
