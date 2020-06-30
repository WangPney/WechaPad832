using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadToWeiboRequest")]
	[Serializable]
	public class UploadToWeiboRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientMsgId = "";

		private uint _Type;

		private uint _TotalLen;

		private uint _StartPos;

		private uint _DataLen;

		private byte[] _Data = null;

		private string _Content = "";

		private uint _FilterType;

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

		[ProtoMember(3, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = true, Name = "DataLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "Data", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] Data
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

		[ProtoMember(8, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(9, IsRequired = true, Name = "FilterType", DataFormat = DataFormat.TwosComplement)]
		public uint FilterType
		{
			get
			{
				return this._FilterType;
			}
			set
			{
				this._FilterType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
