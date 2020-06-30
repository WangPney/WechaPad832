using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "StatReportItem")]
	[Serializable]
	public class StatReportItem : IExtensible
	{
		private uint _ActionID;

		private uint _Time;

		private uint _IP;

		private uint _Port;

		private uint _IPType;

		private uint _NetType;

		private uint _IfSuc;

		private uint _FunID;

		private uint _Cost;

		private uint _AliveTime;

		private uint _UploadSize;

		private uint _DownloadSize;

		private uint _Count = 0u;

		private uint _IsWifiFirstConnect = 0u;

		private ulong _BeginTimeMS = 0uL;

		private ulong _EndTimeMS = 0uL;

		private uint _NotifySyncCount = 0u;

		private uint _PushSyncCount = 0u;

		private uint _SyncCount = 0u;

		private uint _IsDNS = 0u;

		private uint _IsSocket = 0u;

		private int _ErrCode = 0;

		private uint _SignalStrength = 0u;

		private uint _ISPCode = 0u;

		private string _ISPName = "";

		private uint _RetryCount = 0u;

		private string _Host = "";

		private uint _IPCnt = 0u;

		private ulong _reserved1 = 0uL;

		private ulong _reserved2 = 0uL;

		private ulong _reserved3 = 0uL;

		private uint _ClientIP = 0u;

		private uint _NetworkCost = 0u;

		private uint _DnsCount = 0u;

		private uint _DnsCost = 0u;

		private uint _ConnCount = 0u;

		private uint _ConnCost = 0u;

		private uint _NewDnsCostTime = 0u;

		private uint _NewDnsErrType = 0u;

		private uint _NewDnsErrCode = 0u;

		private uint _NewDnsSvrIp = 0u;

		private uint _FirstPkgTime = 0u;

		private uint _EndFlag = 0u;

		private uint _TotalTime = 0u;

		private uint _Conncosttime = 0u;

		private uint _Endstep = 0u;

		private uint _Dnscosttime = 0u;

		private uint _Dnserrtype = 0u;

		private int _NewNetType = 0;

		private int _SubNetType = 0;

		private string _NetExtraInfo = "";

		private string _StatReportExtraInfo = "";

		private int _TotalConnCost = 0;

		private int _IpIndex = 0;

		private int _InnerIp = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ActionID", DataFormat = DataFormat.TwosComplement)]
		public uint ActionID
		{
			get
			{
				return this._ActionID;
			}
			set
			{
				this._ActionID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Time", DataFormat = DataFormat.TwosComplement)]
		public uint Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				this._Time = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "IP", DataFormat = DataFormat.TwosComplement)]
		public uint IP
		{
			get
			{
				return this._IP;
			}
			set
			{
				this._IP = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Port", DataFormat = DataFormat.TwosComplement)]
		public uint Port
		{
			get
			{
				return this._Port;
			}
			set
			{
				this._Port = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "IPType", DataFormat = DataFormat.TwosComplement)]
		public uint IPType
		{
			get
			{
				return this._IPType;
			}
			set
			{
				this._IPType = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "NetType", DataFormat = DataFormat.TwosComplement)]
		public uint NetType
		{
			get
			{
				return this._NetType;
			}
			set
			{
				this._NetType = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "IfSuc", DataFormat = DataFormat.TwosComplement)]
		public uint IfSuc
		{
			get
			{
				return this._IfSuc;
			}
			set
			{
				this._IfSuc = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "FunID", DataFormat = DataFormat.TwosComplement)]
		public uint FunID
		{
			get
			{
				return this._FunID;
			}
			set
			{
				this._FunID = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "Cost", DataFormat = DataFormat.TwosComplement)]
		public uint Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				this._Cost = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "AliveTime", DataFormat = DataFormat.TwosComplement)]
		public uint AliveTime
		{
			get
			{
				return this._AliveTime;
			}
			set
			{
				this._AliveTime = value;
			}
		}

		[ProtoMember(11, IsRequired = true, Name = "UploadSize", DataFormat = DataFormat.TwosComplement)]
		public uint UploadSize
		{
			get
			{
				return this._UploadSize;
			}
			set
			{
				this._UploadSize = value;
			}
		}

		[ProtoMember(12, IsRequired = true, Name = "DownloadSize", DataFormat = DataFormat.TwosComplement)]
		public uint DownloadSize
		{
			get
			{
				return this._DownloadSize;
			}
			set
			{
				this._DownloadSize = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "Count", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(14, IsRequired = false, Name = "IsWifiFirstConnect", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IsWifiFirstConnect
		{
			get
			{
				return this._IsWifiFirstConnect;
			}
			set
			{
				this._IsWifiFirstConnect = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "BeginTimeMS", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong BeginTimeMS
		{
			get
			{
				return this._BeginTimeMS;
			}
			set
			{
				this._BeginTimeMS = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "EndTimeMS", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong EndTimeMS
		{
			get
			{
				return this._EndTimeMS;
			}
			set
			{
				this._EndTimeMS = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "NotifySyncCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NotifySyncCount
		{
			get
			{
				return this._NotifySyncCount;
			}
			set
			{
				this._NotifySyncCount = value;
			}
		}

		[ProtoMember(18, IsRequired = false, Name = "PushSyncCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint PushSyncCount
		{
			get
			{
				return this._PushSyncCount;
			}
			set
			{
				this._PushSyncCount = value;
			}
		}

		[ProtoMember(19, IsRequired = false, Name = "SyncCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SyncCount
		{
			get
			{
				return this._SyncCount;
			}
			set
			{
				this._SyncCount = value;
			}
		}

		[ProtoMember(20, IsRequired = false, Name = "IsDNS", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IsDNS
		{
			get
			{
				return this._IsDNS;
			}
			set
			{
				this._IsDNS = value;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "IsSocket", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IsSocket
		{
			get
			{
				return this._IsSocket;
			}
			set
			{
				this._IsSocket = value;
			}
		}

		[ProtoMember(22, IsRequired = false, Name = "ErrCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int ErrCode
		{
			get
			{
				return this._ErrCode;
			}
			set
			{
				this._ErrCode = value;
			}
		}

		[ProtoMember(23, IsRequired = false, Name = "SignalStrength", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SignalStrength
		{
			get
			{
				return this._SignalStrength;
			}
			set
			{
				this._SignalStrength = value;
			}
		}

		[ProtoMember(24, IsRequired = false, Name = "ISPCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ISPCode
		{
			get
			{
				return this._ISPCode;
			}
			set
			{
				this._ISPCode = value;
			}
		}

		[ProtoMember(25, IsRequired = false, Name = "ISPName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ISPName
		{
			get
			{
				return this._ISPName;
			}
			set
			{
				this._ISPName = value;
			}
		}

		[ProtoMember(26, IsRequired = false, Name = "RetryCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint RetryCount
		{
			get
			{
				return this._RetryCount;
			}
			set
			{
				this._RetryCount = value;
			}
		}

		[ProtoMember(27, IsRequired = false, Name = "Host", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Host
		{
			get
			{
				return this._Host;
			}
			set
			{
				this._Host = value;
			}
		}

		[ProtoMember(28, IsRequired = false, Name = "IPCnt", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint IPCnt
		{
			get
			{
				return this._IPCnt;
			}
			set
			{
				this._IPCnt = value;
			}
		}

		[ProtoMember(29, IsRequired = false, Name = "reserved1", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong reserved1
		{
			get
			{
				return this._reserved1;
			}
			set
			{
				this._reserved1 = value;
			}
		}

		[ProtoMember(30, IsRequired = false, Name = "reserved2", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong reserved2
		{
			get
			{
				return this._reserved2;
			}
			set
			{
				this._reserved2 = value;
			}
		}

		[ProtoMember(31, IsRequired = false, Name = "reserved3", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong reserved3
		{
			get
			{
				return this._reserved3;
			}
			set
			{
				this._reserved3 = value;
			}
		}

		[ProtoMember(32, IsRequired = false, Name = "ClientIP", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ClientIP
		{
			get
			{
				return this._ClientIP;
			}
			set
			{
				this._ClientIP = value;
			}
		}

		[ProtoMember(33, IsRequired = false, Name = "NetworkCost", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NetworkCost
		{
			get
			{
				return this._NetworkCost;
			}
			set
			{
				this._NetworkCost = value;
			}
		}

		[ProtoMember(34, IsRequired = false, Name = "DnsCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint DnsCount
		{
			get
			{
				return this._DnsCount;
			}
			set
			{
				this._DnsCount = value;
			}
		}

		[ProtoMember(35, IsRequired = false, Name = "DnsCost", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint DnsCost
		{
			get
			{
				return this._DnsCost;
			}
			set
			{
				this._DnsCost = value;
			}
		}

		[ProtoMember(36, IsRequired = false, Name = "ConnCount", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ConnCount
		{
			get
			{
				return this._ConnCount;
			}
			set
			{
				this._ConnCount = value;
			}
		}

		[ProtoMember(37, IsRequired = false, Name = "ConnCost", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ConnCost
		{
			get
			{
				return this._ConnCost;
			}
			set
			{
				this._ConnCost = value;
			}
		}

		[ProtoMember(38, IsRequired = false, Name = "NewDnsCostTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewDnsCostTime
		{
			get
			{
				return this._NewDnsCostTime;
			}
			set
			{
				this._NewDnsCostTime = value;
			}
		}

		[ProtoMember(39, IsRequired = false, Name = "NewDnsErrType", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewDnsErrType
		{
			get
			{
				return this._NewDnsErrType;
			}
			set
			{
				this._NewDnsErrType = value;
			}
		}

		[ProtoMember(40, IsRequired = false, Name = "NewDnsErrCode", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewDnsErrCode
		{
			get
			{
				return this._NewDnsErrCode;
			}
			set
			{
				this._NewDnsErrCode = value;
			}
		}

		[ProtoMember(41, IsRequired = false, Name = "NewDnsSvrIp", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint NewDnsSvrIp
		{
			get
			{
				return this._NewDnsSvrIp;
			}
			set
			{
				this._NewDnsSvrIp = value;
			}
		}

		[ProtoMember(42, IsRequired = false, Name = "FirstPkgTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FirstPkgTime
		{
			get
			{
				return this._FirstPkgTime;
			}
			set
			{
				this._FirstPkgTime = value;
			}
		}

		[ProtoMember(43, IsRequired = false, Name = "EndFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint EndFlag
		{
			get
			{
				return this._EndFlag;
			}
			set
			{
				this._EndFlag = value;
			}
		}

		[ProtoMember(44, IsRequired = false, Name = "TotalTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TotalTime
		{
			get
			{
				return this._TotalTime;
			}
			set
			{
				this._TotalTime = value;
			}
		}

		[ProtoMember(45, IsRequired = false, Name = "Conncosttime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Conncosttime
		{
			get
			{
				return this._Conncosttime;
			}
			set
			{
				this._Conncosttime = value;
			}
		}

		[ProtoMember(46, IsRequired = false, Name = "Endstep", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Endstep
		{
			get
			{
				return this._Endstep;
			}
			set
			{
				this._Endstep = value;
			}
		}

		[ProtoMember(47, IsRequired = false, Name = "Dnscosttime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Dnscosttime
		{
			get
			{
				return this._Dnscosttime;
			}
			set
			{
				this._Dnscosttime = value;
			}
		}

		[ProtoMember(48, IsRequired = false, Name = "Dnserrtype", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Dnserrtype
		{
			get
			{
				return this._Dnserrtype;
			}
			set
			{
				this._Dnserrtype = value;
			}
		}

		[ProtoMember(49, IsRequired = false, Name = "NewNetType", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int NewNetType
		{
			get
			{
				return this._NewNetType;
			}
			set
			{
				this._NewNetType = value;
			}
		}

		[ProtoMember(50, IsRequired = false, Name = "SubNetType", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int SubNetType
		{
			get
			{
				return this._SubNetType;
			}
			set
			{
				this._SubNetType = value;
			}
		}

		[ProtoMember(51, IsRequired = false, Name = "NetExtraInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NetExtraInfo
		{
			get
			{
				return this._NetExtraInfo;
			}
			set
			{
				this._NetExtraInfo = value;
			}
		}

		[ProtoMember(52, IsRequired = false, Name = "StatReportExtraInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string StatReportExtraInfo
		{
			get
			{
				return this._StatReportExtraInfo;
			}
			set
			{
				this._StatReportExtraInfo = value;
			}
		}

		[ProtoMember(53, IsRequired = false, Name = "TotalConnCost", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int TotalConnCost
		{
			get
			{
				return this._TotalConnCost;
			}
			set
			{
				this._TotalConnCost = value;
			}
		}

		[ProtoMember(54, IsRequired = false, Name = "IpIndex", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int IpIndex
		{
			get
			{
				return this._IpIndex;
			}
			set
			{
				this._IpIndex = value;
			}
		}

		[ProtoMember(55, IsRequired = false, Name = "InnerIp", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int InnerIp
		{
			get
			{
				return this._InnerIp;
			}
			set
			{
				this._InnerIp = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
