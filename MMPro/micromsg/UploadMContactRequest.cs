using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UploadMContactRequest")]
	[Serializable]
	public class UploadMContactRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _UserName = "";

		private int _Opcode;

		private string _Mobile = "";

		private int _MobileListSize;

		private readonly List<Mobile> _MobileList = new List<Mobile>();

		private int _EmailListSize;

		private readonly List<MEmail> _EmailList = new List<MEmail>();

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

		[ProtoMember(3, IsRequired = true, Name = "Opcode", DataFormat = DataFormat.TwosComplement)]
		public int Opcode
		{
			get
			{
				return this._Opcode;
			}
			set
			{
				this._Opcode = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Mobile", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Mobile
		{
			get
			{
				return this._Mobile;
			}
			set
			{
				this._Mobile = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "MobileListSize", DataFormat = DataFormat.TwosComplement)]
		public int MobileListSize
		{
			get
			{
				return this._MobileListSize;
			}
			set
			{
				this._MobileListSize = value;
			}
		}

		[ProtoMember(6, Name = "MobileList", DataFormat = DataFormat.Default)]
		public List<Mobile> MobileList
		{
			get
			{
				return this._MobileList;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "EmailListSize", DataFormat = DataFormat.TwosComplement)]
		public int EmailListSize
		{
			get
			{
				return this._EmailListSize;
			}
			set
			{
				this._EmailListSize = value;
			}
		}

		[ProtoMember(8, Name = "EmailList", DataFormat = DataFormat.Default)]
		public List<MEmail> EmailList
		{
			get
			{
				return this._EmailList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
