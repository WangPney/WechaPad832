using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DownloadVoiceRequest")]
	[Serializable]
	public class DownloadVoiceRequest : IExtensible
	{
		private uint _MsgId;

		private uint _Offset;

		private uint _Length;

		private string _ClientMsgId = "";

		private BaseRequest _BaseRequest;

		private ulong _NewMsgId = 0uL;

		private string _ChatRoomName = "";

		private ulong _MasterBufId = 0uL;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Offset", DataFormat = DataFormat.TwosComplement)]
		public uint Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Length", DataFormat = DataFormat.TwosComplement)]
		public uint Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				this._Length = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ClientMsgId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientMsgId
		{
			get
			{
				return this._ClientMsgId;
			}
			set
			{
				this._ClientMsgId = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ChatRoomName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ChatRoomName
		{
			get
			{
				return this._ChatRoomName;
			}
			set
			{
				this._ChatRoomName = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "MasterBufId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong MasterBufId
		{
			get
			{
				return this._MasterBufId;
			}
			set
			{
				this._MasterBufId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
