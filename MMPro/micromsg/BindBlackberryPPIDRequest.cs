using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BindBlackberryPPIDRequest")]
	[Serializable]
	public class BindBlackberryPPIDRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Opcode;

		private string _BBPPID = "";

		private string _BBPIN = "";

		private string _BBMNickName = "";

		private uint _Force;

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

		[ProtoMember(2, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "BBPPID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPPID
		{
			get
			{
				return this._BBPPID;
			}
			set
			{
				this._BBPPID = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BBPIN", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBPIN
		{
			get
			{
				return this._BBPIN;
			}
			set
			{
				this._BBPIN = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "BBMNickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BBMNickName
		{
			get
			{
				return this._BBMNickName;
			}
			set
			{
				this._BBMNickName = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "Force", DataFormat = DataFormat.TwosComplement)]
		public uint Force
		{
			get
			{
				return this._Force;
			}
			set
			{
				this._Force = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
