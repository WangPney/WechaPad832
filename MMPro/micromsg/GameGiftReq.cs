using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameGiftReq")]
	[Serializable]
	public class GameGiftReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private uint _LocalLifeNum;

		private int _Count;

		private readonly List<SKBuiltinString_t> _UserNameList = new List<SKBuiltinString_t>();

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

		[ProtoMember(2, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "LocalLifeNum", DataFormat = DataFormat.TwosComplement)]
		public uint LocalLifeNum
		{
			get
			{
				return this._LocalLifeNum;
			}
			set
			{
				this._LocalLifeNum = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public int Count
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

		[ProtoMember(5, Name = "UserNameList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> UserNameList
		{
			get
			{
				return this._UserNameList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
