using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AdvertiseObject")]
	[Serializable]
	public class AdvertiseObject : IExtensible
	{
		private SnsADObject _SnsADObject;

		private SKBuiltinString_t _ADInfo = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SnsADObject", DataFormat = DataFormat.Default)]
		public SnsADObject SnsADObject
		{
			get
			{
				return this._SnsADObject;
			}
			set
			{
				this._SnsADObject = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ADInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t ADInfo
		{
			get
			{
				return this._ADInfo;
			}
			set
			{
				this._ADInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
