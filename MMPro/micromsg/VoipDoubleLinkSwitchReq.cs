using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "VoipDoubleLinkSwitchReq")]
	[Serializable]
	public class VoipDoubleLinkSwitchReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _RoomId;

		private long _RoomKey;

		private int _RoomMemberId;

		private int _CurLinkType;

		private int _IsRelayConnReady;

		private int _IsDirectConnReady;

		private int _CurStrategy;

		private int _BufferVersion;

		private SKBuiltinBuffer_t _Buffer;

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

		[ProtoMember(2, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
		public int RoomId
		{
			get
			{
				return this._RoomId;
			}
			set
			{
				this._RoomId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
		public long RoomKey
		{
			get
			{
				return this._RoomKey;
			}
			set
			{
				this._RoomKey = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "RoomMemberId", DataFormat = DataFormat.TwosComplement)]
		public int RoomMemberId
		{
			get
			{
				return this._RoomMemberId;
			}
			set
			{
				this._RoomMemberId = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "CurLinkType", DataFormat = DataFormat.TwosComplement)]
		public int CurLinkType
		{
			get
			{
				return this._CurLinkType;
			}
			set
			{
				this._CurLinkType = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "IsRelayConnReady", DataFormat = DataFormat.TwosComplement)]
		public int IsRelayConnReady
		{
			get
			{
				return this._IsRelayConnReady;
			}
			set
			{
				this._IsRelayConnReady = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "IsDirectConnReady", DataFormat = DataFormat.TwosComplement)]
		public int IsDirectConnReady
		{
			get
			{
				return this._IsDirectConnReady;
			}
			set
			{
				this._IsDirectConnReady = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "CurStrategy", DataFormat = DataFormat.TwosComplement)]
		public int CurStrategy
		{
			get
			{
				return this._CurStrategy;
			}
			set
			{
				this._CurStrategy = value;
			}
		}

		[ProtoMember(9, IsRequired = true, Name = "BufferVersion", DataFormat = DataFormat.TwosComplement)]
		public int BufferVersion
		{
			get
			{
				return this._BufferVersion;
			}
			set
			{
				this._BufferVersion = value;
			}
		}

		[ProtoMember(10, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
