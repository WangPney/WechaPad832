using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCardSerialResponse")]
	[Serializable]
	public class GetCardSerialResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _serial_number = "";

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

		[ProtoMember(2, IsRequired = false, Name = "serial_number", DataFormat = DataFormat.Default), DefaultValue("")]
		public string serial_number
		{
			get
			{
				return this._serial_number;
			}
			set
			{
				this._serial_number = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
