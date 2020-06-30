using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "VoipSyncResp")]
	[Serializable]
	public class VoipSyncResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _RoomId;

		private SKBuiltinBuffer_t _KeyBuf;

		private VoipCmdList _CmdList;

		private int _ContinueFlag;

		private long _RoomKey;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RoomId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = true, Name = "KeyBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KeyBuf
		{
			get
			{
				return this._KeyBuf;
			}
			set
			{
				this._KeyBuf = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "CmdList", DataFormat = DataFormat.Default)]
		public VoipCmdList CmdList
		{
			get
			{
				return this._CmdList;
			}
			set
			{
				this._CmdList = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public int ContinueFlag
		{
			get
			{
				return this._ContinueFlag;
			}
			set
			{
				this._ContinueFlag = value;
			}
		}

		[ProtoMember(8, IsRequired = true, Name = "RoomKey", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
