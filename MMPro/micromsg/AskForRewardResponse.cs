using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AskForRewardResponse")]
	[Serializable]
	public class AskForRewardResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private string _ReqKey;

		private string _AppID;

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

		[ProtoMember(2, IsRequired = true, Name = "ReqKey", DataFormat = DataFormat.Default)]
		public string ReqKey
		{
			get
			{
				return this._ReqKey;
			}
			set
			{
				this._ReqKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "AppID", DataFormat = DataFormat.Default)]
		public string AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
