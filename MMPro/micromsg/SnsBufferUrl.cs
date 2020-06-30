using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsBufferUrl")]
	[Serializable]
	public class SnsBufferUrl : IExtensible
	{
		private string _Url = "";

		private uint _Type;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
