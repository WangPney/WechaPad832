using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LabelPair")]
	[Serializable]
	public class LabelPair : IExtensible
	{
		private string _LabelName = "";

		private uint _LabelID;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "LabelName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LabelName
		{
			get
			{
				return this._LabelName;
			}
			set
			{
				this._LabelName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "LabelID", DataFormat = DataFormat.TwosComplement)]
		public uint LabelID
		{
			get
			{
				return this._LabelID;
			}
			set
			{
				this._LabelID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
