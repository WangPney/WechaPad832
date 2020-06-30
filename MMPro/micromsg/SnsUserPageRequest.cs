using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsUserPageRequest")]
	[Serializable]
	public class SnsUserPageRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private string _FirstPageMd5 = "";

		private string _Username = "";

		private ulong _MaxId;

		private uint _Source = 0u;

		private ulong _MinFilterId = 0uL;

		private uint _LastRequestTime = 0u;

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

		[ProtoMember(2, IsRequired = false, Name = "FirstPageMd5", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FirstPageMd5
		{
			get
			{
				return this._FirstPageMd5;
			}
			set
			{
				this._FirstPageMd5 = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Username", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this._Username = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "MaxId", DataFormat = DataFormat.TwosComplement)]
		public ulong MaxId
		{
			get
			{
				return this._MaxId;
			}
			set
			{
				this._MaxId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Source", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				this._Source = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "MinFilterId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong MinFilterId
		{
			get
			{
				return this._MinFilterId;
			}
			set
			{
				this._MinFilterId = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "LastRequestTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint LastRequestTime
		{
			get
			{
				return this._LastRequestTime;
			}
			set
			{
				this._LastRequestTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
