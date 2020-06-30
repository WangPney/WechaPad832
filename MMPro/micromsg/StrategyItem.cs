using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "StrategyItem")]
	[Serializable]
	public class StrategyItem : IExtensible
	{
		private uint _LogType;

		private uint _Enalbe;

		private uint _Cycle;

		private string _ExtInfo = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "LogType", DataFormat = DataFormat.TwosComplement)]
		public uint LogType
		{
			get
			{
				return this._LogType;
			}
			set
			{
				this._LogType = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Enalbe", DataFormat = DataFormat.TwosComplement)]
		public uint Enalbe
		{
			get
			{
				return this._Enalbe;
			}
			set
			{
				this._Enalbe = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Cycle", DataFormat = DataFormat.TwosComplement)]
		public uint Cycle
		{
			get
			{
				return this._Cycle;
			}
			set
			{
				this._Cycle = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ExtInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
