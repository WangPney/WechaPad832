using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoQueryRequest")]
	[Serializable]
	public class RcptInfoQueryRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _timestamp;

		private string _webviewurl = "";

		private string _appid = "";

		private uint _scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				this._timestamp = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "webviewurl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string webviewurl
		{
			get
			{
				return this._webviewurl;
			}
			set
			{
				this._webviewurl = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "appid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string appid
		{
			get
			{
				return this._appid;
			}
			set
			{
				this._appid = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint scene
		{
			get
			{
				return this._scene;
			}
			set
			{
				this._scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
