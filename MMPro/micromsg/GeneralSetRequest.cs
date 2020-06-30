using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GeneralSetRequest")]
	[Serializable]
	public class GeneralSetRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _SetType;

		private string _SetValue = "";

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

		[ProtoMember(2, IsRequired = true, Name = "SetType", DataFormat = DataFormat.TwosComplement)]
		public int SetType
		{
			get
			{
				return this._SetType;
			}
			set
			{
				this._SetType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SetValue", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SetValue
		{
			get
			{
				return this._SetValue;
			}
			set
			{
				this._SetValue = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
