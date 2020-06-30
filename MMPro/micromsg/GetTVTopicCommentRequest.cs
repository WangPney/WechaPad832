using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetTVTopicCommentRequest")]
	[Serializable]
	public class GetTVTopicCommentRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _TVTopic = "";

		private uint _LastCommentId;

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

		[ProtoMember(2, IsRequired = false, Name = "TVTopic", DataFormat = DataFormat.Default), DefaultValue("")]
		public string TVTopic
		{
			get
			{
				return this._TVTopic;
			}
			set
			{
				this._TVTopic = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "LastCommentId", DataFormat = DataFormat.TwosComplement)]
		public uint LastCommentId
		{
			get
			{
				return this._LastCommentId;
			}
			set
			{
				this._LastCommentId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
