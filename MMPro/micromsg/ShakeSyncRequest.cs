using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeSyncRequest")]
	[Serializable]
	public class ShakeSyncRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private float _Longitude;

		private float _Latitude;

		private int _Precision;

		private string _MacAddr = "";

		private string _CellId = "";

		private uint _ImgId;

		private uint _Times;

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

		[ProtoMember(2, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.FixedSize)]
		public float Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				this._Longitude = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.FixedSize)]
		public float Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				this._Latitude = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Precision", DataFormat = DataFormat.TwosComplement)]
		public int Precision
		{
			get
			{
				return this._Precision;
			}
			set
			{
				this._Precision = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "MacAddr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MacAddr
		{
			get
			{
				return this._MacAddr;
			}
			set
			{
				this._MacAddr = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "CellId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CellId
		{
			get
			{
				return this._CellId;
			}
			set
			{
				this._CellId = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "ImgId", DataFormat = DataFormat.TwosComplement)]
		public uint ImgId
		{
			get
			{
				return this._ImgId;
			}
			set
			{
				this._ImgId = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "Times", DataFormat = DataFormat.TwosComplement)]
		public uint Times
		{
			get
			{
				return this._Times;
			}
			set
			{
				this._Times = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
