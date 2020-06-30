using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SetAppSettingResponse")]
	[Serializable]
	public class SetAppSettingResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _AppID = "";

		private uint _AppFlag;

		private uint _CmdID;

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

		[ProtoMember(3, IsRequired = true, Name = "AppFlag", DataFormat = DataFormat.TwosComplement)]
		public uint AppFlag
		{
			get
			{
				return this._AppFlag;
			}
			set
			{
				this._AppFlag = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "CmdID", DataFormat = DataFormat.TwosComplement)]
		public uint CmdID
		{
			get
			{
				return this._CmdID;
			}
			set
			{
				this._CmdID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
