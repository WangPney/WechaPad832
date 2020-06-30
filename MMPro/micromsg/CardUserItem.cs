using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CardUserItem")]
	[Serializable]
	public class CardUserItem : IExtensible
	{
		private string _CardId = "";

		private ulong _UpdateSequence = 0uL;

		private uint _StateFlag = 0u;

		private uint _UpdateTime = 0u;

		private uint _Status = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "CardId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CardId
		{
			get
			{
				return this._CardId;
			}
			set
			{
				this._CardId = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "UpdateSequence", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong UpdateSequence
		{
			get
			{
				return this._UpdateSequence;
			}
			set
			{
				this._UpdateSequence = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "StateFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint StateFlag
		{
			get
			{
				return this._StateFlag;
			}
			set
			{
				this._StateFlag = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "UpdateTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(5, IsRequired = false, Name = "Status", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
