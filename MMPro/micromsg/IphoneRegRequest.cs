using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "IphoneRegRequest")]
	[Serializable]
	public class IphoneRegRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _Token = "";

		private string _Sound = "";

		private uint _Status = 0u;

		private string _VoipSound = "";

		private uint _TokenCert = 0u;

		private uint _TokenEnv = 0u;

		private uint _TokenScene = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "Token", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "Sound", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Sound
		{
			get
			{
				return this._Sound;
			}
			set
			{
				this._Sound = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Status", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "VoipSound", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VoipSound
		{
			get
			{
				return this._VoipSound;
			}
			set
			{
				this._VoipSound = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "TokenCert", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TokenCert
		{
			get
			{
				return this._TokenCert;
			}
			set
			{
				this._TokenCert = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "TokenEnv", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TokenEnv
		{
			get
			{
				return this._TokenEnv;
			}
			set
			{
				this._TokenEnv = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "TokenScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TokenScene
		{
			get
			{
				return this._TokenScene;
			}
			set
			{
				this._TokenScene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
