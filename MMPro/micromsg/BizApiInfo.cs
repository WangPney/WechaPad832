using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BizApiInfo")]
	[Serializable]
	public class BizApiInfo : IExtensible
	{
		private string _ApiName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ApiName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ApiName
		{
			get
			{
				return this._ApiName;
			}
			set
			{
				this._ApiName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
