using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CreatePoiRequest")]
	[Serializable]
	public class CreatePoiRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Name = "";

		private string _District = "";

		private string _Street = "";

		private LbsLocation _Loc;

		private uint _Count;

		private readonly List<SKBuiltinString_t> _Categories = new List<SKBuiltinString_t>();

		private string _Telephone = "";

		private string _PhotoUrl = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
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

		[ProtoMember(3, IsRequired = false, Name = "District", DataFormat = DataFormat.Default), DefaultValue("")]
		public string District
		{
			get
			{
				return this._District;
			}
			set
			{
				this._District = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Street", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Street
		{
			get
			{
				return this._Street;
			}
			set
			{
				this._Street = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Loc", DataFormat = DataFormat.Default)]
		public LbsLocation Loc
		{
			get
			{
				return this._Loc;
			}
			set
			{
				this._Loc = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, Name = "Categories", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> Categories
		{
			get
			{
				return this._Categories;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "Telephone", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Telephone
		{
			get
			{
				return this._Telephone;
			}
			set
			{
				this._Telephone = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "PhotoUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PhotoUrl
		{
			get
			{
				return this._PhotoUrl;
			}
			set
			{
				this._PhotoUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
