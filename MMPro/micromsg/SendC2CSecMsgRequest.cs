using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendC2CSecMsgRequest")]
	[Serializable]
	public class SendC2CSecMsgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ToUser = "";

		private int _MsgType = 0;

		private string _TempId = "";

		private string _Title = "";

		private string _Des = "";

		private string _Url = "";

		private int _Scene = 0;

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

		[ProtoMember(2, IsRequired = false, Name = "ToUser", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ToUser
		{
			get
			{
				return this._ToUser;
			}
			set
			{
				this._ToUser = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "MsgType", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int MsgType
		{
			get
			{
				return this._MsgType;
			}
			set
			{
				this._MsgType = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "TempId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TempId
		{
			get
			{
				return this._TempId;
			}
			set
			{
				this._TempId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Des", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Des
		{
			get
			{
				return this._Des;
			}
			set
			{
				this._Des = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
