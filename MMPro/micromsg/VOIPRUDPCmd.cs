using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VOIPRUDPCmd")]
	[Serializable]
	public class VOIPRUDPCmd : IExtensible
	{
		private int _CmdType;

		private byte[] _CmdBuffer = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "CmdType", DataFormat = DataFormat.TwosComplement)]
		public int CmdType
		{
			get
			{
				return this._CmdType;
			}
			set
			{
				this._CmdType = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "CmdBuffer", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] CmdBuffer
		{
			get
			{
				return this._CmdBuffer;
			}
			set
			{
				this._CmdBuffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
