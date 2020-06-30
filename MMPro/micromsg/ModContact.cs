using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ModContact")]
	[Serializable]
	public class ModContact : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private SKBuiltinString_t _NickName;

		private SKBuiltinString_t _PYInitial;

		private SKBuiltinString_t _QuanPin;

		private int _Sex;

		private SKBuiltinBuffer_t _ImgBuf;

		private uint _BitMask;

		private uint _BitVal;

		private uint _ImgFlag;

		private SKBuiltinString_t _Remark = null;

		private SKBuiltinString_t _RemarkPYInitial = null;

		private SKBuiltinString_t _RemarkQuanPin = null;

		private uint _ContactType = 0u;

		private uint _RoomInfoCount = 0u;

		private readonly List<RoomInfo> _RoomInfoList = new List<RoomInfo>();

		private SKBuiltinString_t _DomainList = null;

		private uint _ChatRoomNotify = 0u;

		private uint _AddContactScene = 0u;

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private uint _PersonalCard = 0u;

		private uint _HasWeiXinHdHeadImg = 0u;

		private uint _VerifyFlag = 0u;

		private string _VerifyInfo = "";

		private int _Level = 0;

		private uint _Source = 0u;

		private string _Weibo = "";

		private string _VerifyContent = "";

		private string _Alias = "";

		private string _ChatRoomOwner = "";

		private string _WeiboNickname = "";

		private uint _WeiboFlag = 0u;

		private int _AlbumStyle = 0;

		private int _AlbumFlag = 0;

		private string _AlbumBGImgID = "";

		private SnsUserInfo _SnsUserInfo = null;

		private string _Country = "";

		private string _BigHeadImgUrl = "";

		private string _SmallHeadImgUrl = "";

		private string _MyBrandList = "";

		private CustomizedInfo _CustomizedInfo = null;

		private string _ChatRoomData = "";

		private string _HeadImgMd5 = "";

		private string _EncryptUserName = "";

		private string _IDCardNum = "";

		private string _RealName = "";

		private string _MobileHash = "";

		private string _MobileFullHash = "";

		private AdditionalContactList _AdditionalContactList = null;

		private uint _ChatroomVersion = 0u;

		private string _ExtInfo = "";

		private uint _ChatroomMaxCount = 0u;

		private uint _ChatroomType = 0u;

		private ChatRoomMemberData _NewChatroomData = null;

		private int _DeleteFlag = 0;

		private string _Description = "";

		private string _CardImgUrl = "";

		private string _LabelIDList = "";

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

		[ProtoMember(3, IsRequired = true, Name = "PYInitial", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t PYInitial
		{
			get
			{
				return this._PYInitial;
			}
			set
			{
				this._PYInitial = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "QuanPin", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t QuanPin
		{
			get
			{
				return this._QuanPin;
			}
			set
			{
				this._QuanPin = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Sex", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ImgBuf
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

		[ProtoMember(7, IsRequired = true, Name = "BitMask", DataFormat = DataFormat.TwosComplement)]
		public uint BitMask
		{
			get
			{
				return this._BitMask;
			}
			set
			{
				this._BitMask = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "BitVal", DataFormat = DataFormat.TwosComplement)]
		public uint BitVal
		{
			get
			{
				return this._BitVal;
			}
			set
			{
				this._BitVal = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "ImgFlag", DataFormat = DataFormat.TwosComplement)]
		public uint ImgFlag
		{
			get
			{
				return this._ImgFlag;
			}
			set
			{
				this._ImgFlag = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "Remark", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t Remark
		{
			get
			{
				return this._Remark;
			}
			set
			{
				this._Remark = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "RemarkPYInitial", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t RemarkPYInitial
		{
			get
			{
				return this._RemarkPYInitial;
			}
			set
			{
				this._RemarkPYInitial = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "RemarkQuanPin", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t RemarkQuanPin
		{
			get
			{
				return this._RemarkQuanPin;
			}
			set
			{
				this._RemarkQuanPin = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "ContactType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ContactType
		{
			get
			{
				return this._ContactType;
			}
			set
			{
				this._ContactType = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "RoomInfoCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint RoomInfoCount
		{
			get
			{
				return this._RoomInfoCount;
			}
			set
			{
				this._RoomInfoCount = value;
			}
		}

		[ProtoMember(15, Name = "RoomInfoList", DataFormat = DataFormat.Default)]
		public List<RoomInfo> RoomInfoList
		{
			get
			{
				return this._RoomInfoList;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "DomainList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t DomainList
		{
			get
			{
				return this._DomainList;
			}
			set
			{
				this._DomainList = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "ChatRoomNotify", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChatRoomNotify
		{
			get
			{
				return this._ChatRoomNotify;
			}
			set
			{
				this._ChatRoomNotify = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "AddContactScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint AddContactScene
		{
			get
			{
				return this._AddContactScene;
			}
			set
			{
				this._AddContactScene = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(20, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(21, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(22, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(23, IsRequired = false, Name = "HasWeiXinHdHeadImg", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint HasWeiXinHdHeadImg
		{
			get
			{
				return this._HasWeiXinHdHeadImg;
			}
			set
			{
				this._HasWeiXinHdHeadImg = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "VerifyFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(25, IsRequired = false, Name = "VerifyInfo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(26, IsRequired = false, Name = "Level", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(27, IsRequired = false, Name = "Source", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				this._Source = value;
			}
		}

		[ProtoMember(28, IsRequired = false, Name = "Weibo", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(29, IsRequired = false, Name = "VerifyContent", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(30, IsRequired = false, Name = "Alias", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(31, IsRequired = false, Name = "ChatRoomOwner", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomOwner
		{
			get
			{
				return this._ChatRoomOwner;
			}
			set
			{
				this._ChatRoomOwner = value;
			}
		}

		[ProtoMember(32, IsRequired = false, Name = "WeiboNickname", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(33, IsRequired = false, Name = "WeiboFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(34, IsRequired = false, Name = "AlbumStyle", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(35, IsRequired = false, Name = "AlbumFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
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

		[ProtoMember(36, IsRequired = false, Name = "AlbumBGImgID", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(37, IsRequired = false, Name = "SnsUserInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(39, IsRequired = false, Name = "BigHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(40, IsRequired = false, Name = "SmallHeadImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(41, IsRequired = false, Name = "MyBrandList", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(42, IsRequired = false, Name = "CustomizedInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(43, IsRequired = false, Name = "ChatRoomData", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomData
		{
			get
			{
				return this._ChatRoomData;
			}
			set
			{
				this._ChatRoomData = value;
			}
		}

		[ProtoMember(44, IsRequired = false, Name = "HeadImgMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string HeadImgMd5
		{
			get
			{
				return this._HeadImgMd5;
			}
			set
			{
				this._HeadImgMd5 = value;
			}
		}

		[ProtoMember(45, IsRequired = false, Name = "EncryptUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string EncryptUserName
		{
			get
			{
				return this._EncryptUserName;
			}
			set
			{
				this._EncryptUserName = value;
			}
		}

		[ProtoMember(46, IsRequired = false, Name = "IDCardNum", DataFormat = DataFormat.Default), DefaultValue("")]
		public string IDCardNum
		{
			get
			{
				return this._IDCardNum;
			}
			set
			{
				this._IDCardNum = value;
			}
		}

		[ProtoMember(47, IsRequired = false, Name = "RealName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RealName
		{
			get
			{
				return this._RealName;
			}
			set
			{
				this._RealName = value;
			}
		}

		[ProtoMember(48, IsRequired = false, Name = "MobileHash", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MobileHash
		{
			get
			{
				return this._MobileHash;
			}
			set
			{
				this._MobileHash = value;
			}
		}

		[ProtoMember(49, IsRequired = false, Name = "MobileFullHash", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MobileFullHash
		{
			get
			{
				return this._MobileFullHash;
			}
			set
			{
				this._MobileFullHash = value;
			}
		}

		[ProtoMember(50, IsRequired = false, Name = "AdditionalContactList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public AdditionalContactList AdditionalContactList
		{
			get
			{
				return this._AdditionalContactList;
			}
			set
			{
				this._AdditionalContactList = value;
			}
		}

		[ProtoMember(53, IsRequired = false, Name = "ChatroomVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChatroomVersion
		{
			get
			{
				return this._ChatroomVersion;
			}
			set
			{
				this._ChatroomVersion = value;
			}
		}

		[ProtoMember(54, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		[ProtoMember(55, IsRequired = false, Name = "ChatroomMaxCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChatroomMaxCount
		{
			get
			{
				return this._ChatroomMaxCount;
			}
			set
			{
				this._ChatroomMaxCount = value;
			}
		}

		[ProtoMember(56, IsRequired = false, Name = "ChatroomType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ChatroomType
		{
			get
			{
				return this._ChatroomType;
			}
			set
			{
				this._ChatroomType = value;
			}
		}

		[ProtoMember(57, IsRequired = false, Name = "NewChatroomData", DataFormat = DataFormat.Default), DefaultValue(null)]
		public ChatRoomMemberData NewChatroomData
		{
			get
			{
				return this._NewChatroomData;
			}
			set
			{
				this._NewChatroomData = value;
			}
		}

		[ProtoMember(58, IsRequired = false, Name = "DeleteFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int DeleteFlag
		{
			get
			{
				return this._DeleteFlag;
			}
			set
			{
				this._DeleteFlag = value;
			}
		}

		[ProtoMember(59, IsRequired = false, Name = "Description", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this._Description = value;
			}
		}

		[ProtoMember(60, IsRequired = false, Name = "CardImgUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CardImgUrl
		{
			get
			{
				return this._CardImgUrl;
			}
			set
			{
				this._CardImgUrl = value;
			}
		}

		[ProtoMember(61, IsRequired = false, Name = "LabelIDList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string LabelIDList
		{
			get
			{
				return this._LabelIDList;
			}
			set
			{
				this._LabelIDList = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
