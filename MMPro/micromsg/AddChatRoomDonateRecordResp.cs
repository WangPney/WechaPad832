using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AddChatRoomDonateRecordResp")]
	[Serializable]
	public class AddChatRoomDonateRecordResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MaxCount;

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

		[ProtoMember(2, IsRequired = true, Name = "MaxCount", DataFormat = DataFormat.TwosComplement)]
		public uint MaxCount
		{
			get
			{
				return this._MaxCount;
			}
			set
			{
				this._MaxCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
