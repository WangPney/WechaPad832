using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SampleProduct")]
	[Serializable]
	public class SampleProduct : IExtensible
	{
		private string _Pid = "";

		private string _SkuId = "";

		private uint _Count = 0u;

		private string _SafeUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Pid", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = false, Name = "SkuId", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "Count", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(4, IsRequired = false, Name = "SafeUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SafeUrl
		{
			get
			{
				return this._SafeUrl;
			}
			set
			{
				this._SafeUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
