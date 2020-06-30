using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SwitchOpVoicePrintResponse")]
	[Serializable]
	public class SwitchOpVoicePrintResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _UserSwitch;

		private uint _UserStatus;

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

		[ProtoMember(2, IsRequired = true, Name = "UserSwitch", DataFormat = DataFormat.TwosComplement)]
		public uint UserSwitch
		{
			get
			{
				return this._UserSwitch;
			}
			set
			{
				this._UserSwitch = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "UserStatus", DataFormat = DataFormat.TwosComplement)]
		public uint UserStatus
		{
			get
			{
				return this._UserStatus;
			}
			set
			{
				this._UserStatus = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
