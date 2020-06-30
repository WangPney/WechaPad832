using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetVoiceprintTicketRsaResponse")]
	[Serializable]
	public class GetVoiceprintTicketRsaResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _VoiceprintTicket = "";

		private BuiltinIPList _BuiltinIPList = null;

		private HostList _NewHostList = null;

		private NetworkControl _NetworkControl = null;

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

		[ProtoMember(2, IsRequired = false, Name = "VoiceprintTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VoiceprintTicket
		{
			get
			{
				return this._VoiceprintTicket;
			}
			set
			{
				this._VoiceprintTicket = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "BuiltinIPList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BuiltinIPList BuiltinIPList
		{
			get
			{
				return this._BuiltinIPList;
			}
			set
			{
				this._BuiltinIPList = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "NewHostList", DataFormat = DataFormat.Default), DefaultValue(null)]
		public HostList NewHostList
		{
			get
			{
				return this._NewHostList;
			}
			set
			{
				this._NewHostList = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "NetworkControl", DataFormat = DataFormat.Default), DefaultValue(null)]
		public NetworkControl NetworkControl
		{
			get
			{
				return this._NetworkControl;
			}
			set
			{
				this._NetworkControl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
