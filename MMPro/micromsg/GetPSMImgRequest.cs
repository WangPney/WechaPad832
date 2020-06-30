using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetPSMImgRequest")]
	[Serializable]
	public class GetPSMImgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _URL = "";

		private uint _Offset;

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

		[ProtoMember(2, IsRequired = false, Name = "URL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				this._URL = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Offset", DataFormat = DataFormat.TwosComplement)]
		public uint Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
