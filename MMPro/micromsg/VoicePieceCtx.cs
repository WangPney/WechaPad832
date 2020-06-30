using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "VoicePieceCtx")]
	[Serializable]
	public class VoicePieceCtx : IExtensible
	{
		private uint _StartPos;

		private uint _PieceLen;

		private uint _PieceFlag;

		private SKBuiltinBuffer_t _PieceData;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = true, Name = "PieceLen", DataFormat = DataFormat.TwosComplement)]
		public uint PieceLen
		{
			get
			{
				return this._PieceLen;
			}
			set
			{
				this._PieceLen = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "PieceFlag", DataFormat = DataFormat.TwosComplement)]
		public uint PieceFlag
		{
			get
			{
				return this._PieceFlag;
			}
			set
			{
				this._PieceFlag = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "PieceData", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t PieceData
		{
			get
			{
				return this._PieceData;
			}
			set
			{
				this._PieceData = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
