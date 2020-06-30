using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsUserInfo")]
	[Serializable]
	public class SnsUserInfo : IExtensible
	{
		private uint _SnsFlag;

		private string _SnsBGImgID = "";

		private ulong _SnsBGObjectID = 0uL;

		private uint _SnsFlagEx = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SnsFlag", DataFormat = DataFormat.TwosComplement)]
		public uint SnsFlag
		{
			get
			{
				return this._SnsFlag;
			}
			set
			{
				this._SnsFlag = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "SnsBGImgID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string SnsBGImgID
		{
			get
			{
				return this._SnsBGImgID;
			}
			set
			{
				this._SnsBGImgID = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "SnsBGObjectID", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong SnsBGObjectID
		{
			get
			{
				return this._SnsBGObjectID;
			}
			set
			{
				this._SnsBGObjectID = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "SnsFlagEx", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint SnsFlagEx
		{
			get
			{
				return this._SnsFlagEx;
			}
			set
			{
				this._SnsFlagEx = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
