using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetQRCodeResponse")]
	[Serializable]
	public class GetQRCodeResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _QRCode;

		private uint _Style;

		private string _FooterWording = "";

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

		[ProtoMember(2, IsRequired = true, Name = "QRCode", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t QRCode
		{
			get
			{
				return this._QRCode;
			}
			set
			{
				this._QRCode = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Style", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "FooterWording", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FooterWording
		{
			get
			{
				return this._FooterWording;
			}
			set
			{
				this._FooterWording = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
