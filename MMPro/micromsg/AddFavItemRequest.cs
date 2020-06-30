using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AddFavItemRequest")]
	[Serializable]
	public class AddFavItemRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientId = "";

		private uint _Type;

		private uint _SourceType;

		private string _SourceId = "";

		private string _Object = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ClientId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				this._ClientId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "SourceType", DataFormat = DataFormat.TwosComplement)]
		public uint SourceType
		{
			get
			{
				return this._SourceType;
			}
			set
			{
				this._SourceType = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "SourceId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SourceId
		{
			get
			{
				return this._SourceId;
			}
			set
			{
				this._SourceId = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Object", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Object
		{
			get
			{
				return this._Object;
			}
			set
			{
				this._Object = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
