using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GrantBigChatRoomResp")]
	[Serializable]
	public class GrantBigChatRoomResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Quota;

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

		[ProtoMember(2, IsRequired = true, Name = "Quota", DataFormat = DataFormat.TwosComplement)]
		public uint Quota
		{
			get
			{
				return this._Quota;
			}
			set
			{
				this._Quota = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
