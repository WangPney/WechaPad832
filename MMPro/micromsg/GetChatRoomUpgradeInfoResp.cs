using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetChatRoomUpgradeInfoResp")]
	[Serializable]
	public class GetChatRoomUpgradeInfoResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ChatRoomUpgradeInfo = "";

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

		[ProtoMember(2, IsRequired = false, Name = "ChatRoomUpgradeInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomUpgradeInfo
		{
			get
			{
				return this._ChatRoomUpgradeInfo;
			}
			set
			{
				this._ChatRoomUpgradeInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
