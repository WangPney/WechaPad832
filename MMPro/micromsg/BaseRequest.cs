using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "BaseRequest")]
	[Serializable]
	public class BaseRequest : IExtensible
	{
		private byte[] _SessionKey;

		private uint _Uin;

		private byte[] _DeviceID;

		private int _ClientVersion;

		private byte[] _DeviceType;

		private uint _Scene = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "SessionKey", DataFormat = DataFormat.Default)]
		public byte[] SessionKey
		{
			get
			{
				return this._SessionKey;
			}
			set
			{
				this._SessionKey = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Uin", DataFormat = DataFormat.TwosComplement)]
		public uint Uin
		{
			get
			{
				return this._Uin;
			}
			set
			{
				this._Uin = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "DeviceID", DataFormat = DataFormat.Default)]
		public byte[] DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				this._DeviceID = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ClientVersion", DataFormat = DataFormat.TwosComplement)]
		public int ClientVersion
		{
			get
			{
				return this._ClientVersion;
			}
			set
			{
				this._ClientVersion = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "DeviceType", DataFormat = DataFormat.Default)]
		public byte[] DeviceType
		{
			get
			{
				return this._DeviceType;
			}
			set
			{
				this._DeviceType = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
