using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetAppInfoResponse")]
	[Serializable]
	public class GetAppInfoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private OpenAppInfo _AppInfo;

		private uint _NoUse = 0u;

		private string _DevInfo = "";

		private string _AppType = "";

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

		[ProtoMember(2, IsRequired = true, Name = "AppInfo", DataFormat = DataFormat.Default)]
		public OpenAppInfo AppInfo
		{
			get
			{
				return this._AppInfo;
			}
			set
			{
				this._AppInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "NoUse", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NoUse
		{
			get
			{
				return this._NoUse;
			}
			set
			{
				this._NoUse = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "DevInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DevInfo
		{
			get
			{
				return this._DevInfo;
			}
			set
			{
				this._DevInfo = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "AppType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppType
		{
			get
			{
				return this._AppType;
			}
			set
			{
				this._AppType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
