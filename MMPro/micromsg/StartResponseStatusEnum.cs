using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "StartResponseStatusEnum")]
	public enum StartResponseStatusEnum
	{
		[ProtoEnum(Name = "START_RESPONSE_SUCCESS", Value = 0)]
		START_RESPONSE_SUCCESS,
		[ProtoEnum(Name = "START_RESPONSE_ID_WRONG", Value = 1)]
		START_RESPONSE_ID_WRONG,
		[ProtoEnum(Name = "START_RESPONSE_SIZE_WRONG", Value = 2)]
		START_RESPONSE_SIZE_WRONG
	}
}
