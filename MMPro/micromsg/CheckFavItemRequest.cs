using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CheckFavItemRequest")]
	[Serializable]
	public class CheckFavItemRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _SourceType;

		private string _SourceId = "";

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

		[ProtoMember(2, IsRequired = true, Name = "SourceType", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "SourceId", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
