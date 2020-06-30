using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ExtDeviceInitResponse")]
	[Serializable]
	public class ExtDeviceInitResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private CmdList _CmdList = null;

		private readonly List<string> _ChatContactList = new List<string>();

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

		[ProtoMember(2, IsRequired = false, Name = "CmdList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CmdList CmdList
		{
			get
			{
				return this._CmdList;
			}
			set
			{
				this._CmdList = value;
			}
		}

		[ProtoMember(3, Name = "ChatContactList", DataFormat = DataFormat.Default)]
		public List<string> ChatContactList
		{
			get
			{
				return this._ChatContactList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
