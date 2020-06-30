using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetRecommendAppListRequest")]
	[Serializable]
	public class GetRecommendAppListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Start;

		private uint _Count;

		private string _InstalledList = "";

		private uint _IconType;

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

		[ProtoMember(2, IsRequired = true, Name = "Start", DataFormat = DataFormat.TwosComplement)]
		public uint Start
		{
			get
			{
				return this._Start;
			}
			set
			{
				this._Start = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "InstalledList", DataFormat = DataFormat.Default), DefaultValue("")]
		public string InstalledList
		{
			get
			{
				return this._InstalledList;
			}
			set
			{
				this._InstalledList = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "IconType", DataFormat = DataFormat.TwosComplement)]
		public uint IconType
		{
			get
			{
				return this._IconType;
			}
			set
			{
				this._IconType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
