using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BackupFinishRequest")]
	[Serializable]
	public class BackupFinishRequest : IExtensible
	{
		private string _ID;

		private BackupReportList _Data = null;

		private uint _ServerSessionCount = 0u;

		private uint _ServerMessageCount = 0u;

		private uint _ServerFileCount = 0u;

		private uint _CalculateSize = 0u;

		private uint _ServerDataPushSize = 0u;

		private uint _ServerReadDBTotalTime = 0u;

		private uint _ServerReadFileTotalTime = 0u;

		private uint _ServerCostTotalTime = 0u;

		private uint _ServerVersion = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ID", DataFormat = DataFormat.Default)]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Data", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BackupReportList Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ServerSessionCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerSessionCount
		{
			get
			{
				return this._ServerSessionCount;
			}
			set
			{
				this._ServerSessionCount = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ServerMessageCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerMessageCount
		{
			get
			{
				return this._ServerMessageCount;
			}
			set
			{
				this._ServerMessageCount = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ServerFileCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerFileCount
		{
			get
			{
				return this._ServerFileCount;
			}
			set
			{
				this._ServerFileCount = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "CalculateSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint CalculateSize
		{
			get
			{
				return this._CalculateSize;
			}
			set
			{
				this._CalculateSize = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ServerDataPushSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerDataPushSize
		{
			get
			{
				return this._ServerDataPushSize;
			}
			set
			{
				this._ServerDataPushSize = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "ServerReadDBTotalTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerReadDBTotalTime
		{
			get
			{
				return this._ServerReadDBTotalTime;
			}
			set
			{
				this._ServerReadDBTotalTime = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "ServerReadFileTotalTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerReadFileTotalTime
		{
			get
			{
				return this._ServerReadFileTotalTime;
			}
			set
			{
				this._ServerReadFileTotalTime = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "ServerCostTotalTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerCostTotalTime
		{
			get
			{
				return this._ServerCostTotalTime;
			}
			set
			{
				this._ServerCostTotalTime = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "ServerVersion", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ServerVersion
		{
			get
			{
				return this._ServerVersion;
			}
			set
			{
				this._ServerVersion = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
