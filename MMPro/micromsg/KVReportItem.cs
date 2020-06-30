using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "KVReportItem")]
	[Serializable]
	public class KVReportItem : IExtensible
	{
		private uint _LogID;

		private string _Value = "";

		private uint _StartTime;

		private uint _EndTime;

		private uint _Count;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "LogID", DataFormat = DataFormat.TwosComplement)]
		public uint LogID
		{
			get
			{
				return this._LogID;
			}
			set
			{
				this._LogID = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Value", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "StartTime", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = true, Name = "EndTime", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
