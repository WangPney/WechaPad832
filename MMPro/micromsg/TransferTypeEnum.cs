using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "TransferTypeEnum")]
	public enum TransferTypeEnum
	{
		[ProtoEnum(Name = "TRANSFER_NEW", Value = 0)]
		TRANSFER_NEW,
		[ProtoEnum(Name = "TRANSFER_ADDON", Value = 1)]
		TRANSFER_ADDON
	}
}
