using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "FavCDNItem")]
	[Serializable]
	public class FavCDNItem : IExtensible
	{
		private string _DataId = "";

		private string _FullMd5 = "";

		private string _Head256Md5 = "";

		private uint _FullSize;

		private string _CDNURL = "";

		private string _AESKey = "";

		private int _EncryVer;

		private string _VideoId = "";

		private int _Status;

		private int _DataStatus;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "DataId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string DataId
		{
			get
			{
				return this._DataId;
			}
			set
			{
				this._DataId = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "FullMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FullMd5
		{
			get
			{
				return this._FullMd5;
			}
			set
			{
				this._FullMd5 = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Head256Md5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Head256Md5
		{
			get
			{
				return this._Head256Md5;
			}
			set
			{
				this._Head256Md5 = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "FullSize", DataFormat = DataFormat.TwosComplement)]
		public uint FullSize
		{
			get
			{
				return this._FullSize;
			}
			set
			{
				this._FullSize = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "CDNURL", DataFormat = DataFormat.Default), DefaultValue("")]
		public string CDNURL
		{
			get
			{
				return this._CDNURL;
			}
			set
			{
				this._CDNURL = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "AESKey", DataFormat = DataFormat.Default), DefaultValue("")]
		public string AESKey
		{
			get
			{
				return this._AESKey;
			}
			set
			{
				this._AESKey = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "EncryVer", DataFormat = DataFormat.TwosComplement)]
		public int EncryVer
		{
			get
			{
				return this._EncryVer;
			}
			set
			{
				this._EncryVer = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "VideoId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string VideoId
		{
			get
			{
				return this._VideoId;
			}
			set
			{
				this._VideoId = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = true, Name = "DataStatus", DataFormat = DataFormat.TwosComplement)]
		public int DataStatus
		{
			get
			{
				return this._DataStatus;
			}
			set
			{
				this._DataStatus = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
