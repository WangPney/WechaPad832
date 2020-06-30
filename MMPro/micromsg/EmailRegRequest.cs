using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EmailRegRequest")]
	[Serializable]
	public class EmailRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _RandomEncryKey;

		private uint _Opcode;

		private string _Email = "";

		private string _Language = "";

		private string _Pwd = "";

		private string _VerifyCode = "";

		private string _ClientSeqID = "";

		private string _RealCountry = "";

		private uint _VerifyScene = 0u;

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

		[ProtoMember(3, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
		public uint Opcode
		{
			get
			{
				return this._Opcode;
			}
			set
			{
				this._Opcode = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Email", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this._Email = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Language", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Language
		{
			get
			{
				return this._Language;
			}
			set
			{
				this._Language = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Pwd", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				this._Pwd = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "VerifyCode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifyCode
		{
			get
			{
				return this._VerifyCode;
			}
			set
			{
				this._VerifyCode = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "ClientSeqID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientSeqID
		{
			get
			{
				return this._ClientSeqID;
			}
			set
			{
				this._ClientSeqID = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "RealCountry", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RealCountry
		{
			get
			{
				return this._RealCountry;
			}
			set
			{
				this._RealCountry = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "VerifyScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint VerifyScene
		{
			get
			{
				return this._VerifyScene;
			}
			set
			{
				this._VerifyScene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
