using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "CheckVoiceTransResponse")]
	[Serializable]
	public class CheckVoiceTransResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _Status;

		private VoiceTransRes _TransRes;

		private UploadVoiceCtx _UploadCtx;

		private QueryResCtx _QueryCtx;

		private uint _NotifyId;

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

		[ProtoMember(2, IsRequired = true, Name = "Status", DataFormat = DataFormat.TwosComplement)]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TransRes", DataFormat = DataFormat.Default)]
		public VoiceTransRes TransRes
		{
			get
			{
				return this._TransRes;
			}
			set
			{
				this._TransRes = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "UploadCtx", DataFormat = DataFormat.Default)]
		public UploadVoiceCtx UploadCtx
		{
			get
			{
				return this._UploadCtx;
			}
			set
			{
				this._UploadCtx = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "QueryCtx", DataFormat = DataFormat.Default)]
		public QueryResCtx QueryCtx
		{
			get
			{
				return this._QueryCtx;
			}
			set
			{
				this._QueryCtx = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "NotifyId", DataFormat = DataFormat.TwosComplement)]
		public uint NotifyId
		{
			get
			{
				return this._NotifyId;
			}
			set
			{
				this._NotifyId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
