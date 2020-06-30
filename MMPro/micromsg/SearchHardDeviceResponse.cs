using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SearchHardDeviceResponse")]
	[Serializable]
	public class SearchHardDeviceResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private ModContact _Contact;

		private HardDevice _HardDevice;

		private HardDeviceAttr _HardDeviceAttr;

		private string _BindTicket = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Contact", DataFormat = DataFormat.Default)]
		public ModContact Contact
		{
			get
			{
				return this._Contact;
			}
			set
			{
				this._Contact = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "HardDevice", DataFormat = DataFormat.Default)]
		public HardDevice HardDevice
		{
			get
			{
				return this._HardDevice;
			}
			set
			{
				this._HardDevice = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "HardDeviceAttr", DataFormat = DataFormat.Default)]
		public HardDeviceAttr HardDeviceAttr
		{
			get
			{
				return this._HardDeviceAttr;
			}
			set
			{
				this._HardDeviceAttr = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "BindTicket", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BindTicket
		{
			get
			{
				return this._BindTicket;
			}
			set
			{
				this._BindTicket = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
