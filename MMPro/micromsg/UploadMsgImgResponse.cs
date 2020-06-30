using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadMsgImgResponse")]
	[Serializable]
	public class UploadMsgImgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MsgId;

		private SKBuiltinString_t _ClientImgId;

		private SKBuiltinString_t _FromUserName;

		private SKBuiltinString_t _ToUserName;

		private uint _TotalLen;

		private uint _StartPos;

		private uint _DataLen;

		private uint _CreateTime;

		private ulong _NewMsgId = 0uL;

		private string _AESKey = "";

		private string _FileId = "";

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

		[ProtoMember(2, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "ClientImgId", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ClientImgId
		{
			get
			{
				return this._ClientImgId;
			}
			set
			{
				this._ClientImgId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "FromUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t FromUserName
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

		[ProtoMember(5, IsRequired = true, Name = "ToUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ToUserName
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

		[ProtoMember(6, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public uint StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "DataLen", DataFormat = DataFormat.TwosComplement)]
		public uint DataLen
		{
			get
			{
				return this._DataLen;
			}
			set
			{
				this._DataLen = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
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

		[ProtoMember(11, IsRequired = false, Name = "AESKey", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(12, IsRequired = false, Name = "FileId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FileId
		{
			get
			{
				return this._FileId;
			}
			set
			{
				this._FileId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
