using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ExtDevLoginType")]
	public enum ExtDevLoginType
	{
		[ProtoEnum(Name = "EXTDEV_LOGINTYPE_NORMAL", Value = 0)]
		EXTDEV_LOGINTYPE_NORMAL,
		[ProtoEnum(Name = "EXTDEV_LOGINTYPE_TMP", Value = 1)]
		EXTDEV_LOGINTYPE_TMP,
		[ProtoEnum(Name = "EXTDEV_LOGINTYPE_PAIR", Value = 2)]
		EXTDEV_LOGINTYPE_PAIR
	}
}
