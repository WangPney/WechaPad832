using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SecAuthRegKeySect")]
	[Serializable]
	public class SecAuthRegKeySect : IExtensible
	{
		private SKBuiltinBuffer_t _AutoAuthKey;

		private ECDHKey _SvrPubECDHKey;

		private SKBuiltinBuffer_t _SessionKey;

		private uint _AuthResultFlag;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "AutoAuthKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t AutoAuthKey
		{
			get
			{
				return this._AutoAuthKey;
			}
			set
			{
				this._AutoAuthKey = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "SvrPubECDHKey", DataFormat = DataFormat.Default)]
		public ECDHKey SvrPubECDHKey
		{
			get
			{
				return this._SvrPubECDHKey;
			}
			set
			{
				this._SvrPubECDHKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "SessionKey", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t SessionKey
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

		[ProtoMember(4, IsRequired = true, Name = "AuthResultFlag", DataFormat = DataFormat.TwosComplement)]
		public uint AuthResultFlag
		{
			get
			{
				return this._AuthResultFlag;
			}
			set
			{
				this._AuthResultFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
