using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PossibleFriend")]
	[Serializable]
	public class PossibleFriend : IExtensible
	{
		private string _UserName = "";

		private string _NickName = "";

		private string _PYInitial = "";

		private string _QuanPin = "";

		private int _Sex;

		private uint _ImgFlag;

		private uint _ContactType;

		private string _DomainList = "";

		private string _Source = "";

		private uint _FriendScene;

		private string _Mobile = "";

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

		[ProtoMember(3, IsRequired = false, Name = "PYInitial", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PYInitial
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

		[ProtoMember(4, IsRequired = false, Name = "QuanPin", DataFormat = DataFormat.Default), DefaultValue("")]
		public string QuanPin
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

		[ProtoMember(6, IsRequired = true, Name = "ImgFlag", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = true, Name = "ContactType", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "DomainList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DomainList
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

		[ProtoMember(9, IsRequired = false, Name = "Source", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Source
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

		[ProtoMember(10, IsRequired = true, Name = "FriendScene", DataFormat = DataFormat.TwosComplement)]
		public uint FriendScene
		{
			get
			{
				return this._FriendScene;
			}
			set
			{
				this._FriendScene = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "Mobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Mobile
		{
			get
			{
				return this._Mobile;
			}
			set
			{
				this._Mobile = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
