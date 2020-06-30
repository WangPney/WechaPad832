using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DelContactMsg")]
	[Serializable]
	public class DelContactMsg : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private int _MaxMsgId;

		private long _NewMsgId = 0L;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MaxMsgId", DataFormat = DataFormat.TwosComplement)]
		public int MaxMsgId
		{
			get
			{
				return this._MaxMsgId;
			}
			set
			{
				this._MaxMsgId = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public long NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
