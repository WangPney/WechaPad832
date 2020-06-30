using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShowcaseInfo")]
	[Serializable]
	public class ShowcaseInfo : IExtensible
	{
		private uint _ObjectId;

		private string _Summary = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ObjectId", DataFormat = DataFormat.TwosComplement)]
		public uint ObjectId
		{
			get
			{
				return this._ObjectId;
			}
			set
			{
				this._ObjectId = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Summary", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Summary
		{
			get
			{
				return this._Summary;
			}
			set
			{
				this._Summary = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
