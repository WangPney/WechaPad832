using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RegisterVoicePrintRequest")]
	[Serializable]
	public class RegisterVoicePrintRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Step;

		private uint _VoiceTicket;

		private VoicePieceCtx _PieceData;

		private uint _ResId;

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

		[ProtoMember(2, IsRequired = true, Name = "Step", DataFormat = DataFormat.TwosComplement)]
		public uint Step
		{
			get
			{
				return this._Step;
			}
			set
			{
				this._Step = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "VoiceTicket", DataFormat = DataFormat.TwosComplement)]
		public uint VoiceTicket
		{
			get
			{
				return this._VoiceTicket;
			}
			set
			{
				this._VoiceTicket = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "PieceData", DataFormat = DataFormat.Default)]
		public VoicePieceCtx PieceData
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

		[ProtoMember(5, IsRequired = true, Name = "ResId", DataFormat = DataFormat.TwosComplement)]
		public uint ResId
		{
			get
			{
				return this._ResId;
			}
			set
			{
				this._ResId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
