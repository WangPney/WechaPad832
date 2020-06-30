using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "StatusNotifyFunction")]
	[Serializable]
	public class StatusNotifyFunction : IExtensible
	{
		private string _Name = "";

		private string _Arg = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Name", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Arg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Arg
		{
			get
			{
				return this._Arg;
			}
			set
			{
				this._Arg = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
