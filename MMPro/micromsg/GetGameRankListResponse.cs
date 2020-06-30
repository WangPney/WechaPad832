using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetGameRankListResponse")]
	[Serializable]
	public class GetGameRankListResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<UserGameRankInfo> _RankList = new List<UserGameRankInfo>();

		private uint _FriendsCount = 0u;

		private uint _HasReportScore = 0u;

		private YYBStruct _SYYB = null;

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, Name = "RankList", DataFormat = DataFormat.Default)]
		public List<UserGameRankInfo> RankList
		{
			get
			{
				return this._RankList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "FriendsCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FriendsCount
		{
			get
			{
				return this._FriendsCount;
			}
			set
			{
				this._FriendsCount = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "HasReportScore", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint HasReportScore
		{
			get
			{
				return this._HasReportScore;
			}
			set
			{
				this._HasReportScore = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "SYYB", DataFormat = DataFormat.Default), DefaultValue(null)]
		public YYBStruct SYYB
		{
			get
			{
				return this._SYYB;
			}
			set
			{
				this._SYYB = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
