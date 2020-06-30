using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "PropertySurveyItem")]
	[Serializable]
	public class PropertySurveyItem : IExtensible
	{
		private string _DeviceModel = "";

		private string _OsType = "";

		private string _Module = "";

		private string _SubModule = "";

		private uint _AvgElapsedTime;

		private uint _MaxElapsedTime;

		private uint _MinElapsedTime;

		private uint _UseModuleCount;

		private string _Expand = "";

		private uint _BeginTime;

		private uint _EndTime;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "DeviceModel", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DeviceModel
		{
			get
			{
				return this._DeviceModel;
			}
			set
			{
				this._DeviceModel = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "OsType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string OsType
		{
			get
			{
				return this._OsType;
			}
			set
			{
				this._OsType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Module", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Module
		{
			get
			{
				return this._Module;
			}
			set
			{
				this._Module = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "SubModule", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SubModule
		{
			get
			{
				return this._SubModule;
			}
			set
			{
				this._SubModule = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "AvgElapsedTime", DataFormat = DataFormat.TwosComplement)]
		public uint AvgElapsedTime
		{
			get
			{
				return this._AvgElapsedTime;
			}
			set
			{
				this._AvgElapsedTime = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "MaxElapsedTime", DataFormat = DataFormat.TwosComplement)]
		public uint MaxElapsedTime
		{
			get
			{
				return this._MaxElapsedTime;
			}
			set
			{
				this._MaxElapsedTime = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "MinElapsedTime", DataFormat = DataFormat.TwosComplement)]
		public uint MinElapsedTime
		{
			get
			{
				return this._MinElapsedTime;
			}
			set
			{
				this._MinElapsedTime = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "UseModuleCount", DataFormat = DataFormat.TwosComplement)]
		public uint UseModuleCount
		{
			get
			{
				return this._UseModuleCount;
			}
			set
			{
				this._UseModuleCount = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "Expand", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Expand
		{
			get
			{
				return this._Expand;
			}
			set
			{
				this._Expand = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "BeginTime", DataFormat = DataFormat.TwosComplement)]
		public uint BeginTime
		{
			get
			{
				return this._BeginTime;
			}
			set
			{
				this._BeginTime = value;
			}
		}

		[ProtoMember(11, IsRequired = true, Name = "EndTime", DataFormat = DataFormat.TwosComplement)]
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
