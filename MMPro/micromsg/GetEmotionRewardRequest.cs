using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetEmotionRewardRequest")]
	[Serializable]
	public class GetEmotionRewardRequest : IExtensible
	{
		private string _ProductID;

		private uint _OpCode;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ProductID", DataFormat = DataFormat.Default)]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
