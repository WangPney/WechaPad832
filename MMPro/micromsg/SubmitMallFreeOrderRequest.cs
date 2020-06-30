using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SubmitMallFreeOrderRequest")]
	[Serializable]
	public class SubmitMallFreeOrderRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private Snapshot _Snapshot = null;

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
