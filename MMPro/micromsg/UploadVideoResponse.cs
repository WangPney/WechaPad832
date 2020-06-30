using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadVideoResponse")]
	[Serializable]
	public class UploadVideoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ClientMsgId = "";

		private uint _MsgId;

		private uint _ThumbStartPos;

		private uint _VideoStartPos;

		private ulong _NewMsgId = 0uL;

		private string _AESKey = "";

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

		[ProtoMember(3, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ThumbStartPos", DataFormat = DataFormat.TwosComplement)]
		public uint ThumbStartPos
		{
			get
			{
				return this._ThumbStartPos;
			}
			set
			{
				this._ThumbStartPos = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "VideoStartPos", DataFormat = DataFormat.TwosComplement)]
		public uint VideoStartPos
		{
			get
			{
				return this._VideoStartPos;
			}
			set
			{
				this._VideoStartPos = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "AESKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AESKey
		{
			get
			{
				return this._AESKey;
			}
			set
			{
				this._AESKey = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
