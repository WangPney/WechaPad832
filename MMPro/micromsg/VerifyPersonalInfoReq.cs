using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyPersonalInfoReq")]
	[Serializable]
	public class VerifyPersonalInfoReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _UserRealName = "";

		private uint _UserIDCardType;

		private string _UserIDCardNum = "";

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

		[ProtoMember(2, IsRequired = false, Name = "UserRealName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserRealName
		{
			get
			{
				return this._UserRealName;
			}
			set
			{
				this._UserRealName = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "UserIDCardType", DataFormat = DataFormat.TwosComplement)]
		public uint UserIDCardType
		{
			get
			{
				return this._UserIDCardType;
			}
			set
			{
				this._UserIDCardType = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "UserIDCardNum", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserIDCardNum
		{
			get
			{
				return this._UserIDCardNum;
			}
			set
			{
				this._UserIDCardNum = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
