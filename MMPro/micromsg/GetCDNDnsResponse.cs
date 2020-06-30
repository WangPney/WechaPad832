using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCDNDnsResponse")]
	[Serializable]
	public class GetCDNDnsResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private CDNDnsInfo _DnsInfo;

		private CDNDnsInfo _SnsDnsInfo = null;

		private CDNDnsInfo _AppDnsInfo = null;

		private SKBuiltinBuffer_t _CDNDnsRuleBuf = null;

		private SKBuiltinBuffer_t _FakeCDNDnsRuleBuf = null;

		private CDNDnsInfo _FakeDnsInfo = null;

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

		[ProtoMember(2, IsRequired = true, Name = "DnsInfo", DataFormat = DataFormat.Default)]
		public CDNDnsInfo DnsInfo
		{
			get
			{
				return this._DnsInfo;
			}
			set
			{
				this._DnsInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SnsDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo SnsDnsInfo
		{
			get
			{
				return this._SnsDnsInfo;
			}
			set
			{
				this._SnsDnsInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "AppDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo AppDnsInfo
		{
			get
			{
				return this._AppDnsInfo;
			}
			set
			{
				this._AppDnsInfo = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "CDNDnsRuleBuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t CDNDnsRuleBuf
		{
			get
			{
				return this._CDNDnsRuleBuf;
			}
			set
			{
				this._CDNDnsRuleBuf = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "FakeCDNDnsRuleBuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t FakeCDNDnsRuleBuf
		{
			get
			{
				return this._FakeCDNDnsRuleBuf;
			}
			set
			{
				this._FakeCDNDnsRuleBuf = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "FakeDnsInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CDNDnsInfo FakeDnsInfo
		{
			get
			{
				return this._FakeDnsInfo;
			}
			set
			{
				this._FakeDnsInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
