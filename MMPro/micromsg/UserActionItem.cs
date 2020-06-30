using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UserActionItem")]
	[Serializable]
	public class UserActionItem : IExtensible
	{
		private uint _EventID;

		private uint _ClickCnt;

		private string _ActionPath = "";

		private uint _StartTime;

		private uint _EndTime;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "EventID", DataFormat = DataFormat.TwosComplement)]
		public uint EventID
		{
			get
			{
				return this._EventID;
			}
			set
			{
				this._EventID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ClickCnt", DataFormat = DataFormat.TwosComplement)]
		public uint ClickCnt
		{
			get
			{
				return this._ClickCnt;
			}
			set
			{
				this._ClickCnt = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ActionPath", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ActionPath
		{
			get
			{
				return this._ActionPath;
			}
			set
			{
				this._ActionPath = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "StartTime", DataFormat = DataFormat.TwosComplement)]
		public uint StartTime
		{
			get
			{
				return this._StartTime;
			}
			set
			{
				this._StartTime = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "EndTime", DataFormat = DataFormat.TwosComplement)]
		public uint EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				this._EndTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
