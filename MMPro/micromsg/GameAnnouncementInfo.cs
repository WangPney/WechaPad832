using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GameAnnouncementInfo")]
	[Serializable]
	public class GameAnnouncementInfo : IExtensible
	{
		private uint _Style;

		private string _Title = "";

		private string _Desc = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Style", DataFormat = DataFormat.TwosComplement)]
		public uint Style
		{
			get
			{
				return this._Style;
			}
			set
			{
				this._Style = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Title", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(3, IsRequired = false, Name = "Desc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Desc
		{
			get
			{
				return this._Desc;
			}
			set
			{
				this._Desc = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
