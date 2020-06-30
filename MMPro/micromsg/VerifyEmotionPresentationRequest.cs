using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "VerifyEmotionPresentationRequest")]
	[Serializable]
	public class VerifyEmotionPresentationRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _ProductID = "";

		private uint _MemberCount;

		private readonly List<EmotionMember> _MemberList = new List<EmotionMember>();

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

		[ProtoMember(2, IsRequired = false, Name = "ProductID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "MemberCount", DataFormat = DataFormat.TwosComplement)]
		public uint MemberCount
		{
			get
			{
				return this._MemberCount;
			}
			set
			{
				this._MemberCount = value;
			}
		}

		[ProtoMember(4, Name = "MemberList", DataFormat = DataFormat.Default)]
		public List<EmotionMember> MemberList
		{
			get
			{
				return this._MemberList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
