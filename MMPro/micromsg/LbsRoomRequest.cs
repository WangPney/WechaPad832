using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "LbsRoomRequest")]
	[Serializable]
	public class LbsRoomRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpCode;

		private float _Longitude;

		private float _Latitude;

		private int _Precision;

		private string _MacAddr = "";

		private string _CellId = "";

		private int _GPSSource = 0;

		private string _RoomName = "";

		private int _ExitScene = 0;

		private int _StayTime = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.FixedSize)]
		public float Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				this._Longitude = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.FixedSize)]
		public float Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				this._Latitude = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Precision", DataFormat = DataFormat.TwosComplement)]
		public int Precision
		{
			get
			{
				return this._Precision;
			}
			set
			{
				this._Precision = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "MacAddr", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MacAddr
		{
			get
			{
				return this._MacAddr;
			}
			set
			{
				this._MacAddr = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "CellId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CellId
		{
			get
			{
				return this._CellId;
			}
			set
			{
				this._CellId = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "GPSSource", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int GPSSource
		{
			get
			{
				return this._GPSSource;
			}
			set
			{
				this._GPSSource = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "RoomName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string RoomName
		{
			get
			{
				return this._RoomName;
			}
			set
			{
				this._RoomName = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "ExitScene", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int ExitScene
		{
			get
			{
				return this._ExitScene;
			}
			set
			{
				this._ExitScene = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "StayTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int StayTime
		{
			get
			{
				return this._StayTime;
			}
			set
			{
				this._StayTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
