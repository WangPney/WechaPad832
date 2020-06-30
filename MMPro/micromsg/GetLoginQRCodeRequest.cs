using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetLoginQRCodeRequest")]
	[Serializable]
	public class GetLoginQRCodeRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _RandomEncryKey;

		private uint _OPCode = 0u;

		private string _DeviceName = "";

		private string _UserName = "";

		private uint _ExtDevLoginType = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "RandomEncryKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t RandomEncryKey
		{
			get
			{
				return this._RandomEncryKey;
			}
			set
			{
				this._RandomEncryKey = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "OPCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(4, IsRequired = false, Name = "DeviceName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				this._DeviceName = value;
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

		[ProtoMember(6, IsRequired = false, Name = "ExtDevLoginType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ExtDevLoginType
		{
			get
			{
				return this._ExtDevLoginType;
			}
			set
			{
				this._ExtDevLoginType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
