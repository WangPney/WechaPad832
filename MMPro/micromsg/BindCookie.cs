using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindCookie")]
	[Serializable]
	public class BindCookie : IExtensible
	{
		private string _mobile = "";

		private string _verifycode = "";

		private uint _expire;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "mobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string mobile
		{
			get
			{
				return this._mobile;
			}
			set
			{
				this._mobile = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "verifycode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string verifycode
		{
			get
			{
				return this._verifycode;
			}
			set
			{
				this._verifycode = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "expire", DataFormat = DataFormat.TwosComplement)]
		public uint expire
		{
			get
			{
				return this._expire;
			}
			set
			{
				this._expire = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
