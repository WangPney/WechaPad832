using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsActionGroup")]
	[Serializable]
	public class SnsActionGroup : IExtensible
	{
		private ulong _Id;

		private ulong _ParentId = 0uL;

		private SnsAction _CurrentAction;

		private SnsAction _ReferAction = null;

		private string _ClientId = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Id", DataFormat = DataFormat.TwosComplement)]
		public ulong Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ParentId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong ParentId
		{
			get
			{
				return this._ParentId;
			}
			set
			{
				this._ParentId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CurrentAction", DataFormat = DataFormat.Default)]
		public SnsAction CurrentAction
		{
			get
			{
				return this._CurrentAction;
			}
			set
			{
				this._CurrentAction = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ReferAction", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SnsAction ReferAction
		{
			get
			{
				return this._ReferAction;
			}
			set
			{
				this._ReferAction = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ClientId", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				this._ClientId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
