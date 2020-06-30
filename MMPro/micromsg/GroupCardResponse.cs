using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GroupCardResponse")]
	[Serializable]
	public class GroupCardResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _GroupUserName = "";

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

		[ProtoMember(2, IsRequired = false, Name = "GroupUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string GroupUserName
		{
			get
			{
				return this._GroupUserName;
			}
			set
			{
				this._GroupUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
