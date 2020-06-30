using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetA8KeyResp")]
	[Serializable]
	public class GetA8KeyResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _FullURL = "";

		private string _A8Key = "";

		private uint _ActionCode = 0u;

		private string _Title = "";

		private string _Content = "";

		private JSAPIPermissionBitSet _JSAPIPermission = null;

		private GeneralControlBitSet _GeneralControlBitSet = null;

		private string _UserName = "";

		private string _ShareURL = "";

		private uint _ScopeCount = 0u;

		private readonly List<BizScopeInfo> _ScopeList = new List<BizScopeInfo>();

		private string _AntispamTicket = "";

		private string _SSID = "";

		private string _MID = "";

		private DeepLinkBitSet _DeepLinkBitSet = null;

		private SKBuiltinBuffer_t _JSAPIControlBytes = null;

		private int _HttpHeaderNumb = 0;

		private readonly List<HTTPHeader> _HttpHeader = new List<HTTPHeader>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "FullURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FullURL
		{
			get
			{
				return this._FullURL;
			}
			set
			{
				this._FullURL = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "A8Key", DataFormat = DataFormat.Default), DefaultValue("")]
		public string A8Key
		{
			get
			{
				return this._A8Key;
			}
			set
			{
				this._A8Key = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ActionCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ActionCode
		{
			get
			{
				return this._ActionCode;
			}
			set
			{
				this._ActionCode = value;
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

		[ProtoMember(6, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "JSAPIPermission", DataFormat = DataFormat.Default), DefaultValue(null)]
		public JSAPIPermissionBitSet JSAPIPermission
		{
			get
			{
				return this._JSAPIPermission;
			}
			set
			{
				this._JSAPIPermission = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "GeneralControlBitSet", DataFormat = DataFormat.Default), DefaultValue(null)]
		public GeneralControlBitSet GeneralControlBitSet
		{
			get
			{
				return this._GeneralControlBitSet;
			}
			set
			{
				this._GeneralControlBitSet = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(15, IsRequired = false, Name = "ShareURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ShareURL
		{
			get
			{
				return this._ShareURL;
			}
			set
			{
				this._ShareURL = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "ScopeCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ScopeCount
		{
			get
			{
				return this._ScopeCount;
			}
			set
			{
				this._ScopeCount = value;
			}
		}

		[ProtoMember(17, Name = "ScopeList", DataFormat = DataFormat.Default)]
		public List<BizScopeInfo> ScopeList
		{
			get
			{
				return this._ScopeList;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "AntispamTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AntispamTicket
		{
			get
			{
				return this._AntispamTicket;
			}
			set
			{
				this._AntispamTicket = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "SSID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SSID
		{
			get
			{
				return this._SSID;
			}
			set
			{
				this._SSID = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "MID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MID
		{
			get
			{
				return this._MID;
			}
			set
			{
				this._MID = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "DeepLinkBitSet", DataFormat = DataFormat.Default), DefaultValue(null)]
		public DeepLinkBitSet DeepLinkBitSet
		{
			get
			{
				return this._DeepLinkBitSet;
			}
			set
			{
				this._DeepLinkBitSet = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "JSAPIControlBytes", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t JSAPIControlBytes
		{
			get
			{
				return this._JSAPIControlBytes;
			}
			set
			{
				this._JSAPIControlBytes = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "HttpHeaderNumb", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int HttpHeaderNumb
		{
			get
			{
				return this._HttpHeaderNumb;
			}
			set
			{
				this._HttpHeaderNumb = value;
			}
		}

		[ProtoMember(25, Name = "HttpHeader", DataFormat = DataFormat.Default)]
		public List<HTTPHeader> HttpHeader
		{
			get
			{
				return this._HttpHeader;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
