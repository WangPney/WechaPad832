using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShareFavRequest")]
	[Serializable]
	public class ShareFavRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ToUser = "";

		private uint _Scene;

		private uint _Count;

		private readonly List<uint> _FavIdList = new List<uint>();

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

		[ProtoMember(2, IsRequired = false, Name = "ToUser", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ToUser
		{
			get
			{
				return this._ToUser;
			}
			set
			{
				this._ToUser = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, Name = "FavIdList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<uint> FavIdList
		{
			get
			{
				return this._FavIdList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
