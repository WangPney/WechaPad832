using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EchoResponse")]
	[Serializable]
	public class EchoResponse : IExtensible
	{
		private string _EchoStr = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "EchoStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string EchoStr
		{
			get
			{
				return this._EchoStr;
			}
			set
			{
				this._EchoStr = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
