using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "IBeaconBoardcastResponse")]
	[Serializable]
	public class IBeaconBoardcastResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private IBeaconNotification _Notification = null;

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

		[ProtoMember(2, IsRequired = false, Name = "Notification", DataFormat = DataFormat.Default), DefaultValue(null)]
		public IBeaconNotification Notification
		{
			get
			{
				return this._Notification;
			}
			set
			{
				this._Notification = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
