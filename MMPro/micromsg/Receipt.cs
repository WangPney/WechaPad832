using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Receipt")]
	[Serializable]
	public class Receipt : IExtensible
	{
		private uint _IsNeed;

		private string _Detail = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "IsNeed", DataFormat = DataFormat.TwosComplement)]
		public uint IsNeed
		{
			get
			{
				return this._IsNeed;
			}
			set
			{
				this._IsNeed = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Detail", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Detail
		{
			get
			{
				return this._Detail;
			}
			set
			{
				this._Detail = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
