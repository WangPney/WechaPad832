using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RevokeMsgRequest")]
	[Serializable]
	public class RevokeMsgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientMsgId = "";

		private uint _NewClientMsgId;

		private uint _CreateTime;

		private uint _SvrMsgId;

		private string _FromUserName = "";

		private string _ToUserName = "";

		private uint _IndexOfRequest;

		private ulong _SvrNewMsgId = 0uL;

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

		[ProtoMember(2, IsRequired = false, Name = "ClientMsgId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientMsgId
		{
			get
			{
				return this._ClientMsgId;
			}
			set
			{
				this._ClientMsgId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "NewClientMsgId", DataFormat = DataFormat.TwosComplement)]
		public uint NewClientMsgId
		{
			get
			{
				return this._NewClientMsgId;
			}
			set
			{
				this._NewClientMsgId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
		public uint CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				this._CreateTime = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "SvrMsgId", DataFormat = DataFormat.TwosComplement)]
		public uint SvrMsgId
		{
			get
			{
				return this._SvrMsgId;
			}
			set
			{
				this._SvrMsgId = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "FromUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FromUserName
		{
			get
			{
				return this._FromUserName;
			}
			set
			{
				this._FromUserName = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ToUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ToUserName
		{
			get
			{
				return this._ToUserName;
			}
			set
			{
				this._ToUserName = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "IndexOfRequest", DataFormat = DataFormat.TwosComplement)]
		public uint IndexOfRequest
		{
			get
			{
				return this._IndexOfRequest;
			}
			set
			{
				this._IndexOfRequest = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "SvrNewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong SvrNewMsgId
		{
			get
			{
				return this._SvrNewMsgId;
			}
			set
			{
				this._SvrNewMsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
