using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchOrRecommendItem")]
	[Serializable]
	public class SearchOrRecommendItem : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _NickName;

		private int _Sex;

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private uint _PersonalCard = 0u;

		private uint _VerifyFlag = 0u;

		private string _VerifyInfo = "";

		private string _Weibo = "";

		private string _Alias = "";

		private string _WeiboNickname = "";

		private uint _WeiboFlag = 0u;

		private string _Country = "";

		private CustomizedInfo _CustomizedInfo = null;

		private string _BigHeadImgUrl = "";

		private string _SmallHeadImgUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
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

		[ProtoMember(2, IsRequired = true, Name = "NickName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t NickName
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

		[ProtoMember(3, IsRequired = true, Name = "Sex", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(5, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(6, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(7, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PersonalCard
		{
			get
			{
				return this._PersonalCard;
			}
			set
			{
				this._PersonalCard = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "VerifyFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(9, IsRequired = false, Name = "VerifyInfo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(10, IsRequired = false, Name = "Weibo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(11, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Alias
		{
			get
			{
				return this._Alias;
			}
			set
			{
				this._Alias = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "WeiboNickname", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(13, IsRequired = false, Name = "WeiboFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(14, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(15, IsRequired = false, Name = "CustomizedInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(16, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(17, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
