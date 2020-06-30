using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GmailOperRequest")]
	[Serializable]
	public class GmailOperRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpType;

		private string _GmailAcct = "";

		private string _GmailPwd = "";

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

		[ProtoMember(2, IsRequired = true, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
		public uint OpType
		{
			get
			{
				return this._OpType;
			}
			set
			{
				this._OpType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "GmailAcct", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GmailAcct
		{
			get
			{
				return this._GmailAcct;
			}
			set
			{
				this._GmailAcct = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "GmailPwd", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GmailPwd
		{
			get
			{
				return this._GmailPwd;
			}
			set
			{
				this._GmailPwd = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
