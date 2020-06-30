using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchNBSRequest")]
	[Serializable]
	public class SearchNBSRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _KeyWord = "";

		private string _Tags = "";

		private string _BizMarkets = "";

		private PositionInfo _UserPos;

		private SKBuiltinBuffer_t _PageBuff;

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

		[ProtoMember(2, IsRequired = false, Name = "KeyWord", DataFormat = DataFormat.Default), DefaultValue("")]
		public string KeyWord
		{
			get
			{
				return this._KeyWord;
			}
			set
			{
				this._KeyWord = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Tags", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Tags
		{
			get
			{
				return this._Tags;
			}
			set
			{
				this._Tags = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BizMarkets", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BizMarkets
		{
			get
			{
				return this._BizMarkets;
			}
			set
			{
				this._BizMarkets = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "UserPos", DataFormat = DataFormat.Default)]
		public PositionInfo UserPos
		{
			get
			{
				return this._UserPos;
			}
			set
			{
				this._UserPos = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "PageBuff", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t PageBuff
		{
			get
			{
				return this._PageBuff;
			}
			set
			{
				this._PageBuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
