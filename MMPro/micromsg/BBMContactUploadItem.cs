using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BBMContactUploadItem")]
	[Serializable]
	public class BBMContactUploadItem : IExtensible
	{
		private string _BBPPID = "";

		private string _BBPIN = "";

		private string _BBMNickName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "BBPPID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPPID
		{
			get
			{
				return this._BBPPID;
			}
			set
			{
				this._BBPPID = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "BBPIN", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPIN
		{
			get
			{
				return this._BBPIN;
			}
			set
			{
				this._BBPIN = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "BBMNickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBMNickName
		{
			get
			{
				return this._BBMNickName;
			}
			set
			{
				this._BBMNickName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
