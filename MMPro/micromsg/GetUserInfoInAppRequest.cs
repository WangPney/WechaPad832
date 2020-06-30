using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetUserInfoInAppRequest")]
	[Serializable]
	public class GetUserInfoInAppRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private uint _UserCount;

		private readonly List<SKBuiltinString_t> _UserNameList = new List<SKBuiltinString_t>();

		private uint _Scene;

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

		[ProtoMember(3, IsRequired = true, Name = "UserCount", DataFormat = DataFormat.TwosComplement)]
		public uint UserCount
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

		[ProtoMember(5, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
