using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UserActionReportResp")]
	[Serializable]
	public class UserActionReportResp : IExtensible
	{
		private BaseResponse _BaseResponse;

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
