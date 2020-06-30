using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Host")]
	[Serializable]
	public class Host : IExtensible
	{
		private string _Origin = "";

		private string _Substitute = "";

		private int _Priority = 0;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "Origin", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Origin
		{
			get
			{
				return this._Origin;
			}
			set
			{
				this._Origin = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Substitute", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Substitute
		{
			get
			{
				return this._Substitute;
			}
			set
			{
				this._Substitute = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Priority", DataFormat = DataFormat.TwosComplement), DefaultValue(0)]
		public int Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				this._Priority = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
