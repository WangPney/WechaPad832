using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "CommandTypeEnum")]
	public enum CommandTypeEnum
	{
		[ProtoEnum(Name = "COMMAND_REQUEST_TO_BACKUP", Value = 1)]
		COMMAND_REQUEST_TO_BACKUP = 1,
		[ProtoEnum(Name = "COMMAND_CONFIRM_BACKUP", Value = 2)]
		COMMAND_CONFIRM_BACKUP,
		[ProtoEnum(Name = "COMMAND_REQUEST_TO_RECOVER", Value = 3)]
		COMMAND_REQUEST_TO_RECOVER,
		[ProtoEnum(Name = "COMMAND_CONFIRM_RECOVER", Value = 4)]
		COMMAND_CONFIRM_RECOVER,
		[ProtoEnum(Name = "COMMAND_REQUEST_TO_CONTINUE_BACKUP", Value = 5)]
		COMMAND_REQUEST_TO_CONTINUE_BACKUP,
		[ProtoEnum(Name = "COMMAND_CONFIRM_CONTINUE_BACKUP", Value = 6)]
		COMMAND_CONFIRM_CONTINUE_BACKUP,
		[ProtoEnum(Name = "COMMAND_REQUEST_TO_CONTINUE_RECOVER", Value = 7)]
		COMMAND_REQUEST_TO_CONTINUE_RECOVER,
		[ProtoEnum(Name = "COMMAND_CONFIRM_CONTINUE_RECOVER", Value = 8)]
		COMMAND_CONFIRM_CONTINUE_RECOVER
	}
}
