using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoQueryResponse")]
	[Serializable]
	public class RcptInfoQueryResponse : IExtensible
	{
		private RcptInfoList _rcptinfolist;

		private uint _islatest;

		private BaseResponse _BaseResponse;

		private string _appusername = "";

		private uint _isauthority = 0u;

		private string _appnickname = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "rcptinfolist", DataFormat = DataFormat.Default)]
		public RcptInfoList rcptinfolist
		{
			get
			{
				return this._rcptinfolist;
			}
			set
			{
				this._rcptinfolist = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "islatest", DataFormat = DataFormat.TwosComplement)]
		public uint islatest
		{
			get
			{
				return this._islatest;
			}
			set
			{
				this._islatest = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "appusername", DataFormat = DataFormat.Default), DefaultValue("")]
		public string appusername
		{
			get
			{
				return this._appusername;
			}
			set
			{
				this._appusername = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "isauthority", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint isauthority
		{
			get
			{
				return this._isauthority;
			}
			set
			{
				this._isauthority = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "appnickname", DataFormat = DataFormat.Default), DefaultValue("")]
		public string appnickname
		{
			get
			{
				return this._appnickname;
			}
			set
			{
				this._appnickname = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
