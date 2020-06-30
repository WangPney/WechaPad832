using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SyncCheckResponse")]
	[Serializable]
	public class SyncCheckResponse : IExtensible
	{
		private string _ErrMsg = "";

		private string _Signature = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "ErrMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ErrMsg
		{
			get
			{
				return this._ErrMsg;
			}
			set
			{
				this._ErrMsg = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Signature
		{
			get
			{
				return this._Signature;
			}
			set
			{
				this._Signature = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
