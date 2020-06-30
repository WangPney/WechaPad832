using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "InviteGoogleContactItem")]
	[Serializable]
	public class InviteGoogleContactItem : IExtensible
	{
		private string _GoogleContactName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "GoogleContactName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GoogleContactName
		{
			get
			{
				return this._GoogleContactName;
			}
			set
			{
				this._GoogleContactName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
