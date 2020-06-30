using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetCardListFromAppRequest")]
	[Serializable]
	public class GetCardListFromAppRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private readonly List<CardListItem> _card_list = new List<CardListItem>();

		private uint _from_scene = 0u;

		private string _bundle_id = "";

		private string _package_name = "";

		private string _sign = "";

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

		[ProtoMember(2, Name = "card_list", DataFormat = DataFormat.Default)]
		public List<CardListItem> card_list
		{
			get
			{
				return this._card_list;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "from_scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint from_scene
		{
			get
			{
				return this._from_scene;
			}
			set
			{
				this._from_scene = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "bundle_id", DataFormat = DataFormat.Default), DefaultValue("")]
		public string bundle_id
		{
			get
			{
				return this._bundle_id;
			}
			set
			{
				this._bundle_id = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "package_name", DataFormat = DataFormat.Default), DefaultValue("")]
		public string package_name
		{
			get
			{
				return this._package_name;
			}
			set
			{
				this._package_name = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "sign", DataFormat = DataFormat.Default), DefaultValue("")]
		public string sign
		{
			get
			{
				return this._sign;
			}
			set
			{
				this._sign = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
