using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsTimeLineResponse")]
	[Serializable]
	public class SnsTimeLineResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _FirstPageMd5 = "";

		private uint _ObjectCount;

		private readonly List<SnsObject> _ObjectList = new List<SnsObject>();

		private uint _NewRequestTime = 0u;

		private uint _ObjectCountForSameMd5 = 0u;

		private uint _ControlFlag = 0u;

		private SnsServerConfig _ServerConfig = null;

		private uint _AdvertiseCount = 0u;

		private readonly List<AdvertiseObject> _AdvertiseList = new List<AdvertiseObject>();

		private SKBuiltinBuffer_t _Session = null;

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

		[ProtoMember(3, IsRequired = true, Name = "ObjectCount", DataFormat = DataFormat.TwosComplement)]
		public uint ObjectCount
		{
			get
			{
				return this._ObjectCount;
			}
			set
			{
				this._ObjectCount = value;
			}
		}

		[ProtoMember(4, Name = "ObjectList", DataFormat = DataFormat.Default)]
		public List<SnsObject> ObjectList
		{
			get
			{
				return this._ObjectList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "NewRequestTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewRequestTime
		{
			get
			{
				return this._NewRequestTime;
			}
			set
			{
				this._NewRequestTime = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ObjectCountForSameMd5", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ObjectCountForSameMd5
		{
			get
			{
				return this._ObjectCountForSameMd5;
			}
			set
			{
				this._ObjectCountForSameMd5 = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ControlFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ControlFlag
		{
			get
			{
				return this._ControlFlag;
			}
			set
			{
				this._ControlFlag = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "ServerConfig", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SnsServerConfig ServerConfig
		{
			get
			{
				return this._ServerConfig;
			}
			set
			{
				this._ServerConfig = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "AdvertiseCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AdvertiseCount
		{
			get
			{
				return this._AdvertiseCount;
			}
			set
			{
				this._AdvertiseCount = value;
			}
		}

		[ProtoMember(10, Name = "AdvertiseList", DataFormat = DataFormat.Default)]
		public List<AdvertiseObject> AdvertiseList
		{
			get
			{
				return this._AdvertiseList;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "Session", DataFormat = DataFormat.Default), DefaultValue(null)]
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
