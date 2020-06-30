using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "InitRequest")]
	[Serializable]
	public class InitRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _UserName;

		private uint _SyncKey;

		private SKBuiltinString_t _Buffer;

		private string _Language = "";

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

		[ProtoMember(3, IsRequired = true, Name = "SyncKey", DataFormat = DataFormat.TwosComplement)]
		public uint SyncKey
		{
			get
			{
				return this._SyncKey;
			}
			set
			{
				this._SyncKey = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Language", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Language
		{
			get
			{
				return this._Language;
			}
			set
			{
				this._Language = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
