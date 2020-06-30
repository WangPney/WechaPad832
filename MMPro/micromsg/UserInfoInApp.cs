using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserInfoInApp")]
	[Serializable]
	public class UserInfoInApp : IExtensible
	{
		private string _UserName = "";

		private string _PersonalSettingXml = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "PersonalSettingXml", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PersonalSettingXml
		{
			get
			{
				return this._PersonalSettingXml;
			}
			set
			{
				this._PersonalSettingXml = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
