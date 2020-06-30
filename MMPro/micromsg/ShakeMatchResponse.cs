using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeMatchResponse")]
	[Serializable]
	public class ShakeMatchResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _Tips = "";

		private uint _Ret;

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

		[ProtoMember(2, IsRequired = false, Name = "Tips", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Tips
		{
			get
			{
				return this._Tips;
			}
			set
			{
				this._Tips = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
		public uint Ret
		{
			get
			{
				return this._Ret;
			}
			set
			{
				this._Ret = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
