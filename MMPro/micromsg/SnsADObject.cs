using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsADObject")]
	[Serializable]
	public class SnsADObject : IExtensible
	{
		private SnsObject _SnsObject;

		private SKBuiltinString_t _ADXML = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SnsObject", DataFormat = DataFormat.Default)]
		public SnsObject SnsObject
		{
			get
			{
				return this._SnsObject;
			}
			set
			{
				this._SnsObject = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ADXML", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t ADXML
		{
			get
			{
				return this._ADXML;
			}
			set
			{
				this._ADXML = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
