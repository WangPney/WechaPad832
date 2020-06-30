using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameMsg")]
	[Serializable]
	public class GameMsg : IExtensible
	{
		private uint _MsgId;

		private uint _Status;

		private string _Object = "";

		private uint _UpdateTime;

		private uint _UpdateSeq;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "Object", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Object
		{
			get
			{
				return this._Object;
			}
			set
			{
				this._Object = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "UpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				this._UpdateTime = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "UpdateSeq", DataFormat = DataFormat.TwosComplement)]
		public uint UpdateSeq
		{
			get
			{
				return this._UpdateSeq;
			}
			set
			{
				this._UpdateSeq = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
