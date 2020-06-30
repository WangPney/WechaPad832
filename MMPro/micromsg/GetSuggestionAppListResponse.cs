using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetSuggestionAppListResponse")]
	[Serializable]
	public class GetSuggestionAppListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _RcCount;

		private readonly List<RcAppList> _RcList = new List<RcAppList>();

		private uint _IsInternalDownload = 0u;

		private uint _AdCount = 0u;

		private readonly List<AdAppList> _AdList = new List<AdAppList>();

		private uint _GiftCount = 0u;

		private readonly List<GiftList> _GiftList = new List<GiftList>();

		private GiftEntranceItem _GiftEntranceItem = null;

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

		[ProtoMember(2, IsRequired = true, Name = "RcCount", DataFormat = DataFormat.TwosComplement)]
		public uint RcCount
		{
			get
			{
				return this._RcCount;
			}
			set
			{
				this._RcCount = value;
			}
		}

		[ProtoMember(3, Name = "RcList", DataFormat = DataFormat.Default)]
		public List<RcAppList> RcList
		{
			get
			{
				return this._RcList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "IsInternalDownload", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IsInternalDownload
		{
			get
			{
				return this._IsInternalDownload;
			}
			set
			{
				this._IsInternalDownload = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "AdCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AdCount
		{
			get
			{
				return this._AdCount;
			}
			set
			{
				this._AdCount = value;
			}
		}

		[ProtoMember(6, Name = "AdList", DataFormat = DataFormat.Default)]
		public List<AdAppList> AdList
		{
			get
			{
				return this._AdList;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "GiftCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GiftCount
		{
			get
			{
				return this._GiftCount;
			}
			set
			{
				this._GiftCount = value;
			}
		}

		[ProtoMember(8, Name = "GiftList", DataFormat = DataFormat.Default)]
		public List<GiftList> GiftList
		{
			get
			{
				return this._GiftList;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "GiftEntranceItem", DataFormat = DataFormat.Default), DefaultValue(null)]
		public GiftEntranceItem GiftEntranceItem
		{
			get
			{
				return this._GiftEntranceItem;
			}
			set
			{
				this._GiftEntranceItem = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
