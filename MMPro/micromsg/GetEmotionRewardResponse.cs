using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionRewardResponse")]
	[Serializable]
	public class GetEmotionRewardResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private readonly List<EmotionPrice> _Price = new List<EmotionPrice>();

		private uint _DonorNum = 0u;

		private readonly List<EmotionDonor> _Donors = new List<EmotionDonor>();

		private EmotionReward _Reward = null;

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

		[ProtoMember(2, Name = "Price", DataFormat = DataFormat.Default)]
		public List<EmotionPrice> Price
		{
			get
			{
				return this._Price;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "DonorNum", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint DonorNum
		{
			get
			{
				return this._DonorNum;
			}
			set
			{
				this._DonorNum = value;
			}
		}

		[ProtoMember(4, Name = "Donors", DataFormat = DataFormat.Default)]
		public List<EmotionDonor> Donors
		{
			get
			{
				return this._Donors;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Reward", DataFormat = DataFormat.Default), DefaultValue(null)]
		public EmotionReward Reward
		{
			get
			{
				return this._Reward;
			}
			set
			{
				this._Reward = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
