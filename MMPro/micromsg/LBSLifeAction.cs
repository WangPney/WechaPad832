using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LBSLifeAction")]
	[Serializable]
	public class LBSLifeAction : IExtensible
	{
		private uint _Type;

		private string _Name = "";

		private string _Desc = "";

		private string _Link = "";

		private uint _BookingCount;

		private readonly List<LBSLifeActionBooking> _BookingList = new List<LBSLifeActionBooking>();

		private uint _BargainCount;

		private readonly List<LBSLifeActionBargain> _BargainList = new List<LBSLifeActionBargain>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Name", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Desc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Desc
		{
			get
			{
				return this._Desc;
			}
			set
			{
				this._Desc = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Link", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Link
		{
			get
			{
				return this._Link;
			}
			set
			{
				this._Link = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "BookingCount", DataFormat = DataFormat.TwosComplement)]
		public uint BookingCount
		{
			get
			{
				return this._BookingCount;
			}
			set
			{
				this._BookingCount = value;
			}
		}

		[ProtoMember(6, Name = "BookingList", DataFormat = DataFormat.Default)]
		public List<LBSLifeActionBooking> BookingList
		{
			get
			{
				return this._BookingList;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "BargainCount", DataFormat = DataFormat.TwosComplement)]
		public uint BargainCount
		{
			get
			{
				return this._BargainCount;
			}
			set
			{
				this._BargainCount = value;
			}
		}

		[ProtoMember(8, Name = "BargainList", DataFormat = DataFormat.Default)]
		public List<LBSLifeActionBargain> BargainList
		{
			get
			{
				return this._BargainList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
