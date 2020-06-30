using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "MemberResp")]
	[Serializable]
	public class MemberResp : IExtensible
	{
		private SKBuiltinString_t _MemberName;

		private uint _MemberStatus;

		private SKBuiltinString_t _NickName;

		private SKBuiltinString_t _PYInitial;

		private SKBuiltinString_t _QuanPin;

		private int _Sex;

		private SKBuiltinString_t _Remark;

		private SKBuiltinString_t _RemarkPYInitial;

		private SKBuiltinString_t _RemarkQuanPin;

		private uint _ContactType;

		private string _Province = "";

		private string _City = "";

		private string _Signature = "";

		private uint _PersonalCard = 0u;

		private uint _VerifyFlag = 0u;

		private string _VerifyInfo = "";

		private string _Country = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MemberName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t MemberName
		{
			get
			{
				return this._MemberName;
			}
			set
			{
				this._MemberName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MemberStatus", DataFormat = DataFormat.TwosComplement)]
		public uint MemberStatus
		{
			get
			{
				return this._MemberStatus;
			}
			set
			{
				this._MemberStatus = value;
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

		[ProtoMember(4, IsRequired = true, Name = "PYInitial", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = true, Name = "QuanPin", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = true, Name = "Sex", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = true, Name = "Remark", DataFormat = DataFormat.Default)]
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

		[ProtoMember(10, IsRequired = true, Name = "RemarkPYInitial", DataFormat = DataFormat.Default)]
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

		[ProtoMember(11, IsRequired = true, Name = "RemarkQuanPin", DataFormat = DataFormat.Default)]
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

		[ProtoMember(12, IsRequired = true, Name = "ContactType", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(13, IsRequired = false, Name = "Province", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(14, IsRequired = false, Name = "City", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(15, IsRequired = false, Name = "Signature", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(16, IsRequired = false, Name = "PersonalCard", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(19, IsRequired = false, Name = "Country", DataFormat = DataFormat.Default), DefaultValue("")]
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
