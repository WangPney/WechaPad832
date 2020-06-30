using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GroupCardReq")]
	[Serializable]
	public class GroupCardReq : IExtensible
	{
		private string _GroupCardName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "GroupCardName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GroupCardName
		{
			get
			{
				return this._GroupCardName;
			}
			set
			{
				this._GroupCardName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
