using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UnlockStockRequest")]
	[Serializable]
	public class UnlockStockRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Pid = "";

		private string _SkuId = "";

		private uint _Count = 0u;

		private string _Url = "";

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

		[ProtoMember(2, IsRequired = false, Name = "Pid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Pid
		{
			get
			{
				return this._Pid;
			}
			set
			{
				this._Pid = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SkuId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SkuId
		{
			get
			{
				return this._SkuId;
			}
			set
			{
				this._SkuId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Count", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(5, IsRequired = false, Name = "Url", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
