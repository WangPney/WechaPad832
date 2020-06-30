using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameEndReq")]
	[Serializable]
	public class GameEndReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private int _Count;

		private readonly List<EnemyGameKilled> _EnemyKilled = new List<EnemyGameKilled>();

		private uint _LocalScore;

		private uint _ConsumeTime;

		private string _Token = "";

		private uint _DeadCount = 0u;

		private int _GameConsumePropsCount = 0;

		private readonly List<GameConsumeProps> _GameConsumePropsList = new List<GameConsumeProps>();

		private uint _GameStartTime = 0u;

		private uint _GameEndTime = 0u;

		private uint _ShieldNum = 0u;

		private uint _TotalShots = 0u;

		private uint _GameCoinCount = 0u;

		private uint _ClientUseReviveNum = 0u;

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

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, Name = "EnemyKilled", DataFormat = DataFormat.Default)]
		public List<EnemyGameKilled> EnemyKilled
		{
			get
			{
				return this._EnemyKilled;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "LocalScore", DataFormat = DataFormat.TwosComplement)]
		public uint LocalScore
		{
			get
			{
				return this._LocalScore;
			}
			set
			{
				this._LocalScore = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "ConsumeTime", DataFormat = DataFormat.TwosComplement)]
		public uint ConsumeTime
		{
			get
			{
				return this._ConsumeTime;
			}
			set
			{
				this._ConsumeTime = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Token", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(8, IsRequired = false, Name = "DeadCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint DeadCount
		{
			get
			{
				return this._DeadCount;
			}
			set
			{
				this._DeadCount = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "GameConsumePropsCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int GameConsumePropsCount
		{
			get
			{
				return this._GameConsumePropsCount;
			}
			set
			{
				this._GameConsumePropsCount = value;
			}
		}

		[ProtoMember(10, Name = "GameConsumePropsList", DataFormat = DataFormat.Default)]
		public List<GameConsumeProps> GameConsumePropsList
		{
			get
			{
				return this._GameConsumePropsList;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "GameStartTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GameStartTime
		{
			get
			{
				return this._GameStartTime;
			}
			set
			{
				this._GameStartTime = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "GameEndTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GameEndTime
		{
			get
			{
				return this._GameEndTime;
			}
			set
			{
				this._GameEndTime = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "ShieldNum", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ShieldNum
		{
			get
			{
				return this._ShieldNum;
			}
			set
			{
				this._ShieldNum = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "TotalShots", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TotalShots
		{
			get
			{
				return this._TotalShots;
			}
			set
			{
				this._TotalShots = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "GameCoinCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(16, IsRequired = false, Name = "ClientUseReviveNum", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ClientUseReviveNum
		{
			get
			{
				return this._ClientUseReviveNum;
			}
			set
			{
				this._ClientUseReviveNum = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
