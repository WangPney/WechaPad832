using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameStartResp")]
	[Serializable]
	public class GameStartResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _LifeNum;

		private uint _CheckLeftTime;

		private string _Token = "";

		private int _Count;

		private readonly List<UserGameAchieveInfo> _RankList = new List<UserGameAchieveInfo>();

		private int _GamePropsCount = 0;

		private readonly List<GameUserPropsInfo> _GamePropsList = new List<GameUserPropsInfo>();

		private uint _GameCoinCount = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "LifeNum", DataFormat = DataFormat.TwosComplement)]
		public uint LifeNum
		{
			get
			{
				return this._LifeNum;
			}
			set
			{
				this._LifeNum = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CheckLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint CheckLeftTime
		{
			get
			{
				return this._CheckLeftTime;
			}
			set
			{
				this._CheckLeftTime = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Token", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				this._Token = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, Name = "RankList", DataFormat = DataFormat.Default)]
		public List<UserGameAchieveInfo> RankList
		{
			get
			{
				return this._RankList;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "GamePropsCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int GamePropsCount
		{
			get
			{
				return this._GamePropsCount;
			}
			set
			{
				this._GamePropsCount = value;
			}
		}

		[ProtoMember(8, Name = "GamePropsList", DataFormat = DataFormat.Default)]
		public List<GameUserPropsInfo> GamePropsList
		{
			get
			{
				return this._GamePropsList;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "GameCoinCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GameCoinCount
		{
			get
			{
				return this._GameCoinCount;
			}
			set
			{
				this._GameCoinCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
