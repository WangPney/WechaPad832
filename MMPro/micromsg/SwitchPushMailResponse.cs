using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SwitchPushMailResponse")]
	[Serializable]
	public class SwitchPushMailResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _SwitchValue;

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

		[ProtoMember(2, IsRequired = true, Name = "SwitchValue", DataFormat = DataFormat.TwosComplement)]
		public uint SwitchValue
		{
			get
			{
				return this._SwitchValue;
			}
			set
			{
				this._SwitchValue = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
