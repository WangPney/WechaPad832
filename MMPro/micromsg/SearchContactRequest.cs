using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchContactRequest")]
	[Serializable]
	public class SearchContactRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _UserName;

		private uint _OpCode = 0u;

		private SKBuiltinBuffer_t _ReqBuf = null;

		private uint _FromScene = 0u;

		private uint _SearchScene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
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

		[ProtoMember(3, IsRequired = false, Name = "OpCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(4, IsRequired = false, Name = "ReqBuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t ReqBuf
		{
			get
			{
				return this._ReqBuf;
			}
			set
			{
				this._ReqBuf = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "FromScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FromScene
		{
			get
			{
				return this._FromScene;
			}
			set
			{
				this._FromScene = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "SearchScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SearchScene
		{
			get
			{
				return this._SearchScene;
			}
			set
			{
				this._SearchScene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
