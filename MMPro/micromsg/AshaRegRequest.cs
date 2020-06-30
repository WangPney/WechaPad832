using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AshaRegRequest")]
	[Serializable]
	public class AshaRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Nid = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Nid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Nid
		{
			get
			{
				return this._Nid;
			}
			set
			{
				this._Nid = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
