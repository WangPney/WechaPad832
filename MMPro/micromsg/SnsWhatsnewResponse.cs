using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsWhatsnewResponse")]
	[Serializable]
	public class SnsWhatsnewResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private Whatsnew61 _Whatsnew61 = null;

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

		[ProtoMember(2, IsRequired = false, Name = "Whatsnew61", DataFormat = DataFormat.Default), DefaultValue(null)]
		public Whatsnew61 Whatsnew61
		{
			get
			{
				return this._Whatsnew61;
			}
			set
			{
				this._Whatsnew61 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
