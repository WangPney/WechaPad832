using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserLabelInfo")]
	[Serializable]
	public class UserLabelInfo : IExtensible
	{
		private string _UserName = "";

		private string _LabelIDList = "";

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

		[ProtoMember(2, IsRequired = false, Name = "LabelIDList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LabelIDList
		{
			get
			{
				return this._LabelIDList;
			}
			set
			{
				this._LabelIDList = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
