using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BizScopeInfo")]
	[Serializable]
	public class BizScopeInfo : IExtensible
	{
		private string _Scope = "";

		private uint _ScopeStatus;

		private string _ScopeDesc = "";

		private uint _ApiCount;

		private readonly List<BizApiInfo> _ApiList = new List<BizApiInfo>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Scope", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Scope
		{
			get
			{
				return this._Scope;
			}
			set
			{
				this._Scope = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "ScopeStatus", DataFormat = DataFormat.TwosComplement)]
		public uint ScopeStatus
		{
			get
			{
				return this._ScopeStatus;
			}
			set
			{
				this._ScopeStatus = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "ScopeDesc", DataFormat = DataFormat.Default), DefaultValue("")]
		public string ScopeDesc
		{
			get
			{
				return this._ScopeDesc;
			}
			set
			{
				this._ScopeDesc = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ApiCount", DataFormat = DataFormat.TwosComplement)]
		public uint ApiCount
		{
			get
			{
				return this._ApiCount;
			}
			set
			{
				this._ApiCount = value;
			}
		}

		[ProtoMember(5, Name = "ApiList", DataFormat = DataFormat.Default)]
		public List<BizApiInfo> ApiList
		{
			get
			{
				return this._ApiList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
