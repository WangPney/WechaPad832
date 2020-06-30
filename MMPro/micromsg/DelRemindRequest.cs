using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DelRemindRequest")]
	[Serializable]
	public class DelRemindRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _RemindID;

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

		[ProtoMember(2, IsRequired = true, Name = "RemindID", DataFormat = DataFormat.TwosComplement)]
		public uint RemindID
		{
			get
			{
				return this._RemindID;
			}
			set
			{
				this._RemindID = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
