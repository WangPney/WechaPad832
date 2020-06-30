using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeTranImgGetResponse")]
	[Serializable]
	public class ShakeTranImgGetResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _PageUrl = "";

		private uint _Count;

		private readonly List<ShakeTranImgGetItem> _ImgUrlList = new List<ShakeTranImgGetItem>();

		private SKBuiltinBuffer_t _Buffer = null;

		private string _Title = "";

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

		[ProtoMember(2, IsRequired = false, Name = "PageUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PageUrl
		{
			get
			{
				return this._PageUrl;
			}
			set
			{
				this._PageUrl = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, Name = "ImgUrlList", DataFormat = DataFormat.Default)]
		public List<ShakeTranImgGetItem> ImgUrlList
		{
			get
			{
				return this._ImgUrlList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Buffer", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
