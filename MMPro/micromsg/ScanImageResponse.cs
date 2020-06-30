using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ScanImageResponse")]
	[Serializable]
	public class ScanImageResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ClientScanID;

		private uint _Type;

		private string _DescriptionXML = "";

		private uint _EndFlag;

		private uint _ImageType;

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

		[ProtoMember(2, IsRequired = true, Name = "ClientScanID", DataFormat = DataFormat.TwosComplement)]
		public uint ClientScanID
		{
			get
			{
				return this._ClientScanID;
			}
			set
			{
				this._ClientScanID = value;
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

		[ProtoMember(4, IsRequired = false, Name = "DescriptionXML", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DescriptionXML
		{
			get
			{
				return this._DescriptionXML;
			}
			set
			{
				this._DescriptionXML = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "EndFlag", DataFormat = DataFormat.TwosComplement)]
		public uint EndFlag
		{
			get
			{
				return this._EndFlag;
			}
			set
			{
				this._EndFlag = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "ImageType", DataFormat = DataFormat.TwosComplement)]
		public uint ImageType
		{
			get
			{
				return this._ImageType;
			}
			set
			{
				this._ImageType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
