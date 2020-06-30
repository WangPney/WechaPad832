using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BackupStartRequest")]
	[Serializable]
	public class BackupStartRequest : IExtensible
	{
		private string _ID;

		private ulong _BigDataSize = 0uL;

		private ulong _SessionCount = 0uL;

		private ulong _MsgCount = 0uL;

		private BackupStartGeneralInfo _GeneralInfo = null;

		private ulong _DataSize = 0uL;

		private int _TransferType = 0;

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

		[ProtoMember(2, IsRequired = false, Name = "BigDataSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
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

		[ProtoMember(3, IsRequired = false, Name = "SessionCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong SessionCount
		{
			get
			{
				return this._SessionCount;
			}
			set
			{
				this._SessionCount = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "MsgCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong MsgCount
		{
			get
			{
				return this._MsgCount;
			}
			set
			{
				this._MsgCount = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "GeneralInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
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

		[ProtoMember(6, IsRequired = false, Name = "DataSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong DataSize
		{
			get
			{
				return this._DataSize;
			}
			set
			{
				this._DataSize = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "TransferType", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int TransferType
		{
			get
			{
				return this._TransferType;
			}
			set
			{
				this._TransferType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
