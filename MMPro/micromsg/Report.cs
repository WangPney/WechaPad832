using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Report")]
	[Serializable]
	public class Report : IExtensible
	{
		private string _Log = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Log", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Log
		{
			get
			{
				return this._Log;
			}
			set
			{
				this._Log = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
