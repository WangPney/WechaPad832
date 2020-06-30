using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetTVInfoRequest")]
	[Serializable]
	public class GetTVInfoRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _TVID = "";

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

		[ProtoMember(2, IsRequired = false, Name = "TVID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TVID
		{
			get
			{
				return this._TVID;
			}
			set
			{
				this._TVID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
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
