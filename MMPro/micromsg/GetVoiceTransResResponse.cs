using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetVoiceTransResResponse")]
	[Serializable]
	public class GetVoiceTransResResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private VoiceTransRes _TransRes;

		private QueryResCtx _QueryCtx;

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

		[ProtoMember(2, IsRequired = true, Name = "TransRes", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = true, Name = "QueryCtx", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
