using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BackupStartResponse")]
	[Serializable]
	public class BackupStartResponse : IExtensible
	{
		private string _ID;

		private ulong _TotalCount;

		private ulong _TotalSize;

		private int _Status;

		private uint _NetworkState = 0u;

		private ulong _BigDataSize = 0uL;

		private BackupStartGeneralInfo _GeneralInfo = null;

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

		[ProtoMember(2, IsRequired = true, Name = "TotalCount", DataFormat = DataFormat.TwosComplement)]
		public ulong TotalCount
		{
			get
			{
				return this._TotalCount;
			}
			set
			{
				this._TotalCount = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalSize", DataFormat = DataFormat.TwosComplement)]
		public ulong TotalSize
		{
			get
			{
				return this._TotalSize;
			}
			set
			{
				this._TotalSize = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public int Status
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

		[ProtoMember(5, IsRequired = false, Name = "NetworkState", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NetworkState
		{
			get
			{
				return this._NetworkState;
			}
			set
			{
				this._NetworkState = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "BigDataSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong BigDataSize
		{
			get
			{
				return this._BigDataSize;
			}
			set
			{
				this._BigDataSize = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "GeneralInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BackupStartGeneralInfo GeneralInfo
		{
			get
			{
				return this._GeneralInfo;
			}
			set
			{
				this._GeneralInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
