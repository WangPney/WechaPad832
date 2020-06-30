using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetProductInfoResponse")]
	[Serializable]
	public class GetProductInfoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Type;

		private string _DescXML = "";

		private string _ProductID = "";

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

		[ProtoMember(3, IsRequired = false, Name = "DescXML", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DescXML
		{
			get
			{
				return this._DescXML;
			}
			set
			{
				this._DescXML = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
