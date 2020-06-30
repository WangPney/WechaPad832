using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModUserInfo")]
	[Serializable]
	public class ModUserInfo : IExtensible
	{
		private uint _BitFlag;

		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _NickName;

		private uint _BindUin;

		private SKBuiltinString_t _BindEmail;

		private SKBuiltinString_t _BindMobile;

		private uint _Status;

		private uint _ImgLen;

		private byte[] _ImgBuf = null;

		private int _Sex = 0;

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private uint _PersonalCard = 0u;

		private DisturbSetting _DisturbSetting = null;

		private uint _PluginFlag = 0u;

		private uint _VerifyFlag = 0u;

		private string _VerifyInfo = "";

		private int _Point = 0;

		private int _Experience = 0;

		private int _Level = 0;

		private int _LevelLowExp = 0;

		private int _LevelHighExp = 0;

		private string _Weibo = "";

		private uint _PluginSwitch = 0u;

		private GmailList _GmailList = null;

		private string _Alias = "";

		private string _WeiboNickname = "";

		private uint _WeiboFlag = 0u;

		private uint _FaceBookFlag = 0u;

		private ulong _FBUserID = 0uL;

		private string _FBUserName = "";

		private int _AlbumStyle = 0;

		private int _AlbumFlag = 0;

		private string _AlbumBGImgID = "";

		private uint _TXNewsCategory = 0u;

		private string _FBToken = "";

		private string _Country = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BitFlag", DataFormat = DataFormat.TwosComplement)]
		public uint BitFlag
		{
			get
			{
				return this._BitFlag;
			}
			set
			{
				this._BitFlag = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "NickName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = true, Name = "BindUin", DataFormat = DataFormat.TwosComplement)]
		public uint BindUin
		{
			get
			{
				return this._BindUin;
			}
			set
			{
				this._BindUin = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "BindEmail", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t BindEmail
		{
			get
			{
				return this._BindEmail;
			}
			set
			{
				this._BindEmail = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "BindMobile", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t BindMobile
		{
			get
			{
				return this._BindMobile;
			}
			set
			{
				this._BindMobile = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public uint Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "ImgLen", DataFormat = DataFormat.TwosComplement)]
		public uint ImgLen
		{
			get
			{
				return this._ImgLen;
			}
			set
			{
				this._ImgLen = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "ImgBuf", DataFormat = DataFormat.Default), DefaultValue(null)]
		public byte[] ImgBuf
		{
			get
			{
				return this._ImgBuf;
			}
			set
			{
				this._ImgBuf = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "Sex", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(11, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(12, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(13, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(14, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(15, IsRequired = false, Name = "DisturbSetting", DataFormat = DataFormat.Default), DefaultValue(null)]
		public DisturbSetting DisturbSetting
		{
			get
			{
				return this._DisturbSetting;
			}
			set
			{
				this._DisturbSetting = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "PluginFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PluginFlag
		{
			get
			{
				return this._PluginFlag;
			}
			set
			{
				this._PluginFlag = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "VerifyFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(18, IsRequired = false, Name = "VerifyInfo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(19, IsRequired = false, Name = "Point", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Point
		{
			get
			{
				return this._Point;
			}
			set
			{
				this._Point = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "Experience", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Experience
		{
			get
			{
				return this._Experience;
			}
			set
			{
				this._Experience = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "Level", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				this._Level = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "LevelLowExp", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int LevelLowExp
		{
			get
			{
				return this._LevelLowExp;
			}
			set
			{
				this._LevelLowExp = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "LevelHighExp", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int LevelHighExp
		{
			get
			{
				return this._LevelHighExp;
			}
			set
			{
				this._LevelHighExp = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "Weibo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(25, IsRequired = false, Name = "PluginSwitch", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PluginSwitch
		{
			get
			{
				return this._PluginSwitch;
			}
			set
			{
				this._PluginSwitch = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "GmailList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public GmailList GmailList
		{
			get
			{
				return this._GmailList;
			}
			set
			{
				this._GmailList = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(28, IsRequired = false, Name = "WeiboNickname", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(29, IsRequired = false, Name = "WeiboFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(30, IsRequired = false, Name = "FaceBookFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FaceBookFlag
		{
			get
			{
				return this._FaceBookFlag;
			}
			set
			{
				this._FaceBookFlag = value;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "FBUserID", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong FBUserID
		{
			get
			{
				return this._FBUserID;
			}
			set
			{
				this._FBUserID = value;
			}
		}

		[ProtoMember(32, IsRequired = false, Name = "FBUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FBUserName
		{
			get
			{
				return this._FBUserName;
			}
			set
			{
				this._FBUserName = value;
			}
		}

		[ProtoMember(33, IsRequired = false, Name = "AlbumStyle", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int AlbumStyle
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

		[ProtoMember(34, IsRequired = false, Name = "AlbumFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int AlbumFlag
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

		[ProtoMember(35, IsRequired = false, Name = "AlbumBGImgID", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(36, IsRequired = false, Name = "TXNewsCategory", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TXNewsCategory
		{
			get
			{
				return this._TXNewsCategory;
			}
			set
			{
				this._TXNewsCategory = value;
			}
		}

		[ProtoMember(37, IsRequired = false, Name = "FBToken", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FBToken
		{
			get
			{
				return this._FBToken;
			}
			set
			{
				this._FBToken = value;
			}
		}

		[ProtoMember(38, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
