using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserGameRankInfo")]
	[Serializable]
	public class UserGameRankInfo : IExtensible
	{
		private string _UserName = "";

		private uint _Score;

		private uint _Rank = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Score", DataFormat = DataFormat.TwosComplement)]
		public uint Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				this._Score = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Rank", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Rank
		{
			get
			{
				return this._Rank;
			}
			set
			{
				this._Rank = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
