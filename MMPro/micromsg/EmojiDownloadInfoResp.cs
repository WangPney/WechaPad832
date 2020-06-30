using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "EmojiDownloadInfoResp")]
	[Serializable]
	public class EmojiDownloadInfoResp : IExtensible
	{
		private int _Ret;

		private int _StartPos;

		private int _TotalLen;

		private SKBuiltinBuffer_t _EmojiBuffer;

		private string _MD5 = "";

		private string _ID = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
		public int Ret
		{
			get
			{
				return this._Ret;
			}
			set
			{
				this._Ret = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public int StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public int TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "EmojiBuffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t EmojiBuffer
		{
			get
			{
				return this._EmojiBuffer;
			}
			set
			{
				this._EmojiBuffer = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "MD5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string MD5
		{
			get
			{
				return this._MD5;
			}
			set
			{
				this._MD5 = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "ID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
