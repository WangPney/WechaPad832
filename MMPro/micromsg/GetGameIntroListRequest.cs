using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetGameIntroListRequest")]
	[Serializable]
	public class GetGameIntroListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Count;

		private readonly List<SKBuiltinString_t> _AppIdList = new List<SKBuiltinString_t>();

		private string _DevicePlatform = "";

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(3, Name = "AppIdList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> AppIdList
		{
			get
			{
				return this._AppIdList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "DevicePlatform", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DevicePlatform
		{
			get
			{
				return this._DevicePlatform;
			}
			set
			{
				this._DevicePlatform = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
