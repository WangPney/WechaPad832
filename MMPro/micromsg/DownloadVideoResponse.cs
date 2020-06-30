using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DownloadVideoResponse")]
	[Serializable]
	public class DownloadVideoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MsgId;

		private uint _TotalLen;

		private uint _StartPos;

		private SKBuiltinBuffer_t _Data;

		private ulong _NewMsgId = 0uL;

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

		[ProtoMember(2, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public uint StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
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
