using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetChatRoomDonateHistoryResp")]
	[Serializable]
	public class GetChatRoomDonateHistoryResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _TotalCount;

		private readonly List<Donor> _List = new List<Donor>();

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

		[ProtoMember(2, IsRequired = true, Name = "TotalCount", DataFormat = DataFormat.TwosComplement)]
		public uint TotalCount
		{
			get
			{
				return this._TotalCount;
			}
			set
			{
				this._TotalCount = value;
			}
		}

		[ProtoMember(3, Name = "List", DataFormat = DataFormat.Default)]
		public List<Donor> List
		{
			get
			{
				return this._List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
