using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GameSyncResponse")]
	[Serializable]
	public class GameSyncResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private CmdList _CmdList;

		private SKBuiltinBuffer_t _KeyBuf;

		private uint _ContinueFlag;

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

		[ProtoMember(2, IsRequired = true, Name = "CmdList", DataFormat = DataFormat.Default)]
		public CmdList CmdList
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

		[ProtoMember(3, IsRequired = true, Name = "KeyBuf", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public uint ContinueFlag
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
