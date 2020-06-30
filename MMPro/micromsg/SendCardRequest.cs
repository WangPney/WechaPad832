using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendCardRequest")]
	[Serializable]
	public class SendCardRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _UserName = "";

		private string _Content = "";

		private uint _SendCardBitFlag = 0u;

		private uint _Style = 0u;

		private string _ContentEx = "";

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

		[ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(4, IsRequired = false, Name = "SendCardBitFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SendCardBitFlag
		{
			get
			{
				return this._SendCardBitFlag;
			}
			set
			{
				this._SendCardBitFlag = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Style", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Style
		{
			get
			{
				return this._Style;
			}
			set
			{
				this._Style = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ContentEx", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ContentEx
		{
			get
			{
				return this._ContentEx;
			}
			set
			{
				this._ContentEx = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
