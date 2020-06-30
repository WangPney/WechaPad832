using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RadarMember")]
	[Serializable]
	public class RadarMember : IExtensible
	{
		private string _MemberName = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "MemberName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MemberName
		{
			get
			{
				return this._MemberName;
			}
			set
			{
				this._MemberName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
