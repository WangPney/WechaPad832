using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SyncResponse")]
	[Serializable]
	public class SyncResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _NewSyncKey;

		private int _ContinueFlag;

		private uint _CmdCount;

		private readonly List<CmdItem> _CmdList = new List<CmdItem>();

		private uint _OOBCount;

		private readonly List<CmdItem> _OOBList = new List<CmdItem>();

		private string _KeyBuf = "";

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

		[ProtoMember(2, IsRequired = true, Name = "NewSyncKey", DataFormat = DataFormat.TwosComplement)]
		public uint NewSyncKey
		{
			get
			{
				return this._NewSyncKey;
			}
			set
			{
				this._NewSyncKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public int ContinueFlag
		{
			get
			{
				return this._ContinueFlag;
			}
			set
			{
				this._ContinueFlag = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "CmdCount", DataFormat = DataFormat.TwosComplement)]
		public uint CmdCount
		{
			get
			{
				return this._CmdCount;
			}
			set
			{
				this._CmdCount = value;
			}
		}

		[ProtoMember(5, Name = "CmdList", DataFormat = DataFormat.Default)]
		public List<CmdItem> CmdList
		{
			get
			{
				return this._CmdList;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "OOBCount", DataFormat = DataFormat.TwosComplement)]
		public uint OOBCount
		{
			get
			{
				return this._OOBCount;
			}
			set
			{
				this._OOBCount = value;
			}
		}

		[ProtoMember(7, Name = "OOBList", DataFormat = DataFormat.Default)]
		public List<CmdItem> OOBList
		{
			get
			{
				return this._OOBList;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "KeyBuf", DataFormat = DataFormat.Default), DefaultValue("")]
		public string KeyBuf
		{
			get
			{
				return this._KeyBuf;
			}
			set
			{
				this._KeyBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
