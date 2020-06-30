using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeGetItem")]
	[Serializable]
	public class ShakeGetItem : IExtensible
	{
		private string _UserName = "";

		private string _NickName = "";

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private string _Distance = "";

		private int _Sex;

		private uint _ImgStatus;

		private uint _HasHDImg;

		private SKBuiltinBuffer_t _ImgBuffer;

		private uint _NumDistance;

		private string _Weibo = "";

		private string _WeiboNickname = "";

		private uint _WeiboFlag = 0u;

		private uint _VerifyFlag = 0u;

		private string _VerifyInfo = "";

		private string _VerifyContent = "";

		private int _HeadImgVersion = 0;

		private SnsUserInfo _SnsUserInfo = null;

		private string _Country = "";

		private string _BigHeadImgUrl = "";

		private string _SmallHeadImgUrl = "";

		private string _MyBrandList = "";

		private CustomizedInfo _CustomizedInfo = null;

		private string _AntispamTicket = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = false, Name = "NickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Province
		{
			get
			{
				return this._Province;
			}
			set
			{
				this._Province = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				this._City = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Signature
		{
			get
			{
				return this._Signature;
			}
			set
			{
				this._Signature = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Distance", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Distance
		{
			get
			{
				return this._Distance;
			}
			set
			{
				this._Distance = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "Sex", DataFormat = DataFormat.TwosComplement)]
		public int Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				this._Sex = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "ImgStatus", DataFormat = DataFormat.TwosComplement)]
		public uint ImgStatus
		{
			get
			{
				return this._ImgStatus;
			}
			set
			{
				this._ImgStatus = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "HasHDImg", DataFormat = DataFormat.TwosComplement)]
		public uint HasHDImg
		{
			get
			{
				return this._HasHDImg;
			}
			set
			{
				this._HasHDImg = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "ImgBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ImgBuffer
		{
			get
			{
				return this._ImgBuffer;
			}
			set
			{
				this._ImgBuffer = value;
			}
		}

		[ProtoMember(11, IsRequired = true, Name = "NumDistance", DataFormat = DataFormat.TwosComplement)]
		public uint NumDistance
		{
			get
			{
				return this._NumDistance;
			}
			set
			{
				this._NumDistance = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "Weibo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Weibo
		{
			get
			{
				return this._Weibo;
			}
			set
			{
				this._Weibo = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "WeiboNickname", DataFormat = DataFormat.Default), DefaultValue("")]
		public string WeiboNickname
		{
			get
			{
				return this._WeiboNickname;
			}
			set
			{
				this._WeiboNickname = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "WeiboFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint WeiboFlag
		{
			get
			{
				return this._WeiboFlag;
			}
			set
			{
				this._WeiboFlag = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "VerifyFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint VerifyFlag
		{
			get
			{
				return this._VerifyFlag;
			}
			set
			{
				this._VerifyFlag = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "VerifyInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifyInfo
		{
			get
			{
				return this._VerifyInfo;
			}
			set
			{
				this._VerifyInfo = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "VerifyContent", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VerifyContent
		{
			get
			{
				return this._VerifyContent;
			}
			set
			{
				this._VerifyContent = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "HeadImgVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int HeadImgVersion
		{
			get
			{
				return this._HeadImgVersion;
			}
			set
			{
				this._HeadImgVersion = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "SnsUserInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SnsUserInfo SnsUserInfo
		{
			get
			{
				return this._SnsUserInfo;
			}
			set
			{
				this._SnsUserInfo = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				this._Country = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BigHeadImgUrl
		{
			get
			{
				return this._BigHeadImgUrl;
			}
			set
			{
				this._BigHeadImgUrl = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmallHeadImgUrl
		{
			get
			{
				return this._SmallHeadImgUrl;
			}
			set
			{
				this._SmallHeadImgUrl = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "MyBrandList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MyBrandList
		{
			get
			{
				return this._MyBrandList;
			}
			set
			{
				this._MyBrandList = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "CustomizedInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public CustomizedInfo CustomizedInfo
		{
			get
			{
				return this._CustomizedInfo;
			}
			set
			{
				this._CustomizedInfo = value;
			}
		}

		[ProtoMember(28, IsRequired = false, Name = "AntispamTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AntispamTicket
		{
			get
			{
				return this._AntispamTicket;
			}
			set
			{
				this._AntispamTicket = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
