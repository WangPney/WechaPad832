using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VoiceAddrResponse")]
	[Serializable]
	public class VoiceAddrResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _EndFlag;

		private int _UserCount;

		private readonly List<SKBuiltinString_t> _UserNameList = new List<SKBuiltinString_t>();

		private string _ReportFiled = "";

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

		[ProtoMember(2, IsRequired = true, Name = "EndFlag", DataFormat = DataFormat.TwosComplement)]
		public uint EndFlag
		{
			get
			{
				return this._EndFlag;
			}
			set
			{
				this._EndFlag = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "UserCount", DataFormat = DataFormat.TwosComplement)]
		public int UserCount
		{
			get
			{
				return this._UserCount;
			}
			set
			{
				this._UserCount = value;
			}
		}

		[ProtoMember(4, Name = "UserNameList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> UserNameList
		{
			get
			{
				return this._UserNameList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ReportFiled", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ReportFiled
		{
			get
			{
				return this._ReportFiled;
			}
			set
			{
				this._ReportFiled = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
