using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RevokeMsgResponse")]
	[Serializable]
	public class RevokeMsgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _Introduction = "";

		private string _SysWording = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Introduction", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Introduction
		{
			get
			{
				return this._Introduction;
			}
			set
			{
				this._Introduction = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SysWording", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SysWording
		{
			get
			{
				return this._SysWording;
			}
			set
			{
				this._SysWording = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
