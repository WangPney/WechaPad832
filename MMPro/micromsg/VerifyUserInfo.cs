using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyUserInfo")]
	[Serializable]
	public class VerifyUserInfo : IExtensible
	{
		private string _Key = "";

		private string _Value = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Key", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				this._Key = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Value", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
