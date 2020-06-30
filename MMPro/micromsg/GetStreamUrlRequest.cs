using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetStreamUrlRequest")]
	[Serializable]
	public class GetStreamUrlRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _StreamId = "";

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

		[ProtoMember(2, IsRequired = false, Name = "StreamId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StreamId
		{
			get
			{
				return this._StreamId;
			}
			set
			{
				this._StreamId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
