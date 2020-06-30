using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTimeLineRequest")]
	[Serializable]
	public class SnsTimeLineRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FirstPageMd5 = "";

		private ulong _MaxId;

		private ulong _MinFilterId = 0uL;

		private uint _LastRequestTime = 0u;

		private ulong _ClientLatestId = 0uL;

		private SKBuiltinBuffer_t _Session = null;

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

		[ProtoMember(2, IsRequired = false, Name = "FirstPageMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FirstPageMd5
		{
			get
			{
				return this._FirstPageMd5;
			}
			set
			{
				this._FirstPageMd5 = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MaxId", DataFormat = DataFormat.TwosComplement)]
		public ulong MaxId
		{
			get
			{
				return this._MaxId;
			}
			set
			{
				this._MaxId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "MinFilterId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong MinFilterId
		{
			get
			{
				return this._MinFilterId;
			}
			set
			{
				this._MinFilterId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "LastRequestTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LastRequestTime
		{
			get
			{
				return this._LastRequestTime;
			}
			set
			{
				this._LastRequestTime = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ClientLatestId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong ClientLatestId
		{
			get
			{
				return this._ClientLatestId;
			}
			set
			{
				this._ClientLatestId = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Session", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Session
		{
			get
			{
				return this._Session;
			}
			set
			{
				this._Session = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
