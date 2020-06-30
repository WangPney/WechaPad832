using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "TVTopicCommentItem")]
	[Serializable]
	public class TVTopicCommentItem : IExtensible
	{
		private string _UserName = "";

		private string _NickName = "";

		private string _BigHeadUrl = "";

		private string _SmallHeadUrl = "";

		private uint _TimeStamp;

		private string _Content = "";

		private uint _CommentId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(2, IsRequired = false, Name = "NickName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "BigHeadUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BigHeadUrl
		{
			get
			{
				return this._BigHeadUrl;
			}
			set
			{
				this._BigHeadUrl = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "SmallHeadUrl", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SmallHeadUrl
		{
			get
			{
				return this._SmallHeadUrl;
			}
			set
			{
				this._SmallHeadUrl = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Content", DataFormat = DataFormat.Default), DefaultValue("")]
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

		[ProtoMember(7, IsRequired = true, Name = "CommentId", DataFormat = DataFormat.TwosComplement)]
		public uint CommentId
		{
			get
			{
				return this._CommentId;
			}
			set
			{
				this._CommentId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
