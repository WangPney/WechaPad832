using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PSMStat")]
	[Serializable]
	public class PSMStat : IExtensible
	{
		private uint _MType;

		private string _AType = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MType", DataFormat = DataFormat.TwosComplement)]
		public uint MType
		{
			get
			{
				return this._MType;
			}
			set
			{
				this._MType = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "AType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AType
		{
			get
			{
				return this._AType;
			}
			set
			{
				this._AType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
