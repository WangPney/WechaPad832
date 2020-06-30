using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "IBeaconNotification")]
	[Serializable]
	public class IBeaconNotification : IExtensible
	{
		private int _Result;

		private string _Tips = "";

		private string _Message = "";

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Result", DataFormat = DataFormat.TwosComplement)]
		public int Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				this._Result = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "Tips", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Tips
		{
			get
			{
				return this._Tips;
			}
			set
			{
				this._Tips = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Message", DataFormat = DataFormat.Default), DefaultValue("")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				this._Message = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
