using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UpgradeChatRoomResp")]
	[Serializable]
	public class UpgradeChatRoomResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ChatRoomData = "";

		private string _ResultMsg = "";

		private uint _MaxCount = 0u;

		private uint _MobileQuota;

		private uint _CardQuota;

		private uint _DonateQuota;

		private uint _TotalQuota = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "ChatRoomData", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomData
		{
			get
			{
				return this._ChatRoomData;
			}
			set
			{
				this._ChatRoomData = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ResultMsg", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ResultMsg
		{
			get
			{
				return this._ResultMsg;
			}
			set
			{
				this._ResultMsg = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "MaxCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint MaxCount
		{
			get
			{
				return this._MaxCount;
			}
			set
			{
				this._MaxCount = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "MobileQuota", DataFormat = DataFormat.TwosComplement)]
		public uint MobileQuota
		{
			get
			{
				return this._MobileQuota;
			}
			set
			{
				this._MobileQuota = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "CardQuota", DataFormat = DataFormat.TwosComplement)]
		public uint CardQuota
		{
			get
			{
				return this._CardQuota;
			}
			set
			{
				this._CardQuota = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "DonateQuota", DataFormat = DataFormat.TwosComplement)]
		public uint DonateQuota
		{
			get
			{
				return this._DonateQuota;
			}
			set
			{
				this._DonateQuota = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "TotalQuota", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TotalQuota
		{
			get
			{
				return this._TotalQuota;
			}
			set
			{
				this._TotalQuota = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
