using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DataConfigInf")]
	[Serializable]
	public class DataConfigInf : IExtensible
	{
		private string _UserName;

		private string _Deviceid = "";

		private uint _CreateTime = 0u;

		private uint _LastModifyTime = 0u;

		private BackupStartGeneralInfo _DeviceInfo = null;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Deviceid", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Deviceid
		{
			get
			{
				return this._Deviceid;
			}
			set
			{
				this._Deviceid = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "CreateTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				this._CreateTime = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "LastModifyTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LastModifyTime
		{
			get
			{
				return this._LastModifyTime;
			}
			set
			{
				this._LastModifyTime = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "DeviceInfo", DataFormat = DataFormat.Default), DefaultValue(null)]
		public BackupStartGeneralInfo DeviceInfo
		{
			get
			{
				return this._DeviceInfo;
			}
			set
			{
				this._DeviceInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
