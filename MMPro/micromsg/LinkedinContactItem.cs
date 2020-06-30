using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LinkedinContactItem")]
	[Serializable]
	public class LinkedinContactItem : IExtensible
	{
		private string _LinkedinName = "";

		private string _LinkedinMemberID = "";

		private string _LinkedinPublicUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "LinkedinName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LinkedinName
		{
			get
			{
				return this._LinkedinName;
			}
			set
			{
				this._LinkedinName = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "LinkedinMemberID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LinkedinMemberID
		{
			get
			{
				return this._LinkedinMemberID;
			}
			set
			{
				this._LinkedinMemberID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "LinkedinPublicUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LinkedinPublicUrl
		{
			get
			{
				return this._LinkedinPublicUrl;
			}
			set
			{
				this._LinkedinPublicUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
