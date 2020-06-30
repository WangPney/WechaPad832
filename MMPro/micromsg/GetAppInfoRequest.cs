using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetAppInfoRequest")]
	[Serializable]
	public class GetAppInfoRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private uint _IconType;

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

		[ProtoMember(2, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "IconType", DataFormat = DataFormat.TwosComplement)]
		public uint IconType
		{
			get
			{
				return this._IconType;
			}
			set
			{
				this._IconType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
