using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadAppAttachResponse")]
	[Serializable]
	public class UploadAppAttachResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _AppId = "";

		private string _MediaId = "";

		private string _ClientAppDataId = "";

		private string _UserName = "";

		private uint _TotalLen;

		private uint _StartPos;

		private uint _DataLen;

		private uint _CreateTime;

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

		[ProtoMember(2, IsRequired = false, Name = "AppId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppId
		{
			get
			{
				return this._AppId;
			}
			set
			{
				this._AppId = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "MediaId", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(4, IsRequired = false, Name = "ClientAppDataId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientAppDataId
		{
			get
			{
				return this._ClientAppDataId;
			}
			set
			{
				this._ClientAppDataId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
