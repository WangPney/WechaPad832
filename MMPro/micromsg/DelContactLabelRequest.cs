using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DelContactLabelRequest")]
	[Serializable]
	public class DelContactLabelRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _LabelIDList = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
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
