using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetVoiceTransResRequest")]
	[Serializable]
	public class GetVoiceTransResRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _VoiceId = "";

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

		[ProtoMember(2, IsRequired = false, Name = "VoiceId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VoiceId
		{
			get
			{
				return this._VoiceId;
			}
			set
			{
				this._VoiceId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
