using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ClickCommandRequest")]
	[Serializable]
	public class ClickCommandRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _ClickType;

		private string _ClickInfo = "";

		private string _BizUserName = "";

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

		[ProtoMember(2, IsRequired = true, Name = "ClickType", DataFormat = DataFormat.TwosComplement)]
		public uint ClickType
		{
			get
			{
				return this._ClickType;
			}
			set
			{
				this._ClickType = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ClickInfo", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClickInfo
		{
			get
			{
				return this._ClickInfo;
			}
			set
			{
				this._ClickInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "BizUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BizUserName
		{
			get
			{
				return this._BizUserName;
			}
			set
			{
				this._BizUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
