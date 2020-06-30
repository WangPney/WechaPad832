using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetProductDetailRequest")]
	[Serializable]
	public class GetProductDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Pid = "";

		private uint _Version = 0u;

		private string _ScanCode = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Pid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pid
		{
			get
			{
				return this._Pid;
			}
			set
			{
				this._Pid = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Version", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				this._Version = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ScanCode", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ScanCode
		{
			get
			{
				return this._ScanCode;
			}
			set
			{
				this._ScanCode = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
