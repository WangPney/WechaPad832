using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsClassifyTimeLineRequest")]
	[Serializable]
	public class SnsClassifyTimeLineRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FirstPageMd5 = "";

		private ulong _MaxId;

		private string _ClassifyId = "";

		private uint _ClassifyType;

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

		[ProtoMember(2, IsRequired = false, Name = "FirstPageMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FirstPageMd5
		{
			get
			{
				return this._FirstPageMd5;
			}
			set
			{
				this._FirstPageMd5 = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MaxId", DataFormat = DataFormat.TwosComplement)]
		public ulong MaxId
		{
			get
			{
				return this._MaxId;
			}
			set
			{
				this._MaxId = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ClassifyId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClassifyId
		{
			get
			{
				return this._ClassifyId;
			}
			set
			{
				this._ClassifyId = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ClassifyType", DataFormat = DataFormat.TwosComplement)]
		public uint ClassifyType
		{
			get
			{
				return this._ClassifyType;
			}
			set
			{
				this._ClassifyType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
