using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameShareReq")]
	[Serializable]
	public class GameShareReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _AppID = "";

		private uint _Type;

		private uint _Score;

		private string _Achieve = "";

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

		[ProtoMember(2, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "Achieve", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Achieve
		{
			get
			{
				return this._Achieve;
			}
			set
			{
				this._Achieve = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
