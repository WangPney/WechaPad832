using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "IBeaconBoardcastRequest")]
	[Serializable]
	public class IBeaconBoardcastRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _BizUsername = "";

		private string _Content = "";

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

		[ProtoMember(2, IsRequired = false, Name = "BizUsername", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BizUsername
		{
			get
			{
				return this._BizUsername;
			}
			set
			{
				this._BizUsername = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
