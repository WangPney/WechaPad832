using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Presentation")]
	[Serializable]
	public class Presentation : IExtensible
	{
		private uint _Time;

		private string _UserName = "";

		private string _NickName = "";

		private string _Title = "";

		private uint _Price;

		private string _WebUrl = "";

		private uint _Num;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "NickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Price", DataFormat = DataFormat.TwosComplement)]
		public uint Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				this._Price = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "WebUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string WebUrl
		{
			get
			{
				return this._WebUrl;
			}
			set
			{
				this._WebUrl = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "Num", DataFormat = DataFormat.TwosComplement)]
		public uint Num
		{
			get
			{
				return this._Num;
			}
			set
			{
				this._Num = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
