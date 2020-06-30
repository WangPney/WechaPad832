using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "MFriend")]
	[Serializable]
	public class MFriend : IExtensible
	{
		private string _Username = "";

		private string _Nickname = "";

		private string _MobileMD5 = "";

		private int _Sex = 0;

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private uint _PersonalCard = 0u;

		private string _Alias = "";

		private FBFriend _FBInfo = null;

		private uint _AlbumFlag = 0u;

		private uint _AlbumStyle = 0u;

		private string _AlbumBGImgID = "";

		private SnsUserInfo _SnsUserInfo = null;

		private string _Country = "";

		private string _MyBrandList = "";

		private CustomizedInfo _CustomizedInfo = null;

		private string _BigHeadImgUrl = "";

		private string _SmallHeadImgUrl = "";

		private string _AntispamTicket = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Username", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this._Username = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Nickname", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Nickname
		{
			get
			{
				return this._Nickname;
			}
			set
			{
				this._Nickname = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "MobileMD5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MobileMD5
		{
			get
			{
				return this._MobileMD5;
			}
			set
			{
				this._MobileMD5 = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Sex", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(5, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(6, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(7, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(8, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(9, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(10, IsRequired = false, Name = "FBInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public FBFriend FBInfo
		{
			get
			{
				return this._FBInfo;
			}
			set
			{
				this._FBInfo = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "AlbumFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AlbumFlag
		{
			get
			{
				return this._AlbumFlag;
			}
			set
			{
				this._AlbumFlag = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "AlbumStyle", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AlbumStyle
		{
			get
			{
				return this._AlbumStyle;
			}
			set
			{
				this._AlbumStyle = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "AlbumBGImgID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AlbumBGImgID
		{
			get
			{
				return this._AlbumBGImgID;
			}
			set
			{
				this._AlbumBGImgID = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "SnsUserInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(15, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(16, IsRequired = false, Name = "MyBrandList", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(17, IsRequired = false, Name = "CustomizedInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(20, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(21, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(22, IsRequired = false, Name = "AntispamTicket", DataFormat = DataFormat.Default), DefaultValue("")]
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
