using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "MailComposeSendRequest")]
	[Serializable]
	public class MailComposeSendRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _MailAccount = "";

		private string _OldMailID = "";

		private string _Subject = "";

		private string _RcptTo = "";

		private string _Cc = "";

		private string _Bcc = "";

		private string _From = "";

		private string _MailContent = "";

		private int _ReplyType;

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

		[ProtoMember(2, IsRequired = false, Name = "MailAccount", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MailAccount
		{
			get
			{
				return this._MailAccount;
			}
			set
			{
				this._MailAccount = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "OldMailID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OldMailID
		{
			get
			{
				return this._OldMailID;
			}
			set
			{
				this._OldMailID = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Subject", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				this._Subject = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "RcptTo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RcptTo
		{
			get
			{
				return this._RcptTo;
			}
			set
			{
				this._RcptTo = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Cc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Cc
		{
			get
			{
				return this._Cc;
			}
			set
			{
				this._Cc = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Bcc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Bcc
		{
			get
			{
				return this._Bcc;
			}
			set
			{
				this._Bcc = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "From", DataFormat = DataFormat.Default), DefaultValue("")]
		public string From
		{
			get
			{
				return this._From;
			}
			set
			{
				this._From = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "MailContent", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MailContent
		{
			get
			{
				return this._MailContent;
			}
			set
			{
				this._MailContent = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "ReplyType", DataFormat = DataFormat.TwosComplement)]
		public int ReplyType
		{
			get
			{
				return this._ReplyType;
			}
			set
			{
				this._ReplyType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
