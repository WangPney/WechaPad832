using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SendSmsToMFriendReq")]
	[Serializable]
	public class SendSmsToMFriendReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Ticket = "";

		private uint _MobileCount;

		private readonly List<SKBuiltinString_t> _MobileList = new List<SKBuiltinString_t>();

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

		[ProtoMember(2, IsRequired = false, Name = "Ticket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Ticket
		{
			get
			{
				return this._Ticket;
			}
			set
			{
				this._Ticket = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MobileCount", DataFormat = DataFormat.TwosComplement)]
		public uint MobileCount
		{
			get
			{
				return this._MobileCount;
			}
			set
			{
				this._MobileCount = value;
			}
		}

		[ProtoMember(4, Name = "MobileList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> MobileList
		{
			get
			{
				return this._MobileList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
