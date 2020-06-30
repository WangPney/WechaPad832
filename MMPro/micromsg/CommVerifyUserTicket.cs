using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "CommVerifyUserTicket")]
	[Serializable]
	public class CommVerifyUserTicket : IExtensible
	{
		private uint _TicketType;

		private uint _Source;

		private uint _FromUin;

		private uint _ToUin;

		private SKBuiltinString_t _ExtInfo;

		private uint _TimeStamp;

		private uint _FriendFlag = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "TicketType", DataFormat = DataFormat.TwosComplement)]
		public uint TicketType
		{
			get
			{
				return this._TicketType;
			}
			set
			{
				this._TicketType = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Source", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "FromUin", DataFormat = DataFormat.TwosComplement)]
		public uint FromUin
		{
			get
			{
				return this._FromUin;
			}
			set
			{
				this._FromUin = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ToUin", DataFormat = DataFormat.TwosComplement)]
		public uint ToUin
		{
			get
			{
				return this._ToUin;
			}
			set
			{
				this._ToUin = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ExtInfo", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ExtInfo
		{
			get
			{
				return this._ExtInfo;
			}
			set
			{
				this._ExtInfo = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				this._TimeStamp = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "FriendFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FriendFlag
		{
			get
			{
				return this._FriendFlag;
			}
			set
			{
				this._FriendFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
