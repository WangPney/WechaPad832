using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendQRCodeByEmailReq")]
	[Serializable]
	public class SendQRCodeByEmailReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _QRCodeUserName = "";

		private uint _ToCount;

		private readonly List<SKBuiltinString_t> _ToList = new List<SKBuiltinString_t>();

		private string _Tittle = "";

		private string _Content = "";

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

		[ProtoMember(2, IsRequired = false, Name = "QRCodeUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string QRCodeUserName
		{
			get
			{
				return this._QRCodeUserName;
			}
			set
			{
				this._QRCodeUserName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ToCount", DataFormat = DataFormat.TwosComplement)]
		public uint ToCount
		{
			get
			{
				return this._ToCount;
			}
			set
			{
				this._ToCount = value;
			}
		}

		[ProtoMember(4, Name = "ToList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> ToList
		{
			get
			{
				return this._ToList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Tittle", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Tittle
		{
			get
			{
				return this._Tittle;
			}
			set
			{
				this._Tittle = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
