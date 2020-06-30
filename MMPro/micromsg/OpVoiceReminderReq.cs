using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "OpVoiceReminderReq")]
	[Serializable]
	public class OpVoiceReminderReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _OpCode;

		private uint _RemindInfoNum;

		private readonly List<VoiceRemindInfo> _RemindInfoList = new List<VoiceRemindInfo>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public int OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "RemindInfoNum", DataFormat = DataFormat.TwosComplement)]
		public uint RemindInfoNum
		{
			get
			{
				return this._RemindInfoNum;
			}
			set
			{
				this._RemindInfoNum = value;
			}
		}

		[ProtoMember(4, Name = "RemindInfoList", DataFormat = DataFormat.Default)]
		public List<VoiceRemindInfo> RemindInfoList
		{
			get
			{
				return this._RemindInfoList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
