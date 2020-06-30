using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Mobile")]
	[Serializable]
	public class Mobile : IExtensible
	{
		private string _v = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "v", DataFormat = DataFormat.Default), DefaultValue("")]
		public string v
		{
			get
			{
				return this._v;
			}
			set
			{
				this._v = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
