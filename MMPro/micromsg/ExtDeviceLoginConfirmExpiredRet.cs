using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ExtDeviceLoginConfirmExpiredRet")]
	[Serializable]
	public class ExtDeviceLoginConfirmExpiredRet : IExtensible
	{
		private uint _IconType = 0u;

		private string _ContentStr = "";

		private string _ButtonStr = "";

		private string _TitleStr = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "IconType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(2, IsRequired = false, Name = "ContentStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ContentStr
		{
			get
			{
				return this._ContentStr;
			}
			set
			{
				this._ContentStr = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ButtonStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ButtonStr
		{
			get
			{
				return this._ButtonStr;
			}
			set
			{
				this._ButtonStr = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "TitleStr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TitleStr
		{
			get
			{
				return this._TitleStr;
			}
			set
			{
				this._TitleStr = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
