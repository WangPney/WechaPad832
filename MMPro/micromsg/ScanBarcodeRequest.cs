using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ScanBarcodeRequest")]
	[Serializable]
	public class ScanBarcodeRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Type;

		private string _Barcode = "";

		private uint _Scene = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "Barcode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Barcode
		{
			get
			{
				return this._Barcode;
			}
			set
			{
				this._Barcode = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
