using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BlueToothBindLoginRequest")]
	[Serializable]
	public class BlueToothBindLoginRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _URL = "";

		private uint _OPCode;

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

		[ProtoMember(3, IsRequired = true, Name = "OPCode", DataFormat = DataFormat.TwosComplement)]
		public uint OPCode
		{
			get
			{
				return this._OPCode;
			}
			set
			{
				this._OPCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
