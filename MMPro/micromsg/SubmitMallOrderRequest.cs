using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SubmitMallOrderRequest")]
	[Serializable]
	public class SubmitMallOrderRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private Snapshot _Snapshot = null;

		private string _PayAppid = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Snapshot", DataFormat = DataFormat.Default), DefaultValue(null)]
		public Snapshot Snapshot
		{
			get
			{
				return this._Snapshot;
			}
			set
			{
				this._Snapshot = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "PayAppid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PayAppid
		{
			get
			{
				return this._PayAppid;
			}
			set
			{
				this._PayAppid = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
