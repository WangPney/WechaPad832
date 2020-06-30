using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetWeiBoURLReq")]
	[Serializable]
	public class GetWeiBoURLReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private SKBuiltinBuffer_t _A2Key;

		private string _UserName = "";

		private uint _Scene = 0u;

		private string _BlogUserName = "";

		private SKBuiltinBuffer_t _A2KeyNew = null;

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

		[ProtoMember(2, IsRequired = true, Name = "A2Key", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t A2Key
		{
			get
			{
				return this._A2Key;
			}
			set
			{
				this._A2Key = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(5, IsRequired = false, Name = "BlogUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BlogUserName
		{
			get
			{
				return this._BlogUserName;
			}
			set
			{
				this._BlogUserName = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "A2KeyNew", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t A2KeyNew
		{
			get
			{
				return this._A2KeyNew;
			}
			set
			{
				this._A2KeyNew = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
