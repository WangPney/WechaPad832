using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadMsgImgRequest")]
	[Serializable]
	public class UploadMsgImgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinString_t _ClientImgId;

		private SKBuiltinString_t _FromUserName;

		private SKBuiltinString_t _ToUserName;

		private uint _TotalLen;

		private uint _StartPos;

		private uint _DataLen;

		private SKBuiltinBuffer_t _Data;

		private uint _MsgType = 0u;

		private string _MsgSource = "";

		private uint _CompressType = 0u;

		private int _NetType = 0;

		private int _PhotoFrom = 0;

		private string _MediaId = "";

		private string _CDNBigImgUrl = "";

		private string _CDNMidImgUrl = "";

		private string _AESKey = "";

		private int _EncryVer = 0;

		private int _CDNBigImgSize = 0;

		private int _CDNMidImgSize = 0;

		private string _CDNThumbImgUrl = "";

		private int _CDNThumbImgSize = 0;

		private int _CDNThumbImgHeight = 0;

		private int _CDNThumbImgWidth = 0;

		private string _CDNThumbAESKey = "";

		private uint _ReqTime = 0u;

		private string _Md5 = "";

		private uint _CRC32 = 0u;

		private uint _MsgForwardType = 0u;

		private uint _HitMd5 = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "ClientImgId", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "FromUserName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = true, Name = "ToUserName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = true, Name = "DataLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "MsgType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MsgType
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

		[ProtoMember(10, IsRequired = false, Name = "MsgSource", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MsgSource
		{
			get
			{
				return this._MsgSource;
			}
			set
			{
				this._MsgSource = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "CompressType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint CompressType
		{
			get
			{
				return this._CompressType;
			}
			set
			{
				this._CompressType = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "NetType", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int NetType
		{
			get
			{
				return this._NetType;
			}
			set
			{
				this._NetType = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "PhotoFrom", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int PhotoFrom
		{
			get
			{
				return this._PhotoFrom;
			}
			set
			{
				this._PhotoFrom = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "MediaId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MediaId
		{
			get
			{
				return this._MediaId;
			}
			set
			{
				this._MediaId = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "CDNBigImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CDNBigImgUrl
		{
			get
			{
				return this._CDNBigImgUrl;
			}
			set
			{
				this._CDNBigImgUrl = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "CDNMidImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CDNMidImgUrl
		{
			get
			{
				return this._CDNMidImgUrl;
			}
			set
			{
				this._CDNMidImgUrl = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "AESKey", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(18, IsRequired = false, Name = "EncryVer", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int EncryVer
		{
			get
			{
				return this._EncryVer;
			}
			set
			{
				this._EncryVer = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "CDNBigImgSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CDNBigImgSize
		{
			get
			{
				return this._CDNBigImgSize;
			}
			set
			{
				this._CDNBigImgSize = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "CDNMidImgSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CDNMidImgSize
		{
			get
			{
				return this._CDNMidImgSize;
			}
			set
			{
				this._CDNMidImgSize = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "CDNThumbImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CDNThumbImgUrl
		{
			get
			{
				return this._CDNThumbImgUrl;
			}
			set
			{
				this._CDNThumbImgUrl = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "CDNThumbImgSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CDNThumbImgSize
		{
			get
			{
				return this._CDNThumbImgSize;
			}
			set
			{
				this._CDNThumbImgSize = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "CDNThumbImgHeight", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CDNThumbImgHeight
		{
			get
			{
				return this._CDNThumbImgHeight;
			}
			set
			{
				this._CDNThumbImgHeight = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "CDNThumbImgWidth", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int CDNThumbImgWidth
		{
			get
			{
				return this._CDNThumbImgWidth;
			}
			set
			{
				this._CDNThumbImgWidth = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "CDNThumbAESKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CDNThumbAESKey
		{
			get
			{
				return this._CDNThumbAESKey;
			}
			set
			{
				this._CDNThumbAESKey = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "ReqTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ReqTime
		{
			get
			{
				return this._ReqTime;
			}
			set
			{
				this._ReqTime = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "Md5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Md5
		{
			get
			{
				return this._Md5;
			}
			set
			{
				this._Md5 = value;
			}
		}

		[ProtoMember(28, IsRequired = false, Name = "CRC32", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint CRC32
		{
			get
			{
				return this._CRC32;
			}
			set
			{
				this._CRC32 = value;
			}
		}

		[ProtoMember(29, IsRequired = false, Name = "MsgForwardType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MsgForwardType
		{
			get
			{
				return this._MsgForwardType;
			}
			set
			{
				this._MsgForwardType = value;
			}
		}

		[ProtoMember(30, IsRequired = false, Name = "HitMd5", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint HitMd5
		{
			get
			{
				return this._HitMd5;
			}
			set
			{
				this._HitMd5 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
