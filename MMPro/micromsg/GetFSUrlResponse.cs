using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetFSUrlResponse")]
	[Serializable]
	public class GetFSUrlResponse : IExtensible
	{
		private string _FSURL = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "FSURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FSURL
		{
			get
			{
				return this._FSURL;
			}
			set
			{
				this._FSURL = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
