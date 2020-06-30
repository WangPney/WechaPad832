using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Package")]
	[Serializable]
	public class Package : IExtensible
	{
		private int _Id;

		private int _Version;

		private string _Name = "";

		private uint _Size = 0u;

		private SKBuiltinBuffer_t _Thumb = null;

		private string _PackName = "";

		private SKBuiltinBuffer_t _Ext = null;

		private string _Md5 = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Id", DataFormat = DataFormat.TwosComplement)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Version", DataFormat = DataFormat.TwosComplement)]
		public int Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				this._Version = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Name", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Size", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				this._Size = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Thumb", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Thumb
		{
			get
			{
				return this._Thumb;
			}
			set
			{
				this._Thumb = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "PackName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string PackName
		{
			get
			{
				return this._PackName;
			}
			set
			{
				this._PackName = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "Ext", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				this._Ext = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "Md5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Md5
		{
			get
			{
				return this._Md5;
			}
			set
			{
				this._Md5 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
