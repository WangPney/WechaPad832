using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadCardImgRequest")]
	[Serializable]
	public class UploadCardImgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ClientId = "";

		private uint _TotalLen;

		private uint _StartPos;

		private uint _DataLen;

		private SKBuiltinBuffer_t _Data;

		private string _ContactUserName = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ClientId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				this._ClientId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = true, Name = "DataLen", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
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

		[ProtoMember(7, IsRequired = false, Name = "ContactUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ContactUserName
		{
			get
			{
				return this._ContactUserName;
			}
			set
			{
				this._ContactUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
